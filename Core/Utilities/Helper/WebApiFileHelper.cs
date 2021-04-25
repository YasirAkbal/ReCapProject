using Core.Constants;
using Core.DTOs;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helper
{
    public static class WebApiFileHelper
    {
        public static IResult Add(IFormFile formFile, FileDto fileDto)
        {
            try
            {
                using (var fileStream = new FileStream(fileDto.FullPath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }
                return new SuccessResult();
            }
            catch
            {
                return new ErrorResult(CoreMessages.fileAddError);
            }     
        }

        public static IResult Update(IFormFile formFile, FileDto fileDto)
        {
            var resultForDeleteImage = Delete(fileDto);

            if(resultForDeleteImage.IsSuccess == false)
            {
                return resultForDeleteImage;
            }

            var resultForAddImage = Add(formFile, fileDto);

            if (resultForAddImage.IsSuccess == false)
            {
                return resultForAddImage;
            }

            return new SuccessResult();
        }

        public static IResult Delete(FileDto fileDto)
        {
            try
            {
                File.Delete(fileDto.FullPath);
                return new SuccessResult();
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                return new ErrorResult(CoreMessages.fileNotFound);
            }
        }

        public static string NewGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
