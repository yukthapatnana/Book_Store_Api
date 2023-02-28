using Book_Store_Api.Models;
using System.Collections.Generic;

namespace Book_Store_Api.Repositories
{
	public interface IBooksRepo
	{
		List<Books> GetAllBooks();
		Books GetBooksByISBN(int ISBN);
		public string AddnewBooks(Books books);
		public string UpdateBooks(Books books);
		public string DeleteBooks(int ISBN);
	}
}
