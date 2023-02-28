using System.ComponentModel.DataAnnotations;

namespace Book_Store_Api.Models
{
	public class Payment
	{
		[Key]
		public int PaymentId { get; set; }
		[Required]
		public string PaymentMethod { get; set; }
		[Required]
		public decimal Amount { get; set; }
		public OrderDetail OrderDetail { get; set; }
	}
}
