using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleWebApi.Core.Model;
using SimpleWebApi.Core.Interfaces;

namespace SimpleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonarController : ControllerBase
    {
        private readonly IDonarRepository donarRepo;
        public DonarController(IDonarRepository donarRepo)
        {
            this.donarRepo = donarRepo;
        }

        [HttpGet]
        public IActionResult GetDonars()
        {
            return Ok(donarRepo.Donars);
        }

        [HttpPost]
        [Route("Search")]
        public IActionResult GetAvailDonars([FromBody]BloodModel model)
        {
            return Ok(donarRepo.GetDonarsByBlood(model.Blood));
        }

        [HttpGet("{id}")]
        public IActionResult GetDonar(int id)
        {
            return Ok(donarRepo.GetDonar(id));
        }

        [HttpPost]
        public IActionResult PostDonar([FromBody]DonarModel model)
        {
            if (model == null) return StatusCode(StatusCodes.Status204NoContent);
            try
            {
                //if(id)
                var result = donarRepo.AddOrEdit(model);
                return Ok(new { StatusCode = result});
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        //public IActionResult SetLastDonation(int donarId, DateTime lastDate)
        //{
        //    return Ok();
        //}

        //public IActionResult SetLocation(int donarId, string area)
        //{
        //    return Ok();
        //}

        [HttpDelete("{donarId}")]
        public IActionResult DeleteDonar(int donarId)
        {
            try
            {
                //if(id)
                var result = donarRepo.Delete(donarId);
                return Ok(new { StatusCode = result });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
