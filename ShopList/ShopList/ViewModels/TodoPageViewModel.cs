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
			ItemList = _databaseService.GetShopList(ItemType.Todos);

			Title = "Todo";
			SubmitItemCommand = new DelegateCommand(AddNewItem);
		}

		public void AddNewItem()
		{
			_databaseService.AddItem(new Item { Name = NewItem, ItemType = ItemType.Todos });
			NewItem = "";
		}

	}
}
