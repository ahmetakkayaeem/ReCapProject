using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class CustomerManager : ICustomerService
	{
		ICustomerDal _customerDal;

		public CustomerManager(ICustomerDal customerDal)
		{
			_customerDal = customerDal;
		}

		[ValidationAspect(typeof(CustomerValidator))]
		public IResult Add(Customer customer)
		{
			_customerDal.Add(customer);
			return new SuccessResult(Messages.CustomerAdded);
		}

		public IResult Delete(Customer customer)
		{
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
			_customerDal.Update(customer);
			return new SuccessResult(Messages.CustomerUpdated);
		}
	}
}
