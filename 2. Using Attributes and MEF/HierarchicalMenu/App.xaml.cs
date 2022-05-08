using HierarchicalMenu.ViewModels.Core;
using Microsoft.VisualStudio.Composition;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace HierarchicalMenu;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
	public ExportProvider? ExportProvider { get; private set; }

	protected override async void OnStartup(StartupEventArgs e)
	{
		base.OnStartup(e);
		ExportProvider = await HostingMefAsync();
		var win = new MainWindow { DataContext = ExportProvider.GetExportedValue<ApplicationViewModel>() };
		win.ShowDialog();
		Environment.Exit(0);
	}

	private async Task<ExportProvider> HostingMefAsync()
	{
		var discovery = PartDiscovery.Combine(
			new AttributedPartDiscovery(Resolver.DefaultInstance),
			new AttributedPartDiscoveryV1(Resolver.DefaultInstance));

		var assemblies = AppDomain.CurrentDomain.GetAssemblies();

		var catalog = ComposableCatalog.Create(Resolver.DefaultInstance)
			.AddParts(await discovery.CreatePartsAsync(assemblies))
			.WithCompositionService();

		var config = CompositionConfiguration.Create(catalog);

		var epf = config.CreateExportProviderFactory();

		return epf.CreateExportProvider();
	}
}
