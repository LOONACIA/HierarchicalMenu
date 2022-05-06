using HierarchicalMenu.Common;
using HierarchicalMenu.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using HierarchicalMenu.ViewModels.Core;

namespace HierarchicalMenu;

internal static class Bootstrapper
{
	internal static void Initialize()
	{
		var services = ConfigureSerivces();
		Ioc.Default.ConfigureServices(services);
	}

	private static IServiceProvider ConfigureSerivces()
	{
		var services = new ServiceCollection();

		// Register Services //
		services.AddSingleton<IModuleViewModelFactory, ModuleViewModelFactory>();

		// Register Module ViewModels //
		AppDomain.CurrentDomain.GetAssemblies()
							   .SelectMany(c => c.GetTypes())
							   .Where(x => typeof(IModuleViewModel).IsAssignableFrom(x) && !x.IsAbstract)
							   .Foreach(type => services.AddTransient(typeof(IModuleViewModel), type));

		// Register Application ViewModel //
		services.AddTransient<ApplicationViewModel>();

		return services.BuildServiceProvider();
	}
}
