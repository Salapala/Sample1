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
    public class LabInfoController : ControllerBase
    {
        //[HttpGet("LabInfo")]
        ICRUDRepository<LabInfo, int> _repository;
       
            public LabInfoController(
                ICRUDRepository<LabInfo, int> repository
            )  => _repository = repository;

            public ActionResult<IEnumerable<LabInfo>> Get()
            {
                var items = _repository.GetAll();
                return items.ToList();
            }
              [HttpGet("{id}")]
            public ActionResult<LabInfo> GetDetails(int id)
            {
                var item = _repository.GetDetails(id);
                if(item==null)
                  return NotFound();

                  return item;
            }
            [HttpPost("addnew")]
            public ActionResult<LabInfo> Create(LabInfo Lab)
            {
                if(Lab == null)
                   return BadRequest();
                   _repository.Create(Lab);
                   return Lab;
            }
            [HttpPut("update/{id}")]
            public ActionResult<LabInfo> update(int id, LabInfo Lab)
            {
                if(Staff == null)
                  return BadRequest();
            _repository.Update(Lab);
            return Lab;
            }

            [HttpDelete("remove/{id}")]
            public ActionResult Delete(int id)
            {
                _repository.Delete(id);
                return Ok();
            }
    }
}