using Business.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImagesService _carImageService;
        public CarImagesController(ICarImagesService carImagesService)
        {
            _carImageService = carImagesService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        public IActionResult Add(CarImages carImages)
        {
            var result = _carImageService.Add(carImages);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
