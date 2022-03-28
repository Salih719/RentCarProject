using Core.Utilities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file,CarImage image);
        IResult Delete(CarImage image);
        IResult Update(IFormFile file,CarImage image);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImage>> GetCarImageByCarId(int carId);
    }
}
