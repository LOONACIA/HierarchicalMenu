﻿using CommunityToolkit.Mvvm.DependencyInjection;
using HierarchicalMenu.ViewModels.Core;
using System;
using System.Windows;

namespace HierarchicalMenu;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
	public App()
	{
		Bootstrapper.Initialize();
	}

	protected override void OnStartup(StartupEventArgs e)
	{
		base.OnStartup(e);

		var win = new MainWindow { DataContext = Ioc.Default.GetService<ApplicationViewModel>() };
		win.ShowDialog();
		Environment.Exit(0);
	}
}
