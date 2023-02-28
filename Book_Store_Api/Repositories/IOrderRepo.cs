using Book_Store_Api.Models;
using System.Collections.Generic;

namespace Book_Store_Api.Repositories
{
	public interface IOrderRepo
	{
		List<OrderDetail> GetAllOrders();
		OrderDetail GetOrderById(int id);
		public string AddnewOrder(OrderDetail orderdetail);
		public string UpdateOrder(OrderDetail orderdetail);
		public string DeleteOrder(int id);
	}
}
