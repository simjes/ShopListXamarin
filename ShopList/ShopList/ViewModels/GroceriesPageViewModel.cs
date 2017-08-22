using Prism.Commands;
using ShopList.Services;

namespace ShopList.ViewModels
{
	public class GroceriesPageViewModel : TabChildViewModelBase
	{
		public GroceriesPageViewModel(IDatabaseService databaseService, IPopUpSerivce popUpSerivce) : base(databaseService, popUpSerivce)
		{
			_databaseService = databaseService;
			popUpSerivce.UndoDelete += OnUndoDelete;
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

		private void OnUndoDelete(object sender, ItemViewModel item)
		{
			if (item.ItemType != (int)ItemType.Groceries) return;
			_databaseService.AddItem(item);
			ItemList.Insert((int)item.Position, item);
		}
	}
}
