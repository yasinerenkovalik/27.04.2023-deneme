using Bussines.Abstract;
using Bussines.Concrete;
using DataAccess.Concrete.EntityFramwork;
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

        [HttpGet("getall")]
        public IActionResult Get()
        {
           
            var result=_productService.GetAll();

            if (result.success)
            {
                return Ok(result);
            }
                return BadRequest(result);
          
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {

            var result = _productService.GetById(id);

          
            
                return Ok(result);
            
            

        }



        [HttpPost("add")]
        public IActionResult Post(Product product)
        {

            var result = _productService.Add(product);

            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
