﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}