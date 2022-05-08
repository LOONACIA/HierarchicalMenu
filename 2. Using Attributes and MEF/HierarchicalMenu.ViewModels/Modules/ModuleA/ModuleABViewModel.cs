namespace HierarchicalMenu.ViewModels.Modules.ModuleA;

[Export(typeof(IModuleViewModel))]
[ExportMetadata("Header", "Module AB")]
[ExportMetadata("Parent", typeof(ModuleAViewModel))]
[ExportMetadata("Order", 1)]
public partial class ModuleABViewModel : ModuleViewModelBase
{
}
