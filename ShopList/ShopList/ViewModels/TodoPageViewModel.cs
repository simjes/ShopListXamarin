using Prism.Commands;
using ShopList.Services;

namespace ShopList.ViewModels
{
	public class TodoPageViewModel : TabChildViewModelBase
	{
		public TodoPageViewModel(IDatabaseService databaseService, IPopUpSerivce popUpSerivce) : base(databaseService, popUpSerivce)
		{
			_databaseService = databaseService;
			ItemList = _databaseService.GetShopList((int)ItemType.Todos);

			Title = "Todo";
			SubmitItemCommand = new DelegateCommand(AddNewItem);
		}

		public override void AddNewItem()
		{
			var newItem = new ItemViewModel { Name = NewItem, ItemType = (int)ItemType.Todos };
			_databaseService.AddItem(newItem);
			ItemList.Insert(0, newItem);
			NewItem = "";
		}
	}
}
