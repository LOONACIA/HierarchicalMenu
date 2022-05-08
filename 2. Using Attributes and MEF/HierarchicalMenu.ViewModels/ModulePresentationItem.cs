using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using HierarchicalMenu.ViewModels.Messages;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace HierarchicalMenu.ViewModels;

public partial class ModulePresentationItem : ObservableRecipient, IModuleViewModelMetadata
{
	#region Fields
	private readonly ObservableCollection<ModulePresentationItem> _child = new();
	#endregion

	#region Contructors

	#endregion

	#region Properties
	[ObservableProperty]
	private bool _isSelected;

	public string? Header { get; init; }

	[DefaultValue(null)]
	public Type? Parent { get; init; }

	[DefaultValue(int.MaxValue)]
	public int Order { get; init; }

	[DefaultValue(Common.IconType.None)]
	public IconType? IconType { get; init; }

	public IModuleViewModel? ViewModel { get; internal set; }

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
	#endregion
}
