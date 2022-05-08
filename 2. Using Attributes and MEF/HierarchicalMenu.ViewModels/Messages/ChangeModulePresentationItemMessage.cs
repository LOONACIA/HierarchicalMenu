using CommunityToolkit.Mvvm.Messaging.Messages;

namespace HierarchicalMenu.ViewModels.Messages;

public class ChangeModulePresentationItemMessage : ValueChangedMessage<ModulePresentationItem>
{
	public ChangeModulePresentationItemMessage(ModulePresentationItem newItem) : base(newItem)
	{

	}
}
