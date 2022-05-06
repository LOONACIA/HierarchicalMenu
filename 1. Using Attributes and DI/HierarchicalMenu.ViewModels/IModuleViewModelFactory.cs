namespace HierarchicalMenu.ViewModels;

public interface IModuleViewModelFactory
{
	IReadOnlyList<ModulePresentationItem> ModulePresentationHierarchy { get; }
	IModuleViewModel GetModuleViewModel(ModulePresentationItem presentationItem);
}
