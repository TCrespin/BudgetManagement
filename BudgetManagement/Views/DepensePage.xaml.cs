using BudgetManagement.ViewModels;

namespace BudgetManagement.Views;

public partial class DepensePage : ContentPage
{
	public DepensePage(DepenseViewModel depenseViewModel)
	{
		InitializeComponent();

		BindingContext = depenseViewModel;
	}
}