using System.ComponentModel;
using System.Runtime.InteropServices;

namespace HierarchicalMenu.ViewModels.Attributes;

[MetadataAttribute]
[AttributeUsage(AttributeTargets.Class)]
public sealed class PresentationMetadataAttribute : Attribute, IModuleViewModelMetadata
{
	public string? Header { get; }

	public Type? Parent { get; }

	public int Order { get; }

	public IconType? IconType { get; }

	public PresentationMetadataAttribute(string? header, [Optional]Type? parent, [Optional]int order, [Optional]IconType iconType) => (Header, Parent, Order, IconType) = (header, parent, order, iconType);
}
