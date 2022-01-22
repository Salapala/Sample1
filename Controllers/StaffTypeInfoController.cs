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
    public class StaffTypeInfoController : ControllerBase
    {
         //[HttpGet("StaffTypeInfo")]
         ICRUDRepository<StaffTypeInfo, int> _repository;
       
            public StaffTypeInfoController(
                ICRUDRepository<StaffTypeInfo, int> repository
            )  => _repository = repository;

            public ActionResult<IEnumerable<StaffTypeInfo>> Get()
            {
                var items = _repository.GetAll();
                return items.ToList();
            }
              [HttpGet("{id}")]
            public ActionResult<StaffTypeInfo> GetDetails(int id)
            {
                var item = _repository.GetDetails(id);
                if(item==null)
                  return NotFound();

                  return item;
            }
            [HttpPost("addnew")]
            public ActionResult<StaffTypeInfo> Create(StaffTypeInfo stype)
            {
                if(stype==null)
                   return BadRequest();
                   _repository.Create(stype);
                   return stype;
            }
            [HttpPut("update/{id}")]
            public ActionResult<StaffTypeInfo> update(int id, StaffTypeInfo stype)
            {
                if(stype==null)
                  return BadRequest();
            _repository.Update(stype);
            return bill;
            }

            [HttpDelete("remove/{id}")]
            public ActionResult Delete(int id)
            {
                _repository.Delete(id);
                return Ok();
            }
    }
}