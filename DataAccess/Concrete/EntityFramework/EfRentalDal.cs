using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, NorthwindContext>, IRentalDal
    {
        public List<CarRentalDetailsDto> GetCarRentalDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from rnt in context.Rentals
                             join c in context.Cars
                             on rnt.CarId equals c.Id

                             join cs in context.Customers
                             on rnt.CustomerId equals cs.Id
                             
                             join u in context.Users
                             on cs.UserId equals u.UserId

                             select new CarRentalDetailsDto
                             {
                                 Id = rnt.Id,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 CarName = c.CarName,
                                 DailyPrice = c.DailyPrice,
                                 RentDate = rnt.RentDate,
                                 ReturnDate = rnt.ReturnDate
                                 
                             };
                return result.ToList();
            }
        }
    }
}
