using System.ComponentModel;

namespace HierarchicalMenu.Common;

[TypeConverter(typeof(EnumFullNameConverter<IconType>))]
public enum IconType
{
	None,
	Home,
	Desktop
}
