using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface ICarService
	{	//Parametresiz olanları kendisiyle çağır.(GetAll(),GerCarDetailDtos())
		// Listeleme yapılmayacaksa kendi idsine göre yazılanlarda Get() yazılır.
		IDataResult<List<Car>> GetAll(); 

		IDataResult<List<Car>> GetCarsByBrandId(int id); 

		IDataResult<List<Car>> GetCarsByColorId(int id); 

		IDataResult<List<CarDetailDto>> GetCarDetails(); 

		IDataResult<Car> GetById(int carId); 

		IResult Add(Car car);

		IResult Delete(Car car);

		IResult Update(Car car);



	}
}
