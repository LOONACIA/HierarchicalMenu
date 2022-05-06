using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchicalMenu.ViewModels.Modules.ModuleA;

[Header("Module AA")]
[Parent(typeof(ModuleAViewModel))]
[Order(0)]
[IconType(IconType.None)]
public partial class ModuleAAViewModel : ModuleViewModelBase
{
}
