namespace BudgetManagement.Views;

public partial class TEpargnePage : ContentPage
{
	public TEpargnePage()
	{
		InitializeComponent();

        var toolbarPage = new ToolbarPage();

        foreach (var toolbarItem in toolbarPage.ToolbarItems)
        {
            ToolbarItems.Add(toolbarItem);
        }
    }
}