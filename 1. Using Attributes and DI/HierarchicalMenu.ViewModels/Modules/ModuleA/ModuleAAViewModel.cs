namespace HierarchicalMenu.ViewModels.Modules.ModuleA;

[Header("Module AA")]
[Parent(typeof(ModuleAViewModel))]
[Order(0)]
[IconType(IconType.None)]
public partial class ModuleAAViewModel : ModuleViewModelBase
{
}
