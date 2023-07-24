using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelNumbersController : ControllerBase
    {
        ITelNumberService _telNumberService;

        public TelNumbersController(ITelNumberService telNumberService)
        {
            _telNumberService = telNumberService;
        }

        [HttpPost("add")]
        public IActionResult Add(TelNumber telNumber)
        {
            var result = _telNumberService.Add(telNumber);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(TelNumber telNumber)
        {
            var result = _telNumberService.Update(telNumber);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(TelNumber telNumber)
        {
            var result = _telNumberService.Delete(telNumber);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _telNumberService.GetByUserId(userId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }


    }
}
