using BudgetManagement.ViewModels;
namespace BudgetManagement.Views;

public partial class TDepensePage : ContentPage
{
	public TDepensePage(TDepenseViewModel depenseViewModel)
	{
		InitializeComponent();

		BindingContext = depenseViewModel;

        var toolbarPage = new ToolbarPage();

        foreach (var toolbarItem in toolbarPage.ToolbarItems)
        {
            ToolbarItems.Add(toolbarItem);
        }
    }
}