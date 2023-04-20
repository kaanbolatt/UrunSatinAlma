using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using UrunSatinAlma.Context;
using UrunSatinAlma.Dtos;
using UrunSatinAlma.Service;

namespace UrunSatinAlma.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrunSatisController : ControllerBase
    {
        UrunSatisService _urunSatisService = new UrunSatisService();

        [HttpPost("CategoryAddOrUpdate")]
        public IActionResult CategoryAddOrUpdate([FromBody] CategoryRequestDto model)
        {
            var result = _urunSatisService.CategoryAddOrUpdate(model);
            return Ok(result);
        }

        [HttpPost("ProductAddOrUpdate")]
        public IActionResult ProductAddOrUpdate([FromBody] ProductRequestDto model)
        {
            var result = _urunSatisService.ProductAddOrUpdate(model);
            return Ok(result);
        }

        [HttpPost("BasketAdd")]
        public IActionResult BasketAdd([FromBody] BasketRequestDto model)
        {
            var result = _urunSatisService.BasketAdd(model);
            return Ok(result);
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserRequestDto model)
        {
            var result = _urunSatisService.Register(model);
            return Ok(result);
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts([FromQuery] ProductFilterDto model)
        {
            var result = _urunSatisService.GetAllProducts(model);
            return Ok(result);
        }
        
        [HttpGet("GetBasketList")]
        public IActionResult GetBasketList([FromQuery] long userId)
        {
            var result = _urunSatisService.GetBasketList(userId);
            return Ok(result);
        }

        [HttpGet("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            var result = _urunSatisService.GetAllCategories();
            return Ok(result);
        }

        [HttpGet("GetProductById")]
        public IActionResult GetProductById([FromQuery] long id)
        {
            var result = _urunSatisService.GetProductById(id);
            return Ok(result);
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequestDto model)
        {
            var result = _urunSatisService.Login(model);
            return Ok(result);
        }

        [HttpDelete("ProductDelete")]
        public IActionResult ProductDelete([FromQuery] long id)
        {
            var result = _urunSatisService.ProductDelete(id);
            return Ok(result);
        }

        [HttpDelete("CategoryDelete")]
        public IActionResult CategoryDelete([FromQuery] long id)
        {
            var result = _urunSatisService.CategoryDelete(id);
            return Ok(result);
        }

        [HttpDelete("BasketProductDelete")]
        public IActionResult BasketProductDelete([FromQuery] long id)
        {
            var result = _urunSatisService.BasketProductDelete(id);
            return Ok(result);
        }

        [HttpDelete("AllBasketProductDelete")]
        public IActionResult AllBasketProductDelete([FromQuery] long userId)
        {
            var result = _urunSatisService.AllBasketProductDelete(userId);
            return Ok(result);
        }


    }
}