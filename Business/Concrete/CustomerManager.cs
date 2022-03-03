using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
	public class CustomerManager : ICustomerService
	{
		ICustomerDal _customerDal;
		IUserService _userService;

		public CustomerManager(ICustomerDal customerDal,IUserService userService)
		{
			_customerDal = customerDal;
			_userService = userService;
		}

		[ValidationAspect(typeof(CustomerValidator))]
		public IResult Add(Customer customer)
		{
			IResult result = BusinessRules.Run(CheckIfUserIdValid(customer.UserId), CheckIfUserIdExist(customer.UserId));
			if (result!=null)
			{
				return result;
			}
			_customerDal.Add(customer);
			return new SuccessResult(Messages.CustomerAdded);
		}

		public IResult Delete(Customer customer)
		{
			IResult result = BusinessRules.Run(CheckIfUserIdExist(customer.UserId));
			if (result!=null)
			{
				return result;
			}
			_customerDal.Delete(customer);
			return new SuccessResult(Messages.CustomerDeleted);
		}

		public IDataResult<List<Customer>> GetAll()
		{
			return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomerListed);
		}

		public IDataResult<Customer> GetById(int customerId)
		{
			Customer customer = _customerDal.Get(c => c.Id == customerId);
			if (customer!=null)
			{
				return new SuccessDataResult<Customer>(customer,Messages.CustomerListedById);
			}
			
			return new ErrorDataResult<Customer>(Messages.CustomerNotExist);
		}

		public IDataResult<List<Customer>> GetCustomerByUserId(int userId)
		{
			List<Customer> customers = _customerDal.GetAll(c => c.UserId == userId);
			if (customers.Count <= 0)
			{
				return new ErrorDataResult<List<Customer>>(Messages.CustomerNotExist);
			}
			return new SuccessDataResult<List<Customer>>(customers, Messages.CustomerListed);
		}

		public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
		{
			List<CustomerDetailDto> customers = _customerDal.GetCustomerDetails();
			if (customers.Count<=0)
			{
				return new ErrorDataResult<List<CustomerDetailDto>>();

			}
			return new SuccessDataResult<List<CustomerDetailDto>>(customers, Messages.CustomerListed);
		}

		[ValidationAspect(typeof(CustomerValidator))]
		public IResult Update(Customer customer)
		{
			IResult result = BusinessRules.Run(CheckIfUserIdExist(customer.UserId));
			if (result!=null)
			{
				return result;
			}

			_customerDal.Update(customer);
			return new SuccessResult(Messages.CustomerUpdated);
		}

		private IResult CheckIfCustomerIdExist(int customerId)
		{
			var result = _customerDal.GetAll(c => c.Id == customerId).Any();
			if (!result)
			{
				return new ErrorResult(Messages.CustomerNotExist);
			}
			return new SuccessResult();
		}

		private IResult CheckIfUserIdExist(int userId)
		{
			var result = _customerDal.GetAll(u => u.UserId == userId).Any();
			if (!result)
			{
				return new ErrorResult(Messages.CustomerAlreadyRegister);
			}
			return new SuccessResult();
		}
		private IResult CheckIfUserIdValid(int userId)
		{
			var result = _userService.GetById(userId);
			if (!result.Success)
			{
				return new ErrorResult(Messages.UserNotExistError);
			}
			return new SuccessResult();
		}


	}
}
