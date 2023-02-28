using Book_Store_Api.Models;
using Book_Store_Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Book_Store_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private readonly IBooksRepo Repositories = null;
		public BooksController(IBooksRepo repo)
		{
			Repositories=repo;
		}
		[HttpGet]
		public ActionResult<List<Books>> Get()
		{
			List<Books> books = Repositories.GetAllBooks();
			if(books.Count>0)
			{
				return books;
			}
			else
			{
				return NotFound();
			}
		}
		[Route("{id:int}")]
		[HttpGet]
		public ActionResult<Books> Get(int ISBN)
		{
			Books books = Repositories.GetBooksByISBN(ISBN);
			if(books != null)
			{
				return books;
			}
			else
			{
				return NotFound();
			}
		}
		[HttpPost]
		public string Post(Books books)
		{
			string Response = Repositories.AddnewBooks(books);
			return Response;
		}
		[HttpPut]
		public string Put(Books books)
		{
			string Response = Repositories.UpdateBooks(books);
			return Response;
		}
		[Route("{id:int}")]
		[HttpDelete]
		public string Delete(int ISBN)
		{
			string Response = Repositories.DeleteBooks(ISBN);
			return Response;
		}
	}
}
