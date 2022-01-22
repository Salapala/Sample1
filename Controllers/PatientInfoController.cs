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
    public class PatientInfoController : ControllerBase
    {
         //[HttpGet("PatientInfo")]
         ICRUDRepository<PatientInfo, int> _repository;
       
            public PatientInfoController(
                ICRUDRepository<PatientInfo, int> repository
            )  => _repository = repository;

            public ActionResult<IEnumerable<PatientInfo>> Get()
            {
                var items = _repository.GetAll();
                return items.ToList();
            }
              [HttpGet("{id}")]
            public ActionResult<PatientInfo> GetDetails(int id)
            {
                var item = _repository.GetDetails(id);
                if(item==null)
                  return NotFound();

                  return item;
            }
            [HttpPost("addnew")]
            public ActionResult<PatientInfo> Create(PatientInfo patient)
            {
                if(Patient==null)
                   return BadRequest();
                   _repository.Create(patient);
                   return Patient;
            }
            [HttpPut("update/{id}")]
            public ActionResult<PatientInfo> update(int id, PatientInfo patient)
            {
                if(Patient==null)
                  return BadRequest();
            _repository.Update(patient);
            return Patient;
            }

            [HttpDelete("remove/{id}")]
            public ActionResult Delete(int id)
            {
                _repository.Delete(id);
                return Ok();
            }
    }
}