using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
    public class EfCarDal : EfEntityRepositoryBase<Car, NorthwindContext>, ICarDal
    {
        public CarDetailDto GetCarDetail(Expression<Func<CarDetailDto, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join x in context.Colors
                             on c.ColorId equals x.ColorId
                             join ci in context.CarImages
                             on c.Id equals ci.CarId

                             join re in context.Rentals
                             on c.IsAvailable equals re.Status
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 ColorId = x.ColorId,
                                 BrandId = b.BrandId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = x.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = (from i in context.CarImages where i.CarId == c.Id select i.ImagePath).ToList(),
                                 IsRentable = re.Status
                             };
                return result.FirstOrDefault(filter);

                // FirstOrDefault un içerisine filter ı koyunca düzeldi. bişey olursa dönüp buraya bakarsın (GetById(CarDetailDto))
            }
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from c in  context.Cars 
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join x in context.Colors
                             on c.ColorId equals x.ColorId
                             join ci in context.CarImages
                             on c.Id equals ci.CarId
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 ColorId = x.ColorId ,
                                 BrandId = b.BrandId ,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = x.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = (from i in context.CarImages where i.CarId == c.Id select i.ImagePath).ToList(),
                                 IsRentable = !context.Rentals.Any(r => r.Id == c.Id) || !context.Rentals.Any(r => r.Id == c.Id && (r.ReturnDate == null || (r.ReturnDate.HasValue && r.ReturnDate > DateTime.Now)))
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();

            }
        }

    }
}
