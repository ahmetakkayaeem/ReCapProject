﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
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

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		[ValidationAspect(typeof(CarValidator))]
		public IResult Add(Car car)
		{
			_carDal.Add(car);
			return new SuccessResult(Messages.CarAdded);
			
		}

		public IResult Delete(Car car)
		{
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
			_carDal.Update(car);
			return new SuccessResult(Messages.CarUpdated);
		}
	}
}

