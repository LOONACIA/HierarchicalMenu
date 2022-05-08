namespace HierarchicalMenu.ViewModels.Modules.ModuleA;

[Header("Module AB")]
[Parent(typeof(ModuleAViewModel))]
[Order(1)]
[IconType(IconType.None)]
public partial class ModuleABViewModel : ModuleViewModelBase
{
}
