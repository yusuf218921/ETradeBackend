using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderLinesController : ControllerBase
    {
        IOrderLineService _orderLineService;

        public OrderLinesController(IOrderLineService orderLineService)
        {
            _orderLineService = orderLineService;
        }

        [HttpPost("add")]
        public IActionResult Add(OrderLine orderLine)
        {
            var result = _orderLineService.Add(orderLine);
            if(result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(OrderLine orderLine)
        {
            var result = _orderLineService.Delete(orderLine);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(OrderLine orderLine)
        {
            var result = _orderLineService.Update(orderLine);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyorderid")]
        public IActionResult GetByOrderId(int id)
        {
            var result = _orderLineService.GetByOrderId(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _orderLineService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("getdetail")]
        public IActionResult GetDetail(int id)
        {
            var result = _orderLineService.GetOrderLineDetail(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("get")]
        public IActionResult Get()
        {
            var result = _orderLineService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

    }
}
