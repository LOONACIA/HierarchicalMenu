namespace HierarchicalMenu.ViewModels.Modules;

[Export(typeof(IModuleViewModel))]
[ExportMetadata("Header", "Module B")]
[ExportMetadata("Order", 1)]
public partial class ModuleBViewModel : ModuleViewModelBase
{
}
