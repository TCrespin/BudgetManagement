using BudgetManagement.ViewModels;

namespace BudgetManagement.Views;

public partial class TRevenuPage : ContentPage
{
	public TRevenuPage(TRevenuViewModel revenuViewModel)
	{
		InitializeComponent();

        BindingContext = revenuViewModel;

        var toolbarPage = new ToolbarPage();

        foreach (var toolbarItem in toolbarPage.ToolbarItems)
        {
            ToolbarItems.Add(toolbarItem);
        }
    }
}