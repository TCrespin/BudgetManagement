using BudgetManagement.Views;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace BudgetManagement.ViewModels;

public partial class HomeViewModel
{
    public ICommand NewDepense {  get; }
    public ICommand NewRevenu { get; }
    public ICommand NewEpargne { get; }
    public HomeViewModel()
    {
        NewDepense = new AsyncRelayCommand(GotoDepensePage);
        NewRevenu = new AsyncRelayCommand(GotoRevenuPage);
        NewEpargne = new AsyncRelayCommand(GotoEpargnePage);
    }

    async Task GotoDepensePage()
    {
        await Shell.Current.GoToAsync(nameof(Views.DepensePage));
    }

    async Task GotoRevenuPage()
    {
        await Shell.Current.GoToAsync(nameof(Views.RevenuPage));
    }

    async Task GotoEpargnePage()
    {
        await Shell.Current.GoToAsync(nameof(Views.EpargnePage));
    }
}
