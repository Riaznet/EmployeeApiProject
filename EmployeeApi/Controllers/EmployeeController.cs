using Microsoft.AspNetCore.Mvc;
using Service.IService.Employees;
using Service.ViewModel.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EmployeeVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EmployeeVM>>> Get()
        {
            try
            {
                var data = await _employeeService.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmployeeVM), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EmployeeVM>> Get(Guid id)
        {
            try
            {
                var data = await _employeeService.Get(id);
                if (data == null)
                    return NotFound();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Post([FromBody] EmployeeVM value)
        {
            try
            {
                var result = await _employeeService.Add(value);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Put([FromBody] EmployeeVM value)
        {
            try
            {
                var result = await _employeeService.Update(value);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var data = await _employeeService.Get(id);
                if (data == null)
                    return NotFound();
                var res = await _employeeService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }
    }
}
