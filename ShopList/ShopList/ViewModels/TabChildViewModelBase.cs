using Prism;
using Prism.Commands;
using Prism.Navigation;
using ShopList.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ShopList.ViewModels
{
	public class TabChildViewModelBase : BaseViewModel, IActiveAware, INavigatingAware, IDestructible
	{
		protected IDatabaseService _databaseService;
		public DelegateCommand SubmitItemCommand { get; set; }

		private ObservableCollection<ItemViewModel> _itemList;
		public ObservableCollection<ItemViewModel> ItemList { get => _itemList; set => SetProperty(ref _itemList, value); }

		private string _newItem;
		public string NewItem
		{
			get => _newItem;
			set => SetProperty(ref _newItem, value);
		}

		public TabChildViewModelBase(IDatabaseService databaseService)
		{
			_databaseService = databaseService;
			IsActiveChanged += (sender, e) => Debug.WriteLine($"{Title} IsActive: {IsActive}");
		}

		public event EventHandler IsActiveChanged;

		private string _message;
		public string Message
		{
			get => _message;
			set => SetProperty(ref _message, value);
		}

		private bool _isActive;
		public bool IsActive
		{
			get => _isActive;
			set { SetProperty(ref _isActive, value, () => Debug.WriteLine($"{Title} IsActive Changed: {value}")); }
		}

		public override void OnNavigatingTo(NavigationParameters parameters)
		{
			Debug.WriteLine($"{Title} is executing OnNavigatingTo");
			var message = parameters.GetValue<string>("message");
			Message = $"{Title} Initialized by OnNavigatingTo: {message}";
		}

		public override void Destroy()
		{
			Debug.WriteLine($"{Title} is being Destroyed!");
		}


		public void DeleteItem(ItemViewModel item)
		{
			ItemList.Remove(item);
			_databaseService.RemoveItem(item);
		}
	}
}
