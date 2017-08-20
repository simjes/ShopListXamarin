﻿using Prism.Commands;
using ShopList.Models;
using ShopList.Services;

namespace ShopList.ViewModels
{
	public class GroceriesPageViewModel : TabChildViewModelBase
	{
		public GroceriesPageViewModel(IDatabaseService databaseService) : base(databaseService)
		{
			_databaseService = databaseService;
			ItemList = _databaseService.GetShopList((int)ItemType.Groceries);

			Title = "Groceries";
			SubmitItemCommand = new DelegateCommand(AddNewItem);
		}

		public void AddNewItem()
		{
			var newItem = new Item { Name = NewItem, ItemType = (int)ItemType.Groceries };
			_databaseService.AddItem(newItem);
			ItemList.Insert(0, newItem);
			NewItem = "";
		}
	}
}
