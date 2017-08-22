using Prism.Commands;
using ShopList.Services;

namespace ShopList.ViewModels
{
	public class TodoPageViewModel : TabChildViewModelBase
	{
		public TodoPageViewModel(IDatabaseService databaseService, IPopUpSerivce popUpSerivce) : base(databaseService, popUpSerivce)
		{
			_databaseService = databaseService;
			popUpSerivce.UndoDelete += OnUndoDelete;
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

		protected override void OnUndoDelete(object sender, ItemViewModel item)
		{
			if (item.ItemType != (int)ItemType.Todos) return;
			_databaseService.AddItem(item);
			ItemList.Insert((int)item.Position, item);
		}
	}
}
