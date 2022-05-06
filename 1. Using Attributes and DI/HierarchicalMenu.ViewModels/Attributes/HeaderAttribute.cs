namespace HierarchicalMenu.ViewModels.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public sealed class HeaderAttribute : Attribute
{
	public string? Header { get; set; }

	public HeaderAttribute(string? header) => Header = header;
}
