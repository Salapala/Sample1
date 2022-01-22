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
    public class BillsInfoController : ControllerBase
    {
         //[HttpGet("BillsInfo")]
         ICRUDRepository<BillsInfo, int> _repository;
       
            public BillsInfoController(
                ICRUDRepository<BillsInfo, int> repository
            )  => _repository = repository;

            public ActionResult<IEnumerable<BillsInfo>> Get()
            {
                var items = _repository.GetAll();
                return items.ToList();
            }
              [HttpGet("{id}")]
            public ActionResult<BillsInfo> GetDetails(int id)
            {
                var item = _repository.GetDetails(id);
                if(item==null)
                  return NotFound();

                  return item;
            }
            [HttpPost("addnew")]
            public ActionResult<BillsInfo> Create(BillsInfo bill)
            {
                if(bill==null)
                   return BadRequest();
                   _repository.Create(bill);
                   return bill;
            }
            [HttpPut("update/{id}")]
            public ActionResult<BillsInfo> update(int id, BillsInfo bill)
            {
                if(bill==null)
                  return BadRequest();
            _repository.Update(bill);
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