using Prism.Commands;
using ShopList.Models;
using System;
using System.Collections.ObjectModel;

namespace ShopList.ViewModels
{
	public class TodoPageViewModel : TabChildViewModelBase
	{
		private readonly ObservableCollection<Item> _todos = new ObservableCollection<Item>()
		{
			new Item{Name = "T first item", AddTime = DateTime.Now, ItemType = ItemType.Groceries},
			new Item{Name = "T second item", AddTime = DateTime.Now, ItemType = ItemType.Groceries},
			new Item{Name = "T third item", AddTime = DateTime.Now, ItemType = ItemType.Groceries}
		};

		public TodoPageViewModel() : base()
		{
			Title = "Todo";
			ItemList = _todos;
			SubmitItemCommand = new DelegateCommand(AddNewItem);
			//ItemList = databaseService.GetShopList(ItemType.Todos);
		}

		public void AddNewItem()
		{
			_todos.Insert(0, new Item() { Name = NewItem });
			NewItem = "";
		}

	}
}
