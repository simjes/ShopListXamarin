using ShopList.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopList.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemListView : ContentView
	{
		public ItemListView()
		{
			InitializeComponent();
		}
		private void OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			(BindingContext as TabChildViewModelBase)?.DeleteItem(e.Item as ItemViewModel);
		}
	}
}