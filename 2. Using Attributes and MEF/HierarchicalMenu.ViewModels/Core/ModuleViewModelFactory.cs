namespace HierarchicalMenu.ViewModels.Core;

[Export(typeof(IModuleViewModelFactory))]
public sealed class ModuleViewModelFactory : IModuleViewModelFactory
{
	#region Fields
	private readonly Dictionary<ModulePresentationItem, IModuleViewModel> _moduleViewModelCache = new();

	private readonly IReadOnlyList<ModulePresentationItem> _modulePresentationHierarchy;
	#endregion

	#region Contructors
	[ImportingConstructor]
	public ModuleViewModelFactory([ImportMany] IEnumerable<Lazy<IModuleViewModel, ModulePresentationItem>> viewModels) => this._modulePresentationHierarchy = BuildPresentationHierarchy(viewModels);
	#endregion

	#region Properties
	public IReadOnlyList<ModulePresentationItem> ModulePresentationHierarchy => this._modulePresentationHierarchy;
	#endregion

	#region Methods
	private List<ModulePresentationItem> BuildPresentationHierarchy(IEnumerable<Lazy<IModuleViewModel, ModulePresentationItem>> viewModels)
	{
		var ret = new List<ModulePresentationItem>();

		var presentationItems = viewModels.Select(item =>
		{
			var metadata = item.Metadata;
			metadata.ViewModel = item.Value;
			return metadata;
		}).ToList();

		foreach (var item in presentationItems)
		{
			var parentType = item.Parent;
			if (parentType is null)
			{
				ret.Add(item);
			}
			else
			{
				var parentItem = presentationItems.SingleOrDefault(x => x.ViewModel!.GetType().Equals(parentType)) ?? throw new InvalidOperationException();
				parentItem.AddChild(item);
			}
		}

		return SortByOrder(ret);
	}

	private List<ModulePresentationItem> SortByOrder(IEnumerable<ModulePresentationItem> items)
	{
		items = items.OrderBy(x => x.Order);
		foreach (var item in items)
		{
			if (item.Child.Any())
			{
				item.Child = SortByOrder(item.Child);
			}
		}

		return items.ToList();
	}

	public IModuleViewModel GetModuleViewModel(ModulePresentationItem item)
	{
		if (!this._moduleViewModelCache.ContainsKey(item))
		{
			this._moduleViewModelCache.Add(item, item.ViewModel);
		}

		return this._moduleViewModelCache[item];
	}
	#endregion
}
