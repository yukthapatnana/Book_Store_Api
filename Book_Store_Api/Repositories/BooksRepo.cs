using Book_Store_Api.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Book_Store_Api.Repositories
{
	public class BooksRepo : IBooksRepo
	{
		private MyDbContext context;
		public BooksRepo(MyDbContext _context)
		{
			context = _context;
		}
		public List<Books> GetAllBooks()
		{
			return context.Bookss.ToList();
		}
		public Books GetBooksByISBN(int ISBN)
		{
			Books books = context.Bookss.Find(ISBN);
			return books;
		}
		public string AddnewBooks(Books books)
		{
			int count = context.Bookss.Count();
			context.Bookss.Add(books);
			context.SaveChanges();
			int newcount = context.Bookss.Count();
			if(newcount>count)
			{
				return "Books added Successfully";
			}
			else
			{
				return "Something went wrong while adding books";
			}
		}
		public string UpdateBooks(Books books)
		{
			Books updatebooks = context.Bookss.Find(books.ISBN);
			if(updatebooks != null)
			{
				updatebooks.Title = books.Title;
				updatebooks.Price = books.Price;
				context.Bookss.Update(updatebooks);
				context.SaveChanges();
				return "Books information is updated";
			}
			else
			{
				return "Books information is not available";
			}
		}

		public string DeleteBooks(int ISBN)
		{
			Books books = context.Bookss.Find(ISBN);
			if(books != null)
			{
				context.Bookss.Remove(books);
				context.SaveChanges();
				return "Book information is removed from Database";
			}
			else
			{
				return "Book information is not removed from database";
			}
		}
	}
}
