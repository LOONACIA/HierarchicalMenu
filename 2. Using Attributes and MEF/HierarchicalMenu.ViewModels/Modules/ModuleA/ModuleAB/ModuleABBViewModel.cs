namespace HierarchicalMenu.ViewModels.Modules.ModuleA.ModuleAB;

[Export(typeof(IModuleViewModel))]
[ExportMetadata("Header", "Module ABB")]
[ExportMetadata("Parent", typeof(ModuleABViewModel))]
[ExportMetadata("Order", 1)]
public partial class ModuleABBViewModel : ModuleViewModelBase
{
}
