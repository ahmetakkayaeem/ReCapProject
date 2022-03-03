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
	public class ColorManager : IColorService
	{
		IColorDal _colorDal;

		public ColorManager(IColorDal colorDal)
		{
			_colorDal = colorDal;
		}

		[ValidationAspect(typeof(ColorValidator))]
		public IResult Add(Color color)
		{
			IResult result = BusinessRules.Run(CheckIfColorNameExists(color.ColorName));
			if (result!=null)
			{
				return new ErrorResult(Messages.ColorAddedError);
			}
			_colorDal.Add(color);
			return new SuccessResult(Messages.ColorAdded);
		}

		public IResult Delete(Color color)
		{
			_colorDal.Delete(color);
			return new SuccessResult(Messages.ColorDeleted);
		}

		public IDataResult<List<Color>> GetAll()
		{
			if (DateTime.Now.Hour == 14)
			{
				return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
			}
			return new SuccessDataResult<List<Color>>( _colorDal.GetAll());
		}

		public IDataResult<Color> GetById(int colorId)
		{
			return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId));
		}

		[ValidationAspect(typeof(ColorValidator))]
		public IResult Update(Color color)
		{
			_colorDal.Update(color);
			return new SuccessResult(Messages.ColorUpdated);
		}

		private IResult CheckIfColorNameExists(string colorName)
		{
			var result = _colorDal.GetAll(c=> c.ColorName==colorName).Any();
			if (result)
			{
				return new ErrorResult();
			}
			return new SuccessResult();
		}

	}

}
