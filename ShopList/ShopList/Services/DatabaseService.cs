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
				_realm.Add(newItem);
				transaction.Commit();
			}
			//switch (newItem.ItemType)
			//{
			//	case ItemType.Groceries:
			//		_groceries.Insert(0, newItem);
			//		break;
			//	case ItemType.Todos:
			//		_todos.Insert(0, newItem);
			//		break;
			//}
		}
	}
}
