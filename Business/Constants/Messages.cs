using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
	public static class Messages
	{
		public static string MaintenanceTime = "System in Maintenance";

		//Car Message
		public static string CarAdded = "Car Added";
		public static string CarDeleted = "Car Deleted";
		public static string CarUpdated = "Car Updated";
		public static string CarListed = "Car Listed";
		public static string CarNameInvalid = "Car Name must be at least two letters!";



		//Brand Message
		public static string BrandAdded = "Brand Added";
		public static string BrandDeleted = "Brand Deleted";
		public static string BrandUpdated = "Brand Updated";
		public static string BrandListed = "Brand Listed";



		//Color Message
		public static string ColorAdded = "Color Added";
		public static string ColorDeleted = "Color Deleted";
		public static string ColorUpdated = "Color Updated";
		public static string ColorListed = "Color Listed";


		//User Message
		public static string UserAdded = "User Added";
		public static string UserAddedError = "User Did Not Add";
		public static string UserDeleted = "User Deleted";
		public static string UserUpdated = "User Updated";
		public static string UserUpdatedError = "User Did Not Update";
		public static string UserListed = "User Listed";

		//Customer Message
		public static string CustomerAdded = "Customer Added";
		public static string CustomerAddedError = "Customer Did Not Add";
		public static string CustomerDeleted = "Customer Deleted";
		public static string CustomerUpdated = "Customer Updated";
		public static string CustomerUpdatedError = "Customer Did Not Update";
		public static string CustomerNameInvalid = "Customer Name is Invalid!";
		public static string CustomerListed = "Customer Listed";
		public static string CustomerListedError = "Customer Did Not List";
		public static string CustomerListedById = "Customer Listed By ID";
		public static string CustomerNotExist = "Customer Did Not Exist";
		

		//Rental Message
		public static string RentalAdded = "Rental Added";
		public static string RentalAddedError = "Rental Did Not Add";
		public static string RentalDeleted = "Rental Deleted";
		public static string RentalUpdated = "Rental Updated";
		public static string RentalNoRentaCar = "No Rent A Car";
		public static string GetRentalDetailListed = "Rental information listed details";
		public static string GetAllRentalListed = "Rentals Listed";
		public static string GetRentalNotListed = "Rentals Did not List By CarID";
		public static string GetRentalById = "Rent has been taken ";


		//CarImage Message
		public static string CarImageLimitError= "A car can have up to 5 images.";
		public static string CarImageAdded= "Car Image Added Successfully";
		public static string CarImageDeleted= "Car Image Deleted Successfully";
		public static string CarImageUpdated="Car Image Updated Successfully";
	}
}
