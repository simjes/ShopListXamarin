using Prism.Unity;
using ShopList.Views;
using Xamarin.Forms;

namespace ShopList
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer) { }

		protected override void OnInitialized()
		{
			InitializeComponent();

			NavigationService.NavigateAsync("NavigationPage/TabPage/GroceriesPage");
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<NavigationPage>();
			Container.RegisterTypeForNavigation<TabPage>();
			Container.RegisterTypeForNavigation<GroceriesPage>();
			Container.RegisterTypeForNavigation<TodoPage>();
		}
	}
}
