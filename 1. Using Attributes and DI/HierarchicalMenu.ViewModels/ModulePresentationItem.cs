using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using HierarchicalMenu.ViewModels.Attributes;
using HierarchicalMenu.ViewModels.Messages;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Input;

namespace HierarchicalMenu.ViewModels;

public partial class ModulePresentationItem : ObservableRecipient
{
	#region Fields
	private readonly ObservableCollection<ModulePresentationItem> _child = new();
	#endregion

	#region Contructors
	public ModulePresentationItem(IModuleViewModel viewModel) => ViewModel = viewModel;
	#endregion

	#region Properties
	[ObservableProperty]
	private bool _isSelected;

	public string? Header { get; init; }

	public Type? Parent { get; init; }

	public ushort Order { get; init; }

	public IconType? IconType { get; init; }

	public IModuleViewModel ViewModel { get; init; }

	public IEnumerable<ModulePresentationItem> Child
	{
		get => this._child;
		set
		{
			this._child.Clear();
			foreach (var item in value)
			{
				AddChild(item);
			}
			OnPropertyChanged(nameof(Child));
		}
	}
	#endregion

	#region Commands
	private RelayCommand? _changeMenuCommand;
	public ICommand ChangeMenuCommand => this._changeMenuCommand ??= new RelayCommand(OnSelected);
	#endregion

	#region Methods
	internal void AddChild(ModulePresentationItem child)
	{
		this._child.Add(child);
	}

	protected virtual void OnSelected()
	{
		Messenger.Send(new ChangeModulePresentationItemMessage(this));
	}

	public static (bool IsValid, ModulePresentationItem? Value) TryParse(IModuleViewModel viewModel)
	{
		var viewModelType = viewModel.GetType();
		if (viewModelType.GetCustomAttribute(typeof(HeaderAttribute), false) is not HeaderAttribute header)
			return (false, null);

		var parent = viewModelType.GetCustomAttribute(typeof(ParentAttribute), false) as ParentAttribute;
		var order = viewModelType.GetCustomAttribute(typeof(OrderAttribute), false) as OrderAttribute;
		var iconType = viewModelType.GetCustomAttribute(typeof(IconTypeAttribute), false) as IconTypeAttribute;

		var item = new ModulePresentationItem(viewModel)
		{
			Header = header?.Header,
			Parent = parent?.Parent,
			Order = order?.Order ?? ushort.MaxValue,
			IconType = iconType?.IconType
		};

		return (true, item);
	}
	#endregion
}
