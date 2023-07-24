using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TownsController : ControllerBase
    {
        ITownService _townService;

        public TownsController(ITownService townService)
        {
            _townService = townService;
        }

        [HttpPost("add")]
        public IActionResult Add(Town town)
        {
            var result = _townService.Add(town);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Town town)
        {
            var result = _townService.Delete(town);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Town town)
        {
            var result = _townService.Update(town);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _townService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyname")]
        public IActionResult GetByName(string name)
        {
            var result = _townService.GetByName(name);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _townService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
