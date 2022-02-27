using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class Rental:IEntity
	{
		public int Id { get; set; }

		public int CarId { get; set; }

		public int CustomerId { get; set; }

		public DateTime RentDate { get; set; } // ? işareti olunca NULL olur demek.Koyulmazsa Null/boş değer olmaz.Otomatik olarak 0001 olarak tarih döner.

		public DateTime? ReturnDate { get; set; }
	}
}
