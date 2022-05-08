using System.ComponentModel;

namespace HierarchicalMenu.ViewModels;

public interface IModuleViewModelMetadata
{
	string? Header { get; }

	//[DefaultValue(null)]
	Type? Parent { get; }

	//[DefaultValue(int.MaxValue)]
	int Order { get; }

	//[DefaultValue(Common.IconType.None)]
	IconType? IconType { get; }
}
