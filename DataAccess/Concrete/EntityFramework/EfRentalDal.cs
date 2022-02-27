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
	public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
	{
		public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
		{
			using (CarRentalContext context = new CarRentalContext())
			{
				var result = from r in context.Rentals
							 join c in context.Cars
							 on r.CarId equals c.Id
							 join co in context.Colors
							 on c.ColorId equals co.ColorId
							 join b in context.Brands
							 on c.BrandId equals b.BrandId
							 join cu in context.Customers
							 on r.CustomerId equals cu.Id
							 join u in context.Users
							 on cu.UserId equals u.Id
							 select new RentalDetailDto
							 {
								 Id=r.Id,
								 BrandName=b.BrandName,
								 ModelYear=c.ModelYear,
								 DailyPrice=c.DailyPrice,
								 CarName=c.Description,
								 ColorName=co.ColorName,
								 FirstName=u.FirstName,
								 LastName=u.LastName,
								 CompanyName=cu.CompanyName,
								 RentDate=r.RentDate,
								 ReturnDate=r.ReturnDate,
								 CustomerId=cu.Id,
								 

							 };
				return filter == null ?result.ToList()
									  :result.Where(filter).ToList();

			}
		}

		
	}
}
