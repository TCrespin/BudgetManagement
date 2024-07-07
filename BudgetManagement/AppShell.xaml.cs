using BudgetManagement.Views;

namespace BudgetManagement
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(DepensePage), typeof(DepensePage));
            Routing.RegisterRoute(nameof(RevenuPage), typeof(RevenuPage));
            Routing.RegisterRoute(nameof(EpargnePage), typeof(EpargnePage));
            Routing.RegisterRoute(nameof(Home), typeof(Home));
        }
    }
}
