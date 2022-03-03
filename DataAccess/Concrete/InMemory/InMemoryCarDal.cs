using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
	public class InMemoryCarDal : ICarDal
	{
		List<Car> _cars;

		public InMemoryCarDal()
		{
			_cars = new List<Car>
			{
			new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2012,DailyPrice=475,Description="Renault"},
			new Car{Id=2,BrandId=2,ColorId=1,ModelYear=2014,DailyPrice=395,Description="Ford"},
			new Car{Id=3,BrandId=3,ColorId=2,ModelYear=2017,DailyPrice=505,Description="Toyota"},
			new Car{Id=4,BrandId=4,ColorId=2,ModelYear=2019,DailyPrice=895,Description="BMW"},
			new Car{Id=5,BrandId=5,ColorId=3,ModelYear=2020,DailyPrice=1000,Description="Mercedes Benz"},
			new Car{Id=6,BrandId=6,ColorId=4,ModelYear=2022,DailyPrice=1200,Description="Wolfswagen"},
			};
		}
		public void Add(Car car)
		{
			_cars.Add(car);
		}

		public void Delete(Car car)
		{
			Car CarToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
			_cars.Remove(car);
		}

		public Car Get(Expression<Func<Car, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public List<Car> GetAll()
		{
			return _cars;
		}

		public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public List<Car> GetById(int Id)
		{
			return _cars.Where(c => c.Id == Id).ToList();
		}

		public List<CarDetailDto> GetCarDetails()
		{
			throw new NotImplementedException();
		}

		public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public List<CarDetailDto> GetCarDetailsByBrandAndByColorId(int brandId, int colorId)
		{
			throw new NotImplementedException();
		}

		public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
		{
			throw new NotImplementedException();
		}

		public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
		{
			throw new NotImplementedException();
		}

		public void Update(Car car)
		{
			Car CarToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
			CarToUpdate.ModelYear = car.ModelYear;
			CarToUpdate.DailyPrice = car.DailyPrice;
			CarToUpdate.Description = car.Description;
			CarToUpdate.ColorId = car.ColorId;
			CarToUpdate.BrandId = car.BrandId;


		}
	}
}
