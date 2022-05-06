using System;
using System.ComponentModel;
using System.Globalization;

namespace HierarchicalMenu.Common;

public class EnumFullNameConverter<T> : EnumConverter where T : Enum
{
	public EnumFullNameConverter() : base(typeof(T))
	{

	}

	public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType) => $"{typeof(T).Name}.{value}";
}
