using Prism.Commands;
using ShopList.Models;
using ShopList.Services;

namespace ShopList.ViewModels
{
	public class GroceriesPageViewModel : TabChildViewModelBase
	{
		public GroceriesPageViewModel(IDatabaseService databaseService) : base(databaseService)
		{
			_databaseService = databaseService;
			ItemList = _databaseService.GetShopList(ItemType.Groceries);

			Title = "Groceries";
			SubmitItemCommand = new DelegateCommand(AddNewItem);
			//ItemList = databaseService.GetShopList(ItemType.Groceries);
		}

		public void AddNewItem()
		{
			_databaseService.AddItem(new Item { Name = NewItem, ItemType = ItemType.Groceries });
			NewItem = "";
		}
	}
}
