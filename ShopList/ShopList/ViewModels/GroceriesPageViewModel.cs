using Prism.Commands;
using ShopList.Models;
using System;
using System.Collections.ObjectModel;

namespace ShopList.ViewModels
{
	public class GroceriesPageViewModel : TabChildViewModelBase
	{

		private readonly ObservableCollection<Item> _groceries = new ObservableCollection<Item>()
		{
			new Item{Name = "G first item", AddTime = DateTime.Now, ItemType = ItemType.Groceries},
			new Item{Name = "G second item", AddTime = DateTime.Now, ItemType = ItemType.Groceries},
			new Item{Name = "G third item", AddTime = DateTime.Now, ItemType = ItemType.Groceries}
		};

		public GroceriesPageViewModel() : base()
		{
			Title = "Groceries";
			ItemList = _groceries;
			SubmitItemCommand = new DelegateCommand(AddNewItem);
			//ItemList = databaseService.GetShopList(ItemType.Groceries);
		}

		public void AddNewItem()
		{
			_groceries.Insert(0, new Item() { Name = NewItem });
			NewItem = "";
		}
	}
}
