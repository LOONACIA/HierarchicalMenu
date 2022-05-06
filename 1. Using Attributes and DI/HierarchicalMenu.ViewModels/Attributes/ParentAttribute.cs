namespace HierarchicalMenu.ViewModels.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public sealed class ParentAttribute : Attribute
{
	public Type? Parent { get; set; }

	public ParentAttribute(Type? parent) => Parent = parent;
}
