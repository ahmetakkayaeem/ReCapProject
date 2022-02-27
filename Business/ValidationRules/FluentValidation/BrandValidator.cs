using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
	public class BrandValidator:AbstractValidator<Brand>
	{
		public BrandValidator()
		{
			RuleFor(b=> b.BrandName).NotEmpty().WithMessage("BrandName can not be empty");
			RuleFor(b => b.BrandName).MinimumLength(2);
			RuleFor(b => b.BrandName).MaximumLength(50);
			RuleFor(b => b.BrandName).NotNull();


		}


	}
}
