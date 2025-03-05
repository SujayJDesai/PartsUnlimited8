using PartsUnlimited.Models;
using PartsUnlimited.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PartsUnlimited.Api
{
    [Route("api/raincheck")]
    [ApiController]
    public class RaincheckController : ControllerBase
    {
        private readonly IRaincheckQuery _query;

        public RaincheckController(IRaincheckQuery query)
        {
            _query = query;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public Task<IEnumerable<Raincheck>> Get()
        {
            return _query.GetAllAsync();
        }

        [HttpGet("{id}")]
        [ActionName("GetOne")]
        public Task<Raincheck> Get(int id)
        {
            return _query.FindAsync(id); 
        }

        [HttpPost]
        [ActionName("Save")]
        public Task<int> Post([FromBody]Raincheck raincheck)
        {
            return _query.AddAsync(raincheck);
        }
    }
}