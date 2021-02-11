using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockServiceApi.Dtos;
using MockServiceApi.Models;
using MockServiceApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace MockServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestClientController : ControllerBase
    {
        private readonly IRestClientRepository _repository;
        private static readonly HttpClient client = new HttpClient();

        public RestClientController(IRestClientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<RestClient>> GetItemsAsync()
        {
            var items = (await _repository.GetItemsAsync());
                   // .Select(item => item as RestClientDto);
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestClient>> GetItemAsync(Guid id)
        {
            var item = await _repository.GetItemAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            return item;//.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<RestClient>> CreateItemAsync(RestClientDto itemDto)
        {
            RestClient item = new RestClient()
            {
                Id = Guid.NewGuid(),
                EndPoint = itemDto.EndPoint,
                HttpMethod = (HttpVerb)itemDto.HttpMethod
            };

            await _repository.CreateItemAsync(item);

            return Ok(item);//CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }); //item.AsDto());
        }

    }
}
