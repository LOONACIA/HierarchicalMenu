using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchicalMenu.ViewModels.Modules;

public partial class ModuleViewModelBase : ObservableObject, IModuleViewModel
{
	[ObservableProperty]
	private bool isVisible;
}
