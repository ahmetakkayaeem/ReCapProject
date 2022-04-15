using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class RentalManager : IRentalService
	{
		IRentalDal _rentalDal;
		
		public RentalManager(IRentalDal rentalDal)
		{
			_rentalDal = rentalDal;
			
		}

		[ValidationAspect(typeof(RentalValidator))]
		[CacheRemoveAspect("IRentalService.Get")]
		[SecuredOperation("admin")]
		public IResult Add(Rental rental)
		{
			IResult result = BusinessRules.Run(CheckIfReturnDateNull(rental.CarId));
			if (result!=null)
			{
				return result;
			}
			_rentalDal.Add(rental);
			return new SuccessResult(Messages.RentalAdded);
		}

		[CacheRemoveAspect("IRentalService.Get")]
		[SecuredOperation("admin")]
		public IResult Delete(Rental rental)
		{
			_rentalDal.Delete(rental);
			return new SuccessResult(Messages.RentalDeleted);
		}

		[CacheAspect]
		public IDataResult<List<Rental>> GetAll()
		{
			return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.GetAllRentalListed);
		}

		public IDataResult<Rental> GetById(int rentalId)
		{
			return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.Id==rentalId), Messages.GetRentalById);
		}

		public IDataResult<List<Rental>> GetLastRentalByCarId(int carId)
		{
			List<Rental> rentals = _rentalDal.GetAll(c=>c.CarId==carId);
			if (rentals.Count<=0)
			{
				return new ErrorDataResult<List<Rental>>(Messages.GetRentalNotListed);
			}
			return new SuccessDataResult<List<Rental>>(rentals,Messages.GetAllRentalListed);
		}

		[SecuredOperation("admin")]
		[CacheAspect]
		public IDataResult<List<RentalDetailDto>> GetRentalDetails()
		{
			return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.GetRentalDetailListed);
		}

		[SecuredOperation("admin")]
		[CacheAspect]
		public IDataResult<List<RentalDetailDto>> GetRentalDetailsByCustomerId(int customerId)
		{
			List<RentalDetailDto> rentals = _rentalDal.GetRentalDetails(c => c.CustomerId == customerId);
			if (rentals.Count<=0)
			{
				return new ErrorDataResult<List<RentalDetailDto>>(Messages.RentalNoRentaCar);
			}

			return new SuccessDataResult<List<RentalDetailDto>>(rentals,Messages.GetRentalDetailListed);

		}

		[ValidationAspect(typeof(RentalValidator))]
		[CacheRemoveAspect("IRentalService.Get")]
		[SecuredOperation("admin")]
		public IResult Update(Rental rental)
		{
			_rentalDal.Update(rental);
			return new SuccessResult(Messages.RentalUpdated);
		}

		private IResult CheckIfReturnDateNull(int carId)
		{
			var result = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null);
			if (result.Count > 0)
			{
				return new ErrorResult(Messages.RentalAddedError);
			}
			return new SuccessResult();
		}
	}
}
