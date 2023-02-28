﻿using Book_Store_Api.Models;
using Book_Store_Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Book_Store_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderDetailsController : ControllerBase
	{
		private readonly IOrderRepo Repositories = null;
		public OrderDetailsController(IOrderRepo repo)
		{
			Repositories= repo;
		}
		[HttpGet]
		public ActionResult<List<OrderDetail>> Get()
		{
			List<OrderDetail> orderdetails = Repositories.GetAllOrders();
			if(orderdetails.Count>0)
			{
				return orderdetails;
			}
			else
			{
				return NotFound();
			}
		}
		[Route("{id:int}")]
		[HttpGet]
		public ActionResult<OrderDetail> Get(int id)
		{
			OrderDetail orderdetails = Repositories.GetOrderById(id);
			if(orderdetails != null)
			{
				return orderdetails;
			}
			else
			{
				return NotFound();
			}
		}
		[HttpPost]
		public string Post(OrderDetail orderdetails)
		{
			string Response = Repositories.AddnewOrder(orderdetails);
			return Response;
		}
		[HttpPut]
		public string Put(OrderDetail orderdetails)
		{
			string Response = Repositories.UpdateOrder(orderdetails);
			return Response;
		}
		[Route("{id:int}")]
		[HttpDelete]
		public string Delete(int id)
		{
			string Response = Repositories.DeleteOrder(id);
			return Response;
		}
	}
}
