using HierarchicalMenu.ViewModels.Attributes;

namespace HierarchicalMenu.ViewModels.Modules.ModuleA.ModuleAB;

[Export(typeof(IModuleViewModel))]
[PresentationMetadata(header: "Module ABA", parent: typeof(ModuleABViewModel), order: 0, iconType: IconType.Desktop)]
public partial class ModuleABAViewModel : ModuleViewModelBase
{
}
