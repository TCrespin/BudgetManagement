using BudgetManagement.ViewModels;

namespace BudgetManagement.Views;

public partial class RevenuPage : ContentPage
{
	public RevenuPage(RevenuViewModel revenuViewModel)
	{
		InitializeComponent();

		BindingContext = revenuViewModel;
    }
}