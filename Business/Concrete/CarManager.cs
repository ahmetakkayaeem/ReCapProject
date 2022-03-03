using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal;
		IBrandService _brandService;

		public CarManager(ICarDal carDal, IBrandService brandService)
		{
			_carDal = carDal;
			_brandService = brandService;
			
		}

		[ValidationAspect(typeof(CarValidator))]
		public IResult Add(Car car)
		{
			IResult result = BusinessRules.Run(CheckIfBrandLimitExceeded());
			if (result!=null)
			{
				return result;
			}
			_carDal.Add(car);
			return new SuccessResult(Messages.CarAdded);
			
		}

		public IResult Delete(Car car)
		{
			IResult result = BusinessRules.Run(CheckIfCarIdExist(car.Id));
			if (result != null)
			{
				return result;
			}
			_carDal.Delete(car);
			return new SuccessResult(Messages.CarDeleted);

		}

		public IDataResult<List<Car>> GetAll()
		{
			if (DateTime.Now.Hour==14)
			{
				return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
			}
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
		}

		public IDataResult<Car> GetById(int carId)
		{
			return new SuccessDataResult<Car>( _carDal.Get(c => c.Id == carId));
		}

		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			
			return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetails());
		}

		public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandAndByColorId(int brandId, int colorId)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByBrandAndByColorId(brandId,colorId));
		}

		public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByBrandId(brandId));
		}

		public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByColorId(colorId));
		}

		public IDataResult<List<Car>> GetCarsByBrandId(int id)
		{	//her c için c'nin BrandId si parametre olarak gönderilen id ye eşitse filtrele.
			return new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.BrandId == id));
		}

		public IDataResult<List<Car>> GetCarsByColorId(int id)
		{
			return new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.ColorId == id));
		}

		[ValidationAspect(typeof(CarValidator))]
		public IResult Update(Car car)
		{
			IResult result = BusinessRules.Run(CheckIfCarIdExist(car.Id));
			if (result != null)
			{
				return result;
			}
			_carDal.Update(car);
			return new SuccessResult(Messages.CarUpdated);
		}

		private IResult CheckIfBrandLimitExceeded()
		{
			var result = _brandService.GetAll();
			if (result.Data.Count>30)
			{
				return new ErrorResult(Messages.BrandLimitExceededError);
			}
			return new SuccessResult();
		}

		private IResult CheckIfCarIdExist(int carId)
		{
			var result = _carDal.GetAll(c=>c.Id==carId);
			if (result!=null)
			{
				return new ErrorResult();
			}
			return new SuccessResult();
		}
		

	}
}

