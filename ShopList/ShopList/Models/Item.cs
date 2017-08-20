using Realms;
using System;

namespace ShopList.Models
{
	public class Item : RealmObject
	{
		[PrimaryKey]
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTimeOffset AddTime { get; set; } = DateTimeOffset.Now;
		public int ItemType { get; set; }
		//public ItemType ItemType { get; set; }
	}

	public enum ItemType
	{
		Groceries,
		Todos
	}
}
