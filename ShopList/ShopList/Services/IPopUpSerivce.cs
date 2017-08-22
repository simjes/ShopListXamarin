using ShopList.ViewModels;
using System;

namespace ShopList.Services
{
	public interface IPopUpSerivce
	{
		void ShowMessageBox(ItemViewModel item, int position);
		event EventHandler<ItemViewModel> UndoDelete;
	}
}
