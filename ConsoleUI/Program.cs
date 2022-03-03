using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Linq;

using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{//KENDİ IDLERİ YAZMA İŞLEM YAPARKEN
		 //CarAddedTest();
		 //CarDeletedTest();
		 //CarUpdatedTest();
		 //CarGetCarDetailsTest();
		 //CarGetCarsByBrandIdTest();
		 //CarGetCarsByColorIdTest();
		 //CarGetByIdTest();
		 //CarGetAllTest();
		 //------------------------------COLOR-----------------------
		 //ColorAddedTest();
		 //ColorGetByIdTest();
		 //-----------------------------BRAND------------------------
		 //BrandAddedTest();
		 //-----------------------------USER-------------------------
		 //UserAddTest();
		 //UserGetAllTest();
		 //-----------------------------Customer-----------------------
		 //CustomerAddTest()
		 //CustomerGetCustomerByUserIdTest();
		 //CustomerGetByIdTest();
		 //CustomerGetCustomerDetailsTest();
		 //------------------------------Rental--------------------------
		 //RentalAddTest();
		 //RentalGetRentalDetailsByCustomerIdTest();
		 //RentalGetRentalDetailsTest();

		}

		private static void RentalGetRentalDetailsTest()
		{
			RentalManager rentalManager = new RentalManager(new EfRentalDal());
			var result = rentalManager.GetRentalDetails();
			if (result.Success)
			{
				foreach (var rental in result.Data)
				{
					Console.WriteLine(rental.FirstName + " " + rental.LastName + " adlı kişi " + rental.ModelYear + " model " + rental.ColorName + " renk " + rental.CarName
						+ " aracı günlüğü " + rental.DailyPrice + " fiyata kiraladı. ");
				}


			}
			else
			{
				Console.WriteLine(result.Message);
			}
		}

		private static void RentalGetRentalDetailsByCustomerIdTest()
		{
			RentalManager rentalManager = new RentalManager(new EfRentalDal());
			var result = rentalManager.GetRentalDetailsByCustomerId(45);
			if (result.Success)
			{
				foreach (var rental in result.Data)
				{
					Console.WriteLine(rental.FirstName + " " + rental.LastName + " adlı kişi " + rental.ModelYear + " model " + rental.ColorName + " renk " + rental.CarName
						+ " aracı günlüğü " + rental.DailyPrice + " fiyata kiraladı. ");
				}
				Console.WriteLine(result.Message);

			}
			else
			{
				Console.WriteLine(result.Message);
			}
		}

		private static void RentalAddTest()
		{
			RentalManager rentalManager = new RentalManager(new EfRentalDal());

			var result = rentalManager.Add(new Rental
			{
				CarId = 2005,
				CustomerId = 11,
				RentDate = new DateTime(2021, 12, 17),

			});

			if (result.Success)
			{
				Console.WriteLine(result.Message);
			}
			else
			{
				Console.WriteLine(result.Message);
			}
		}

		private static void CustomerGetCustomerDetailsTest()
		{
			CustomerManager customerManager = new CustomerManager(new EfCustomerDal(),new UserManager(new EfUserDal()));

			var result = customerManager.GetCustomerDetails();

			if (result.Success)
			{
				foreach (var customer in result.Data)
				{
					Console.WriteLine(customer.FirstName + " " + customer.LastName + " " + "=>" + " " + customer.CompanyName + " "
						+ "--" + customer.Email);
				}
				Console.WriteLine(result.Message);

			}
			else
			{
				Console.WriteLine(result.Message);
			}
		}

		private static void CustomerGetByIdTest()
		{
			CustomerManager customerManager = new CustomerManager(new EfCustomerDal(), new UserManager(new EfUserDal()));
			var result = customerManager.GetById(6);

			if (result.Success)
			{
				Console.WriteLine(result.Message);
			}
			else
			{
				Console.WriteLine(result.Message);
			}
		}

		private static void CustomerGetCustomerByUserIdTest()
		{
			CustomerManager customerManager = new CustomerManager(new EfCustomerDal(),new UserManager(new EfUserDal()));
			var result = customerManager.GetCustomerByUserId(20);
			if (result.Success)
			{
				foreach (var customer in result.Data)
				{
					Console.WriteLine(customer.CompanyName);
				}
				Console.WriteLine(result.Message);

			}
			else
			{
				Console.WriteLine(result.Message);
			}
		}

		private static void CustomerAddTest()
		{
			CustomerManager customerManager = new CustomerManager(new EfCustomerDal(), new UserManager(new EfUserDal()));
			customerManager.Add(new Customer
			{

				UserId = 2,
				CompanyName = "Güneş Sigorta"
			});

			foreach (var customer in customerManager.GetAll().Data)
			{
				Console.WriteLine(customer.CompanyName);
			}
		}

		private static void UserGetAllTest()
		{
			UserManager userManager = new UserManager(new EfUserDal());
			var result = userManager.GetAll();
			if (result.Success)
			{
				foreach (var user in result.Data)
				{
					Console.WriteLine(user.FirstName + " " + user.LastName + " " + user.Email);
				}
				//Console.WriteLine(result.Message);

			}
			else
			{
				Console.WriteLine(result.Message);
			}
		}

		private static void UserAddTest()
		{
			UserManager userManager = new UserManager(new EfUserDal());
			var result = userManager.Add(new User
			{
				Id = 5,
				FirstName = "aaaa",
				LastName="",
				Email = "ccc@gmail.comm",
				Password = "423324a"
			});
			if (result.Success)
			{
				Console.WriteLine(result.Message);
			}
			else
			{
				Console.WriteLine(result.Message);
			}
			
		}

		private static void BrandAddedTest()
		{
			BrandManager brandManager = new BrandManager(new EfBrandDal());
			brandManager.Add(new Brand { BrandName = "Citroen" });
			foreach (var brand in brandManager.GetAll().Data)
			{
				Console.WriteLine(brand.BrandName);
			}
		}

		private static void CarGetAllTest()
		{
			CarManager carManager = new CarManager(new EfCarDal(),new BrandManager(new EfBrandDal()));
			var result = carManager.GetAll();
			if (result.Success)
			{
				foreach (var car in result.Data)
				{
					Console.WriteLine(car.Description);
				}
			}
			else
			{
				Console.WriteLine(result.Message);
			}
			
		}

		private static void ColorGetByIdTest()
		{
			ColorManager colorManager = new ColorManager(new EfColorDal());

			var color = colorManager.GetById(1005).Data;
			Console.WriteLine(color.ColorName);
		}

		private static void ColorAddedTest()
		{
			ColorManager colorManager = new ColorManager(new EfColorDal());
			colorManager.Add(new Color { ColorName = "Apple Green" });

			foreach (var color in colorManager.GetAll().Data)
			{
				Console.WriteLine(color.ColorName);
			}
		}

		private static void CarGetByIdTest()
		{
			//Car tablosunun Id e göre sütunu getirir o yüzden foreach döngüsüne gerek yoktur.
			CarManager carManager = new CarManager(new EfCarDal(), new BrandManager(new EfBrandDal()));

			var car = carManager.GetById(2002).Data;

			Console.WriteLine(car.Description + "=" + car.ModelYear);
		}

		private static void CarGetCarsByColorIdTest()
		{
			CarManager carManager = new CarManager(new EfCarDal(), new BrandManager(new EfBrandDal()));
			var result = carManager.GetCarsByColorId(1);
			if (result.Success)
			{
				foreach (var car in result.Data)
				{
					Console.WriteLine(car.ModelYear);
				}
			}
			Console.WriteLine(result.Message);
			
		}

		private static void CarGetCarsByBrandIdTest()
		{
			CarManager carManager = new CarManager(new EfCarDal(), new BrandManager(new EfBrandDal()));
			var result = carManager.GetCarsByBrandId(1);
			foreach (var car in result.Data)
			{
				Console.WriteLine(car.Description);
			}
		}

		private static void CarGetCarDetailsTest()
		{
			CarManager carManager = new CarManager(new EfCarDal(), new BrandManager(new EfBrandDal()));

			foreach (var car in carManager.GetCarDetails().Data)
			{
				Console.WriteLine(car.BrandName + " = " + car.CarName);

			}
		}

		private static void CarUpdatedTest()
		{
			CarManager carManager = new CarManager(new EfCarDal(), new BrandManager(new EfBrandDal()));
			//güncelleme yaparken tablodaki Id gerekli 
			carManager.Update(new Car { 
				Id = 3011, 
				ColorId = 4, 
				BrandId = 11,
				ModelYear = 2018,
				DailyPrice = 800,
				Description = "Skoda Rapid" });

			foreach (var car in carManager.GetAll().Data)
			{
				Console.WriteLine(car.Description);
			}
		}

		private static void CarDeletedTest()
		{
			CarManager carManager = new CarManager(new EfCarDal(), new BrandManager(new EfBrandDal()));
			//silme yaparken tablodaki Id gerekli 

			carManager.Delete(new Car { 
				Id = 3012, 
				Description = "Aston Martin" });

			foreach (var car in carManager.GetAll().Data)
			{
				Console.WriteLine(car.Description);
			}
		}

		private static void CarAddedTest()
		{
			CarManager carManager = new CarManager(new EfCarDal(), new BrandManager(new EfBrandDal()));
			//ekleme yaparken ıd gerekli DEĞİL
			carManager.Add(new Car { 
				ColorId = 2,
				BrandId=10,
				ModelYear=2020,
				DailyPrice=800,
				Description="Aston Martin" });

			foreach (var car in carManager.GetAll().Data)
			{
				Console.WriteLine(car.Description);
			}
		}





	}
}
