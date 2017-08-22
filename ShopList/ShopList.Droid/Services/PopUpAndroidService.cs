using Android.App;
using Android.Support.Design.Widget;
using ShopList.Droid.Services;
using ShopList.Services;
using ShopList.ViewModels;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(PopUpAndroidService))]
namespace ShopList.Droid.Services
{
	class PopUpAndroidService : IPopUpSerivce
	{
		public event EventHandler<ItemViewModel> UndoDelete;

		public void ShowMessageBox(ItemViewModel item, int position)
		{
			var view = ((Activity)Forms.Context).FindViewById(Resource.Id.sliding_tabs);
			var snackbar = Snackbar.Make(view, $"You removed: {item.Name}", Snackbar.LengthLong);
			snackbar.SetAction("UNDO", s =>
			{
				UndoDelete?.Invoke(this, item);
			});
			snackbar.Show();
		}
	}
}