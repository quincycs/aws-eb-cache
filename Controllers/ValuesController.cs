using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IDatabase _database;
        private IDatabase GetDatabase() {
            if(_database != null) {
                return _database;
            }

            var options = new ConfigurationOptions()
            {
                SyncTimeout = 500000,
                EndPoints =
                {
                    { "xxxxx.itxxxxem.0001.useX.cache.amazonaws.com", 6379 }
                },
                AbortOnConnectFail = false
            };
            ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(options);
            _database = connection.GetDatabase();
            return _database;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            bool success = GetDatabase().StringSet("1", "hello world");

            if(!success){
                throw new Exception("unsuccessful redis key set");
            }

            return new string[] { "set", "hello world" };
        }

        // GET api/values/1
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            string val = GetDatabase().StringGet(id.ToString());
            if(val == null) {
                return "not set";
            }
            return val;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
