using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockServiceApi.Dtos;
using MockServiceApi.Models;
using MockServiceApi.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MockServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MockResponseController : ControllerBase
    {
        private readonly IMockResponseRepository _repository;

        public MockResponseController(IMockResponseRepository repository)
        {
            _repository = repository;
        }

        private static readonly HttpClient client = new HttpClient();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MockResponse>>> GetItemsAsync()
        {
            var items = await _repository.GetItemsAsync();
            // .Select(item => item as RestClientDto);
            return items.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MockResponse>> GetItemAsync(Guid id)
        {
            var item = await _repository.GetItemAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            return item;//.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<MockResponse>> CreateItemAsync(MockResponseDto mock)
        {
            MockResponse item = new MockResponse()
            {
                Id = Guid.NewGuid(),
                EndPoint = mock.EndPoint,
                HttpMethod = (HttpVerb)mock.HttpMethod,
                ResponseCode = mock.ResponseCode,
                ResponseBody = mock.ResponseBody
            };

            await _repository.CreateItemAsync(item);

            return Ok(item);//CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }); //item.AsDto());
        }

        [HttpPost("getDataRepo")]
        public async Task<ActionResult<List<JsonDocument>>> GetDataRepo([FromBody]RestClientDto item)
        {
            HttpResponseMessage streamTask = new HttpResponseMessage();
       
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            if (item.HttpMethod == 0)
            {   // get Request
                streamTask = await getMockService(item.EndPoint);
            }
            if (item.HttpMethod == 1)
            {
                // post 
                streamTask = postMockService(item.EndPoint, item.Parameter);
            }
            if (item.HttpMethod == 2)
            {
                // put
                streamTask = await putMockService(item.EndPoint, item.Parameter);
            }
            if (item.HttpMethod == 3)
            {
                // delete
                streamTask = await deleteMockService(item.EndPoint);
            }

            if (!streamTask.IsSuccessStatusCode)
                throw new Exception(streamTask.ToString());
            var responsemessage = streamTask.Content.ReadAsStringAsync().Result;
            dynamic author = JsonConvert.DeserializeObject(responsemessage);
            if (responsemessage is null)
            {
                return NotFound();
            }
            return Ok(responsemessage);
        }

        private async Task<HttpResponseMessage> getMockService(string endPoint)
        {
            var getData = await client.GetAsync(endPoint);
            return getData;
        }
        private HttpResponseMessage postMockService(string endPoint, string content)
        {
            var inputMessage = new HttpRequestMessage
            {
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            };

            inputMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage getData = client.PostAsync(endPoint, inputMessage.Content).Result;
            return getData;
        }
        private async Task<HttpResponseMessage> putMockService(string endPoint, string content)
        {
            var inputMessage = new HttpRequestMessage
            {
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            };

            inputMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PutAsync(endPoint, inputMessage.Content);

            return response;
        }
        private async Task<HttpResponseMessage> deleteMockService(string endPoint)
        {
            HttpResponseMessage response = await client.DeleteAsync(endPoint);
            return response;
        }


    }
}
