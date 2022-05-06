namespace HierarchicalMenu.ViewModels.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public sealed class OrderAttribute : Attribute
{
	public ushort? Order { get; set; }

	public OrderAttribute(ushort order) => Order = order;
}