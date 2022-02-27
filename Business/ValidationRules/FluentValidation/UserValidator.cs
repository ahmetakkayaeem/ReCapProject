using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
	public class UserValidator:AbstractValidator<User>
	{
		public UserValidator()
		{
			RuleFor(u => u.FirstName).MinimumLength(2);
			RuleFor(u => u.FirstName).MaximumLength(50);
			RuleFor(u => u.FirstName).NotNull();
			RuleFor(u => u.FirstName).NotEmpty().WithMessage("The FirstName field can not be passed blank!");

			RuleFor(u => u.LastName).MinimumLength(2);
			RuleFor(u => u.LastName).MaximumLength(50);
			RuleFor(u => u.LastName).NotNull();
			RuleFor(u => u.LastName).NotEmpty().WithMessage("The Surname field can not be passed blank!");

			RuleFor(u => u.Email).EmailAddress().When(u=>!string.IsNullOrEmpty(u.Email));
			RuleFor(u => u.Email).NotEmpty();
			RuleFor(u => u.Email).NotNull();

			RuleFor(u => u.Password).Must(IsPasswordValid).WithMessage("Your Password must contain at least eight characters,at least one letter and a number");


		}

		private bool IsPasswordValid(string arg)
		{
			Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
			return regex.IsMatch(arg);
		}
	}
}
