using Prism.Commands;
using ShopList.Models;
using ShopList.Services;

namespace ShopList.ViewModels
{
	public class TodoPageViewModel : TabChildViewModelBase
	{
		public TodoPageViewModel(IDatabaseService databaseService) : base(databaseService)
		{
			_databaseService = databaseService;
			ItemList = _databaseService.GetShopList((int)ItemType.Todos);

			Title = "Todo";
			SubmitItemCommand = new DelegateCommand(AddNewItem);
		}

		public void AddNewItem()
		{
			var newItem = new Item { Name = NewItem, ItemType = (int)ItemType.Todos };
			_databaseService.AddItem(newItem);
			ItemList.Insert(0, newItem);
			NewItem = "";
		}

	}
}
