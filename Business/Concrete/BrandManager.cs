using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
	public class BrandManager : IBrandService
	{
		IBrandDal _brandDal;

		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}

		[ValidationAspect(typeof(BrandValidator))]
		public IResult Add(Brand brand)
		{
			IResult result = BusinessRules.Run(CheckIfBrandNameExists(brand.BrandName));
			if (result!=null)
			{
				return new ErrorResult();
			}
			_brandDal.Add(brand);
			return new SuccessResult(Messages.BrandAdded );
		}

		public IResult Delete(Brand brand)
		{
			IResult result = BusinessRules.Run(CheckBrandIdExists(brand.BrandId));
			if (result != null)
			{
				return new ErrorResult();
			}
			_brandDal.Delete(brand);
			return new SuccessResult(Messages.BrandDeleted);
		}

		public IDataResult<List<Brand>> GetAll()
		{
			if (DateTime.Now.Hour==14)
			{
				return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
			}
			return new SuccessDataResult<List<Brand>>( _brandDal.GetAll());
		}

		public IDataResult<Brand> GetById(int brandId)
		{
			IResult result = BusinessRules.Run(CheckBrandIdExists(brandId));
			if (result != null)
			{
				return new ErrorDataResult<Brand>();
			}
			return new SuccessDataResult<Brand>( _brandDal.Get(c => c.BrandId == brandId));
		}

		[ValidationAspect(typeof(BrandValidator))]
		public IResult Update(Brand brand)
		{
			IResult result = BusinessRules.Run(CheckIfBrandNameExists(brand.BrandName),
				CheckBrandIdExists(brand.BrandId));
			if (result != null)
			{
				return new ErrorResult();
			}
			_brandDal.Update(brand);
			return new SuccessResult(Messages.BrandUpdated);
		}

		private IResult CheckIfBrandNameExists(string brandName)
		{
			var result = _brandDal.GetAll(b => b.BrandName == brandName).Any();
			if (result)
			{
				return new ErrorResult(Messages.SameBrandNameError);
			}
			return new SuccessResult();
		}

		private IResult CheckBrandIdExists(int brandId)
		{
			var result = _brandDal.GetAll(b => b.BrandId == brandId).Any();
			if (!result)
			{
				return new ErrorResult(Messages.BrandNotFoundError);
			}
			return new SuccessResult();
		}
	}
}
