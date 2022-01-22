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
    public class DeparmentInfoController : ControllerBase
    {
        
        //[HttpGet("DepartmentInfo")]
        ICRUDRepository<DepartmentInfo, int> _repository;
       
            public DepartmentInfoController(
                ICRUDRepository<DepartmentInfo, int> repository
            )  => _repository = repository;

            public ActionResult<IEnumerable<LabInfo>> Get()
            {
                var items = _repository.GetAll();
                return items.ToList();
            }
              [HttpGet("{id}")]
            public ActionResult<DepartmentInfo> GetDetails(int id)
            {
                var item = _repository.GetDetails(id);
                if(item==null)
                  return NotFound();

                  return item;
            }
            [HttpPost("addnew")]
            public ActionResult<LabInfo> Create(DepartmentInfo dept)
            {
                if(dept == null)
                   return BadRequest();
                   _repository.Create(dept);
                   return dept;
            }
            [HttpPut("update/{id}")]
            public ActionResult<LabInfo> update(int id, DepartmentInfo dept)
            {
                if(dept == null)
                  return BadRequest();
            _repository.Update(dept);
            return dept;
            }

            [HttpDelete("remove/{id}")]
            public ActionResult Delete(int id)
            {
                _repository.Delete(id);
                return Ok();
            }
    }
}