using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class BrandManager : IBrandService
	{
		IBrandDal _brandlDal;

		public BrandManager(IBrandDal brandlDal)
		{
			_brandlDal = brandlDal;
		}

		[ValidationAspect(typeof(BrandValidator))]
		public IResult Add(Brand brand)
		{
			_brandlDal.Add(brand);
			return new SuccessResult(Messages.BrandAdded );
		}

		public IResult Delete(Brand brand)
		{
			_brandlDal.Delete(brand);
			return new SuccessResult(Messages.BrandDeleted);
		}

		public IDataResult<List<Brand>> GetAll()
		{
			if (DateTime.Now.Hour==14)
			{
				return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
			}
			return new SuccessDataResult<List<Brand>>( _brandlDal.GetAll());
		}

		public IDataResult<Brand> GetById(int brandId)
		{
			return new SuccessDataResult<Brand>( _brandlDal.Get(c => c.BrandId == brandId));
		}

		[ValidationAspect(typeof(BrandValidator))]
		public IResult Update(Brand brand)
		{
			_brandlDal.Update(brand);
			return new SuccessResult(Messages.BrandUpdated);
		}
	}
}
