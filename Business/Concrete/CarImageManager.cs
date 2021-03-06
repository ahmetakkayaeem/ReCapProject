using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class CarImageManager : ICarImageService
	{
		ICarImageDal _carImageDal;
		IFileHelper _fileHelper;

		public CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)
		{
			_carImageDal = carImageDal;
			_fileHelper = fileHelper;
		}
		[ValidationAspect(typeof(CarImageValidator))]
		[SecuredOperation("admin")]
		[CacheRemoveAspect("ICarImageService.Get")]
		[CacheRemoveAspect("ICarService.Get")]
		public IResult Add(IFormFile file, CarImage carImage)
		{
			IResult result = BusinessRules.Run(CheckIfCarImageLimitExceeded(carImage.CarId));
			if (result!=null)
			{
				return result;
			}
			carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
			carImage.Date = DateTime.Now;
			_carImageDal.Add(carImage);
			return new SuccessResult(Messages.CarImageAdded);
		}

		
		[SecuredOperation("admin")]
		[CacheRemoveAspect("ICarImageService.Get")]
		[CacheRemoveAspect("ICarService.Get")]
		public IResult Delete(CarImage carImage)
		{
			_fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
			_carImageDal.Delete(carImage);
			return new SuccessResult(Messages.CarImageDeleted);
		}

		[CacheAspect]
		[SecuredOperation("admin")]
		public IDataResult<List<CarImage>> GetAll()
		{
			return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
		}

		public IDataResult<List<CarImage>> GetByCarId(int carId)
		{
			var result = BusinessRules.Run(CheckIfCarImageExist(carId));
			if (result!=null)
			{
				return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
			}
			return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));

		}

		public IDataResult<CarImage>GetById(int imageId)
		{
			return new SuccessDataResult<CarImage>(_carImageDal.Get(i=>i.Id==imageId));
		}

		
		[ValidationAspect(typeof(CarImageValidator))]
		[SecuredOperation("admin")]
		[CacheRemoveAspect("ICarImageService.Get")]
		[CacheRemoveAspect("ICarService.Get")]
		public IResult Update(IFormFile file, CarImage carImage)
		{	
			IResult result = BusinessRules.Run(CheckIfCarImageLimitExceeded(carImage.CarId));
			if (result != null)
			{
				return result;
			}

			carImage.ImagePath = _fileHelper.Update(file,PathConstants.ImagesPath + carImage.ImagePath,PathConstants.ImagesPath);
			carImage.Date = DateTime.Now;
			_carImageDal.Update(carImage);
			return new SuccessResult(Messages.CarImageUpdated);
		}

		private IResult CheckIfCarImageLimitExceeded(int carId)
		{
			var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
			if (result>=5)
			{
				return new ErrorResult(Messages.CarImageLimitError);
			}
			return new SuccessResult();
		}

		private IResult CheckIfCarImageExist(int carId)
		{
			var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
			if (result>0)
			{
				return new SuccessResult();
			}
			return new ErrorResult();
		}

		private IDataResult<List<CarImage>> GetDefaultImage(int carId)
		{
			List<CarImage> carImage = new List<CarImage>();
			carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
			return new SuccessDataResult<List<CarImage>>(carImage);
		}

		
	}
}
