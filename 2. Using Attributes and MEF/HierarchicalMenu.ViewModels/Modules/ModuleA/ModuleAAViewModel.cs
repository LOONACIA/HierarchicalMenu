using HierarchicalMenu.ViewModels.Attributes;

namespace HierarchicalMenu.ViewModels.Modules.ModuleA;

[Export(typeof(IModuleViewModel))]
//[ExportMetadata("Header", "Module AA")]
//[ExportMetadata("Parent", typeof(ModuleAViewModel))]
//[ExportMetadata("Order", 0)]
[PresentationMetadata(header: "Module AA", parent: typeof(ModuleAViewModel), order: 0)]
public partial class ModuleAAViewModel : ModuleViewModelBase
{
}
