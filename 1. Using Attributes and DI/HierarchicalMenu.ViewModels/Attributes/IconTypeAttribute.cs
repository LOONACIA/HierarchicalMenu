namespace HierarchicalMenu.ViewModels.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class IconTypeAttribute : Attribute
{
	public IconType? IconType { get; set; }

	public IconTypeAttribute(IconType iconType) => IconType = iconType;
}

