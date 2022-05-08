using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using HierarchicalMenu.ViewModels.Extensions;
using HierarchicalMenu.ViewModels.Messages;
using System.Collections.ObjectModel;

namespace HierarchicalMenu.ViewModels.Core;

[Export(typeof(ApplicationViewModel))]
public partial class ApplicationViewModel : ObservableRecipient, IRecipient<ChangeModulePresentationItemMessage>
{
	#region Fields
	private readonly IModuleViewModelFactory _moduleViewModelFactory;
	#endregion

	#region Constructors
	[ImportingConstructor]
	public ApplicationViewModel(IModuleViewModelFactory moduleViewModelFactory)
	{
		this._moduleViewModelFactory = moduleViewModelFactory;
		this._menuItems = this._moduleViewModelFactory.ModulePresentationHierarchy.ToObservable();
		Messenger.Register(this);
	}
	#endregion

	#region Properties
	[ObservableProperty]
	private ObservableCollection<ModulePresentationItem> _menuItems = new();

	[ObservableProperty]
	private ObservableCollection<IModuleViewModel> _modules = new();
	#endregion

	#region Methods
	public void Receive(ChangeModulePresentationItemMessage message) => ChangeModulePresentationItem(message.Value);

	private void ChangeModulePresentationItem(ModulePresentationItem newToolItem)
	{
		this._modules.Where(x => x.IsVisible)
					 .Foreach(x => x.IsVisible = false);

		this._menuItems.Flatten()
					   .Where(x => x.IsSelected)
					   .Foreach(x => x.IsSelected = false);

		var viewModel = this._moduleViewModelFactory.GetModuleViewModel(newToolItem);
		if (!this._modules.Contains(viewModel))
			this._modules.Add(viewModel);

		viewModel.IsVisible = true;
		newToolItem.IsSelected = true;
	}
	#endregion
}
