namespace BudgetManagement.Views;

public partial class ComptePage : ContentPage
{
	public ComptePage()
	{
		InitializeComponent();

        var toolbarPage = new ToolbarPage();

        foreach (var toolbarItem in toolbarPage.ToolbarItems)
        {
            ToolbarItems.Add(toolbarItem);
        }
    }
}