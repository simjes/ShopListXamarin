using Realms;
using ShopList.Services;
using ShopList.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]

namespace ShopList.Services
{
	public interface IDatabaseService
	{
		ObservableCollection<ItemViewModel> GetShopList(int listType);
		void AddItem(ItemViewModel item);
		void RemoveItem(ItemViewModel item);
	}


	public class DatabaseService : IDatabaseService
	{
		private readonly Realm _realm;

		public DatabaseService()
		{
			_realm = Realm.GetInstance();
		}

		public ObservableCollection<ItemViewModel> GetShopList(int listType)
		{
			return new ObservableCollection<ItemViewModel>(_realm.All<ItemViewModel>().Where(i => i.ItemType == listType).OrderByDescending(i => i.Id));
		}

		public void AddItem(ItemViewModel item)
		{
			using (var transaction = _realm.BeginWrite())
			{
				int newId = GetNextPrimaryKey();
				item.Id = newId;
				_realm.Add(item);
				transaction.Commit();
			}
		}

		public void RemoveItem(ItemViewModel item)
		{
			using (var transaction = _realm.BeginWrite())
			{
				_realm.Remove(item);
				transaction.Commit();
			}
		}

		private int GetNextPrimaryKey()
		{
			ItemViewModel lastItemViewModel = _realm.All<ItemViewModel>().OrderByDescending(item => item.Id).FirstOrDefault();
			if (lastItemViewModel == null) return 0;
			return lastItemViewModel.Id + 1;

		}
	}


}
