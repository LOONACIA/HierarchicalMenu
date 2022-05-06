using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchicalMenu.ViewModels.Modules.ModuleA;

[Header("Module AB")]
[Parent(typeof(ModuleAViewModel))]
[Order(1)]
[IconType(IconType.None)]
public partial class ModuleABViewModel : ModuleViewModelBase
{
}
