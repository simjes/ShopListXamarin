using Prism.Commands;
using Realms;
using System;
using System.Diagnostics;

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
		[Ignored]
		public DelegateCommand SwipeLeftCommand => new DelegateCommand(SwipeLeft);

		private void SwipeLeft()
		{
			Debug.WriteLine("swipe left");
		}

	}

	public enum ItemType
	{
		Groceries,
		Todos
	}
}
