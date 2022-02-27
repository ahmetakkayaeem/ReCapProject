using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface IRentalService
	{
		IDataResult<List<Rental>> GetAll();

		IDataResult<Rental> GetById(int rentalId);

		IDataResult<List<Rental>> GetLastRentalByCarId(int carId);

		IDataResult<List<RentalDetailDto>> GetRentalDetails();

		IDataResult<List<RentalDetailDto>> GetRentalDetailsByCustomerId(int customerId);


		IResult Add(Rental rental);

		IResult Delete(Rental rental);

		IResult Update(Rental rental);
	}
}
