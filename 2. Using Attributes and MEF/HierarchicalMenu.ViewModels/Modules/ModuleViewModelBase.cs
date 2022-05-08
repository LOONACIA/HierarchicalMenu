using CommunityToolkit.Mvvm.ComponentModel;

namespace HierarchicalMenu.ViewModels.Modules;

public partial class ModuleViewModelBase : ObservableObject, IModuleViewModel
{
	[ObservableProperty]
	private bool isVisible;
}
