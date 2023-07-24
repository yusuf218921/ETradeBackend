using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetList();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyname")]
        public IActionResult GetByName(string name)
        {
            var result = _productService.GetByName(name);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getdetail")]
        public IActionResult GetDetail()
        {
            var result = _productService.GetDetail();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbycategory")]
        public IActionResult GetByCategoryId(int id)
        {
            var result = _productService.GetListByCategory(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("updatestockamount")]
        public IActionResult UpdateStockAmount(Product product)
        {
            var result = _productService.UpdateStockAmount(product);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

    }
}
