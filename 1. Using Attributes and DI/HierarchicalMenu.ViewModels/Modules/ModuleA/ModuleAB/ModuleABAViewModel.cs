namespace HierarchicalMenu.ViewModels.Modules.ModuleA.ModuleAB;

[Header("Module ABA")]
[Parent(typeof(ModuleABViewModel))]
[Order(1)]
[IconType(IconType.Home)]
public partial class ModuleABAViewModel : ModuleViewModelBase
{
}
