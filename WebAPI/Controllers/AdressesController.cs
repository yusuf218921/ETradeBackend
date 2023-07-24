using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        IAdressService _adressService;

        public AdressesController(IAdressService adressService)
        {
            _adressService = adressService;
        }
        [HttpPost("add")]
        public IActionResult Add(Adress adress) 
        {
            var result = _adressService.Add(adress);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Adress adress)
        {
            var result = _adressService.Update(adress);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Adress adress)
        {
            var result = _adressService.Delete(adress);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getdetail")]
        public IActionResult GetDetail(int userId)
        {
            var result = _adressService.GetDetail(userId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        
    }
}
