﻿using Prism.Mvvm;
using Prism.Navigation;

namespace ShopList.ViewModels
{
	public class BaseViewModel : BindableBase, INavigatingAware, IDestructible
	{
		private string _title;
		public string Title
		{
			get => _title;
			set => SetProperty(ref _title, value);
		}

		public virtual void Destroy()
		{
		}

		public virtual void OnNavigatingTo(NavigationParameters parameters)
		{
		}
	}
}
