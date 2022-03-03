using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
	{
		public List<CarDetailDto> GetCarDetails()
			
		{
			using (CarRentalContext context=new CarRentalContext())
			{
				var result = from c in context.Cars
							 join b in context.Brands
							 on c.BrandId equals b.BrandId
							 join co in context.Colors
							 on c.ColorId equals co.ColorId
							 select new CarDetailDto
							 {
								 CarName = c.Description,
								 ColorName=co.ColorName,
								 BrandName=b.BrandName,
								 DailyPrice=c.DailyPrice,
								 ModelYear=c.ModelYear,
								 BrandId=b.BrandId,
								 ColorId=co.ColorId,
								 ImagePath=(from m in context.CarImages where m.CarId==c.Id select m.ImagePath).FirstOrDefault()
							 };
				return result.ToList();
			}
			 
		}

		public List<CarDetailDto> GetCarDetailsByBrandAndByColorId(int brandId, int colorId)
		{
			using (CarRentalContext context = new CarRentalContext())
			{
				var result = from c in context.Cars
							 join b in context.Brands
							 on c.BrandId equals b.BrandId
							 join co in context.Colors
							 on c.ColorId equals co.ColorId
							 where b.BrandId==brandId & co.ColorId==colorId
							 select new CarDetailDto
							 {
								 CarName = c.Description,
								 ColorName = co.ColorName,
								 BrandName = b.BrandName,
								 DailyPrice = c.DailyPrice,
								 ModelYear = c.ModelYear,
								 BrandId = b.BrandId,
								 ColorId = co.ColorId,
								 ImagePath = (from m in context.CarImages where m.CarId == c.Id select m.ImagePath).FirstOrDefault()
							 };
				return result.ToList();
			}
		}

		public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
		{
			using (CarRentalContext context = new CarRentalContext())
			{
				var result = from c in context.Cars
							 join b in context.Brands
							 on c.BrandId equals b.BrandId
							 join co in context.Colors
							 on c.ColorId equals co.ColorId
							 where b.BrandId == brandId 
							 select new CarDetailDto
							 {
								 CarName = c.Description,
								 ColorName = co.ColorName,
								 BrandName = b.BrandName,
								 DailyPrice = c.DailyPrice,
								 ModelYear = c.ModelYear,
								 BrandId = b.BrandId,
								 ColorId = co.ColorId,
								 ImagePath = (from m in context.CarImages where m.CarId == c.Id select m.ImagePath).FirstOrDefault()
							 };
				return result.ToList();
			}
		}

		public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
		{
			using (CarRentalContext context = new CarRentalContext())
			{
				var result = from c in context.Cars
							 join b in context.Brands
							 on c.BrandId equals b.BrandId
							 join co in context.Colors
							 on c.ColorId equals co.ColorId
							 where co.ColorId == colorId
							 select new CarDetailDto
							 {
								 CarName = c.Description,
								 ColorName = co.ColorName,
								 BrandName = b.BrandName,
								 DailyPrice = c.DailyPrice,
								 ModelYear = c.ModelYear,
								 BrandId = b.BrandId,
								 ColorId = co.ColorId,
								 ImagePath = (from m in context.CarImages where m.CarId == c.Id select m.ImagePath).FirstOrDefault()
							 };
				return result.ToList();
			}
		}
	}
}
