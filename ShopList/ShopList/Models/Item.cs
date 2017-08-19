using System;

namespace ShopList.Models
{
	public class Item
	{
		public string Name { get; set; }
		public DateTime AddTime { get; set; }
		public ItemType ItemType { get; set; }
	}

	public enum ItemType
	{
		Groceries,
		Todos
	}
}
