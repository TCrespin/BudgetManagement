namespace BudgetManagement.Views
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();

            var toolbarPage = new ToolbarPage();

            foreach (var toolbarItem in toolbarPage.ToolbarItems)
            {
                ToolbarItems.Add(toolbarItem);
            }
        }
    }
}
