using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;  
        public ValuesController(DataContext dataContext)
        {
            _context = dataContext;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            // throw new Exception("Test Exception");
            // return new string[] { "value1", "value2","value3", "value4" };

            //sync version
            // var values = _context.Values.ToList();

            //async version
            var values = await _context.Values.ToListAsync();
            return Ok(values);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            // return "value";
            //sync version
            // var value = _context.Values.FirstOrDefault(p => p.Id == id);
            
            //async version
            var value = await _context.Values.FirstOrDefaultAsync(p => p.Id == id);
            return Ok(value);
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
