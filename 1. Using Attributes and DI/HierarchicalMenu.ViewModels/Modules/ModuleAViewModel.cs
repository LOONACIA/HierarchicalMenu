using HierarchicalMenu.ViewModels.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchicalMenu.ViewModels.Modules;

[Header("Module A")]
[Order(0)]
[IconType(IconType.Desktop)]
public partial class ModuleAViewModel : ModuleViewModelBase
{
}
