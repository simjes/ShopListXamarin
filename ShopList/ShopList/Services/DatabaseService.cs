using Realms;
using ShopList.Models;
using ShopList.Services;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]

namespace ShopList.Services
{
	public interface IDatabaseService
	{
		ObservableCollection<Item> GetShopList(int listType);
		void AddItem(Item newItem);
	}


	public class DatabaseService : IDatabaseService
	{
		private readonly Realm _realm;

		public DatabaseService()
		{
			_realm = Realm.GetInstance();
		}

		public ObservableCollection<Item> GetShopList(int listType)
		{
			return new ObservableCollection<Item>(_realm.All<Item>().Where(i => i.ItemType == listType).OrderByDescending(i => i.Id));
		}

		public void AddItem(Item newItem)
		{
			using (var transaction = _realm.BeginWrite())
			{
				int newId = GetNextPrimaryKey();
				newItem.Id = newId;
				_realm.Add(newItem);
				transaction.Commit();
			}
		}

		private int GetNextPrimaryKey()
		{
			Item lastItem = _realm.All<Item>().OrderByDescending(item => item.Id).FirstOrDefault();
			if (lastItem == null) return 0;
			return lastItem.Id + 1;

		}
	}


}
