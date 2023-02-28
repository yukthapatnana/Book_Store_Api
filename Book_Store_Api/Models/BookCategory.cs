using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Book_Store_Api.Models
{
	public class BookCategory
	{
		[Key]
		public int CategoryId { get; set; }
		[Required]
		public string Category { get; set; }
		public ICollection<Books> Bookss { get; set; }
	}
}
