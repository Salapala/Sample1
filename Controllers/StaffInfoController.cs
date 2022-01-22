using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffInfoController : ControllerBase
    {
         //[HttpGet("StaffInfo")]
        ICRUDRepository<StaffInfo, int> _repository;
       
            public StaffInfoController(
                ICRUDRepository<StaffInfo, int> repository
            )  => _repository = repository;

            public ActionResult<IEnumerable<StaffInfo>> Get()
            {
                var items = _repository.GetAll();
                return items.ToList();
            }
              [HttpGet("{id}")]
            public ActionResult<StaffInfo> GetDetails(int id)
            {
                var item = _repository.GetDetails(id);
                if(item==null)
                  return NotFound();

                  return item;
            }
            [HttpPost("addnew")]
            public ActionResult<StaffInfo> Create(StaffInfo staff)
            {
                if(Staff == null)
                   return BadRequest();
                   _repository.Create(Staff);
                   return Staff;
            }
            [HttpPut("update/{id}")]
            public ActionResult<StaffInfo> update(int id, StaffInfo staff)
            {
                if(Staff == null)
                  return BadRequest();
            _repository.Update(Staff);
            return Staff;
            }

            [HttpDelete("remove/{id}")]
            public ActionResult Delete(int id)
            {
                _repository.Delete(id);
                return Ok();
            }
    }
}