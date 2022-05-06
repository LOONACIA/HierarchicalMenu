using System.Windows.Controls;
using System.Windows.Input;

namespace HierarchicalMenu.Views;
/// <summary>
/// MainPage.xaml에 대한 상호 작용 논리
/// </summary>
public partial class MainPage : Page
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnMouseDown(object sender, MouseButtonEventArgs e)
	{
		if (sender is not MenuItem menuItem || !menuItem.HasItems)
			return;

		menuItem.Command?.Execute(menuItem.CommandParameter);
	}
}
