using System.Collections.ObjectModel;

namespace HierarchicalMenu.Common;

public static class EnumerableExtensions
{
	public static ObservableCollection<T> ToObservable<T>(this IEnumerable<T> list) => new(list);

	public static void Foreach<T>(this IEnumerable<T> items, Action<T> action)
	{
		if (action is null)
			throw new ArgumentNullException(nameof(action));

		var list = items.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			action(list[i]);
		}
	}
}
