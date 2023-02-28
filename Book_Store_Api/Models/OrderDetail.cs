using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Book_Store_Api.Models
{
	public class OrderDetail
	{
		[Key]
		public string OrderId { get; set; }
		public DateTime OrderDate { get; set; }
		[Required]
		[DataType(DataType.DateTime)]
		public int Quantity { get; set; }
		[Required]
		public string Address { get; set; }
		[Required]
		[Display(Name ="Phone_no")]
		public long Phone { get; set; }
		public decimal TotalPrice { get; set; }
		public Registration Registration { get; set; }
		public Books Books { get; set; }
		public ICollection<Payment> Payments { get; set; } 
	}
}
