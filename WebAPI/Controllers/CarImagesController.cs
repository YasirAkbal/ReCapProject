using BusinessLayer.Abstract;
using Core.Constants;
using Core.DTOs;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class CarImagesController : Controller
    {
        private ICarImageService _carImageService;
        private string ImageDir {get;}
        private const string _imageExtension = "jpg";

        public CarImagesController(ICarImageService carImageService)
        {
            ImageDir = Path.Combine(Environment.CurrentDirectory, "wwwroot//CarImages");
            _carImageService = carImageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("uploadimage")]
        public IActionResult UploadCarImage([FromForm(Name = "Image")] IFormFile file, [FromForm] CarImage carImage)
        {
            if (file == null)
            {
                return BadRequest(new ErrorResult(CoreMessages.fileIsEmpty));
            }

            var guid = WebApiFileHelper.NewGuid();
            var fileDto = new FileDto(ImageDir, guid, _imageExtension);
            var resultFromHelper = WebApiFileHelper.Add(file, fileDto);
            
            if(resultFromHelper.IsSuccess == false)
            {
                return BadRequest(resultFromHelper);
            }

            var resultFromCarImageService = _carImageService.Add(carImage, fileDto);

            if(resultFromCarImageService.IsSuccess)
            {
                return Ok(resultFromCarImageService);
            }

            return BadRequest(resultFromCarImageService);
        }


        [HttpPut("updateimage")]
        public IActionResult UpdateCarImage([FromForm(Name = "Image")] IFormFile file, [FromForm(Name = "CarImageId")] int carImageId)
        {
            if (file == null)
            {
                return BadRequest(new ErrorResult(CoreMessages.fileIsEmpty));
            }

            var resultForGetCarImageById = _carImageService.GetByCarImageId(carImageId);

            if (resultForGetCarImageById.IsSuccess == false)
            {
                return BadRequest(resultForGetCarImageById);
            }

            var fileDto = new FileDto(resultForGetCarImageById.Data.ImagePath);
            var resultFromHelper = WebApiFileHelper.Update(file, fileDto);

            if (resultFromHelper.IsSuccess == false)
            {
                return BadRequest(resultFromHelper);
            }

            var resultFromCarImageService = _carImageService.Update(resultForGetCarImageById.Data, fileDto);

            if (resultFromCarImageService.IsSuccess)
            {
                return Ok(resultFromCarImageService);
            }

            return BadRequest(resultFromCarImageService);
        }

        [HttpDelete("deleteimage")]
        public IActionResult DeleteCarImage([FromForm(Name = "CarImageId")] int carImageId)
        {
            var resultForGetCarImageById = _carImageService.GetByCarImageId(carImageId);

            if (resultForGetCarImageById.IsSuccess == false)
            {
                return BadRequest(resultForGetCarImageById);
            }

            var fileDto = new FileDto(resultForGetCarImageById.Data.ImagePath);
            var resultFromHelper = WebApiFileHelper.Delete(fileDto);

            if (resultFromHelper.IsSuccess == false)
            {
                return BadRequest(resultFromHelper);
            }

            var resultFromCarImageService = _carImageService.Delete(resultForGetCarImageById.Data);

            if (resultFromCarImageService.IsSuccess)
            {
                return Ok(resultFromCarImageService);
            }

            return BadRequest(resultFromCarImageService);
        }

        [HttpGet("getimagesbycarid")]
        public IActionResult GetAllImagesByCarId(int id)
        {
            var result = _carImageService.GetAllImagesByCarId(id);

            if(result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();

            if (result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
