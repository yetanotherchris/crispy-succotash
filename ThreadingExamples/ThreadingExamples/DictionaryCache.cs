using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.ObjectModel;

namespace ThreadingExamples
{
	public class Item
	{
		public int ID { get; set; }
	}

	public class AsyncCache
	{
		protected static readonly Dictionary<int, Item> _externalDataStoreProxy = new Dictionary<int, Item>();

		protected static readonly Dictionary<int, Item> _cache = new Dictionary<int, Item>();

		protected static readonly HashSet<int> _requestedIds = new HashSet<int>();
		protected static readonly ReaderWriterLockSlim _requestedIdsLock = new ReaderWriterLockSlim();

		public Item Get(int id)
		{
			// if item does not exist in cache
			if (!_cache.ContainsKey(id))
			{
				_requestedIdsLock.EnterUpgradeableReadLock();
				try
				{
					// if item was already requested by another thread
					if (_requestedIds.Contains(id))
					{
						_requestedIdsLock.ExitUpgradeableReadLock();
						lock (_cache)
						{
							while (!_cache.ContainsKey(id))
								Monitor.Wait(_cache);

							// once we get here, _cache has our item
						}
					}
					// else, item has not yet been requested by a thread
					else
					{
						_requestedIdsLock.EnterWriteLock();
						try
						{
							// record the current request
							_requestedIds.Add(id);
							_requestedIdsLock.ExitWriteLock();
							_requestedIdsLock.ExitUpgradeableReadLock();

							// get the data from the external resource
							#region fake implementation - replace with real code
							var item = _externalDataStoreProxy[id];
							Thread.Sleep(10000);
							#endregion

							lock (_cache)
							{
								_cache.Add(id, item);
								Monitor.PulseAll(_cache);
							}
						}
						finally
						{
							// let go of any held locks
							if (_requestedIdsLock.IsWriteLockHeld)
								_requestedIdsLock.ExitWriteLock();
						}
					}
				}
				finally
				{
					// let go of any held locks
					if (_requestedIdsLock.IsUpgradeableReadLockHeld)
						_requestedIdsLock.ExitReadLock();
				}
			}

			return _cache[id];
		}

		public Collection<Item> Get(Collection<int> ids)
		{
			var notInCache = ids.Except(_cache.Keys);

			// if some items don't exist in cache
			if (notInCache.Count() > 0)
			{
				_requestedIdsLock.EnterUpgradeableReadLock();
				try
				{
					var needToGet = notInCache.Except(_requestedIds);

					// if any items have not yet been requested by other threads
					if (needToGet.Count() > 0)
					{
						_requestedIdsLock.EnterWriteLock();
						try
						{
							// record the current request
							foreach (var id in ids)
								_requestedIds.Add(id);

							_requestedIdsLock.ExitWriteLock();
							_requestedIdsLock.ExitUpgradeableReadLock();

							// get the data from the external resource
							#region fake implementation - replace with real code
							var data = new Collection<Item>();
							foreach (var id in needToGet)
							{
								var item = _externalDataStoreProxy[id];
								data.Add(item);
							}
							Thread.Sleep(10000);
							#endregion

							lock (_cache)
							{
								foreach (var item in data)
									_cache.Add(item.ID, item);

								Monitor.PulseAll(_cache);
							}
						}
						finally
						{
							// let go of any held locks
							if (_requestedIdsLock.IsWriteLockHeld)
								_requestedIdsLock.ExitWriteLock();
						}
					}

					if (_requestedIdsLock.IsUpgradeableReadLockHeld)
						_requestedIdsLock.ExitUpgradeableReadLock();

					var waitingFor = notInCache.Except(needToGet);
					// if any remaining items were already requested by other threads
					if (waitingFor.Count() > 0)
					{
						lock (_cache)
						{
							while (waitingFor.Count() > 0)
							{
								Monitor.Wait(_cache);
								waitingFor = waitingFor.Except(_cache.Keys);
							}

							// once we get here, _cache has all our items
						}
					}
				}
				finally
				{
					// let go of any held locks
					if (_requestedIdsLock.IsUpgradeableReadLockHeld)
						_requestedIdsLock.ExitReadLock();
				}
			}

			return new Collection<Item>(ids.Select(id => _cache[id]).ToList());
		}
	}
}
