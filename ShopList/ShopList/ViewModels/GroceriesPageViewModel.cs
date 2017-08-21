using Prism.Commands;
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

		public override void AddNewItem()
		{
			var newItem = new ItemViewModel { Name = NewItem, ItemType = (int)ItemType.Groceries };
			_databaseService.AddItem(newItem);
			ItemList.Insert(0, newItem);
			NewItem = "";
		}
	}
}
