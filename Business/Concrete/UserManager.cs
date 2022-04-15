using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
	public class UserManager : IUserService
	{
		IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		[ValidationAspect(typeof(UserValidator))]
		public IResult Add(User user)
		{
			IResult result = BusinessRules.Run(CheckIfEmailExist(user.Email));
			if (result!=null)
			{
				return result;
			}
			_userDal.Add(user);
			return new SuccessResult(Messages.UserAdded);
		}

		public IResult Delete(User user)
		{
			IResult result = BusinessRules.Run(CheckIfUserIdExists(user.Id));
			if (result != null)
			{
				return result;
			}
			_userDal.Delete(user);
			return new SuccessResult(Messages.UserDeleted);
		}

		[CacheAspect]
		public IDataResult<List<User>> GetAll()
		{
			return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
		}

		[CacheAspect]
		public IDataResult<List<OperationClaim>> GetClaims(User user)
		{
			return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
		}

		public IDataResult<User> GetById(int userId)
		{
			return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
		}


		public User GetByEmail(string email)
		{
			return _userDal.Get(u => u.Email == email);
		}

		[ValidationAspect(typeof(UserValidator))]
		public IResult Update(User user)
		{
			IResult result = BusinessRules.Run(CheckIfUserIdExists(user.Id),
				CheckIfEmailAvailableExist(user.Email));
			if (result!=null)
			{
				return result;
			}
			_userDal.Update(user);
			return new SuccessResult(Messages.UserUpdated);
		}

		private IResult CheckIfUserIdExists(int userId)
		{
			var result = _userDal.GetAll(u => u.Id == userId).Any();
			if (!result)
			{
				return new ErrorResult(Messages.UserNotExistError);
			}
			return new SuccessResult();
		}

		private IResult CheckIfEmailExist(string userEmail)
		{
			var result = BaseCheckIfEmailExist(userEmail);
			if (result)
			{
				return new ErrorResult(Messages.UserEmailExist);
			}
			return new SuccessResult();
		}

		private IResult CheckIfEmailAvailableExist(string userEmail)
		{
			var result = BaseCheckIfEmailExist(userEmail);
			if (!result)
			{
				return new ErrorResult(Messages.UserEmailNotAvailable);
			}
			return new SuccessResult();
		}

		private bool BaseCheckIfEmailExist(string userEmail)
		{
			return _userDal.GetAll(u => u.Email == userEmail).Any();
		}

		
	}
}
