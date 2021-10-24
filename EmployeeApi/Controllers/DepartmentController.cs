using Microsoft.AspNetCore.Mvc;
using Service.IService.Department;
using Service.ViewModel.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            this._departmentService = departmentService;
        }
        // GET: api/<DepartmentController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DepartmentVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<DepartmentVM>>> Get()
        {
            try
            {
                var data = await _departmentService.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DepartmentVM), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<DepartmentVM>> Get(Guid id)
        {
            try
            {
                var data = await _departmentService.Get(id);
                if (data == null)
                    return NotFound();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        // POST api/<DepartmentController>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Post([FromBody] DepartmentVM value)
        {
            try
            {
                var result = await _departmentService.Add(value);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        // PUT api/<DepartmentController>/5
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Put([FromBody] DepartmentVM value)
        {
            try
            {
                var result = await _departmentService.Update(value);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var data = await _departmentService.Get(id);
                if (data == null)
                    return NotFound();
                var res = await _departmentService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }
    }
}