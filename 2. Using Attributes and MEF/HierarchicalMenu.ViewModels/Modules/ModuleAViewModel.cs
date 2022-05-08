using HierarchicalMenu.ViewModels.Attributes;

namespace HierarchicalMenu.ViewModels.Modules;

[Export(typeof(IModuleViewModel))]
//[ExportMetadata("Header", "Module A")]
//[ExportMetadata("Order", 0)]
//[ExportMetadata("IconType", IconType.Home)]
[PresentationMetadata(header: "Module A", order: 0, iconType: IconType.Desktop)]
public partial class ModuleAViewModel : ModuleViewModelBase
{
}
