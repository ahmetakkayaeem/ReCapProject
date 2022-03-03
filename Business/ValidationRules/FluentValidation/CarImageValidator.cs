using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
	public class CarImageValidator : AbstractValidator<CarImage>
	{
		public CarImageValidator()
		{
			RuleFor(c => c.CarId).NotNull().WithMessage("CarId can not be empty");
			RuleFor(c => c.CarId).GreaterThan(0).WithMessage("Please enter a value greater than zero");

		}
	}
}
