using Prism.Commands;
using Realms;
using System;
using System.Diagnostics;

namespace ShopList.ViewModels
{
	public class ItemViewModel : RealmObject
	{
		[PrimaryKey]
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTimeOffset AddTime { get; set; } = DateTimeOffset.Now;
		public int ItemType { get; set; }
		//public ItemType ItemType { get; set; }
		[Ignored]
		public DelegateCommand TapToDeleteCommand => new DelegateCommand(Delete);

		public EventHandler<ItemViewModel> SendDelete;

		private void Delete()
		{
			SendDelete.Invoke(this, this);
			//TODO emit delete event
			Debug.WriteLine("delete item: " + Name);
		}

	}

	public enum ItemType
	{
		Groceries,
		Todos
	}
}
