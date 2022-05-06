using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchicalMenu.ViewModels.Modules.ModuleA.ModuleAB;

[Header("Module ABB")]
[Parent(typeof(ModuleABViewModel))]
[Order(0)]
public partial class ModuleABBViewModel : ModuleViewModelBase
{
}
