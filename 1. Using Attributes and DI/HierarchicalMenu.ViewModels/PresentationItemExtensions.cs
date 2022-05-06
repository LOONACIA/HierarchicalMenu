namespace HierarchicalMenu.ViewModels;

internal static class PresentationItemExtensions
{
	internal static IEnumerable<ModulePresentationItem> Flatten(this IEnumerable<ModulePresentationItem> e) => e.SelectMany(s => s.Child.Flatten().Prepend(s));
}
