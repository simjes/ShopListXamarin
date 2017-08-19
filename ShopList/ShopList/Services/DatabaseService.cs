﻿using ShopList.Models;
using ShopList.Services;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]

namespace ShopList.Services
{
	public interface IDatabaseService
	{
		ObservableCollection<Item> GetShopList(ItemType listType);
		void AddItem(Item newItem);
	}


	public class DatabaseService : IDatabaseService
	{

		private readonly ObservableCollection<Item> _groceries = new ObservableCollection<Item>()
		{
			new Item{Name = "G first item", AddTime = DateTime.Now, ItemType = ItemType.Groceries},
			new Item{Name = "G second item", AddTime = DateTime.Now, ItemType = ItemType.Groceries},
			new Item{Name = "G third item", AddTime = DateTime.Now, ItemType = ItemType.Groceries}
		};

		private readonly ObservableCollection<Item> _todos = new ObservableCollection<Item>()
		{
			new Item{Name = "T first item", AddTime = DateTime.Now, ItemType = ItemType.Groceries},
			new Item{Name = "T second item", AddTime = DateTime.Now, ItemType = ItemType.Groceries},
			new Item{Name = "T third item", AddTime = DateTime.Now, ItemType = ItemType.Groceries}
		};

		public ObservableCollection<Item> GetShopList(ItemType listType)
		{
			switch (listType)
			{
				case ItemType.Groceries:
					return _groceries;
				case ItemType.Todos:
					return _todos;
				default:
					return null;
			}

		}

		public void AddItem(Item newItem)
		{
			switch (newItem.ItemType)
			{
				case ItemType.Groceries:
					_groceries.Insert(0, newItem);
					break;
				case ItemType.Todos:
					_todos.Insert(0, newItem);
					break;
			}
		}
	}
}
