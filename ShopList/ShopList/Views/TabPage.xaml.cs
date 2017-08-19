using Prism.Navigation;
using Xamarin.Forms;

namespace ShopList.Views
{
	public partial class TabPage : TabbedPage, INavigatingAware
	{
		public TabPage()
		{
			InitializeComponent();
		}
		public void OnNavigatingTo(NavigationParameters parameters)
		{
			foreach (var child in Children)
			{
				(child as INavigatingAware)?.OnNavigatingTo(parameters);
				(child?.BindingContext as INavigatingAware)?.OnNavigatingTo(parameters);
			}
		}
	}
}
