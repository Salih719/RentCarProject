using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<CarDetailDto> GetCarDetail(int id);
        IResult AddCar(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);

        IResult AddTransactionalTest(Car car);
    }
}
