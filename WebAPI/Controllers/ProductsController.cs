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

        [HttpGet]
        public IActionResult Get()
        {
           
            var result=_productService.GetAll();
            if (result.success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.message);
            

        }
    }
}
