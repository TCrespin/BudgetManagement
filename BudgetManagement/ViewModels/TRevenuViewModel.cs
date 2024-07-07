using System.Collections.ObjectModel;
using System.Windows.Input;
using BudgetManagement.Models;
using BudgetManagement.Models.Table;
using CommunityToolkit.Mvvm.Input;

namespace BudgetManagement.ViewModels;

public partial class TRevenuViewModel
{
    public ObservableCollection<RevenuViewModel> AllRevenus { get; } = new();
    public ICommand SelectRevenuCommand { get; }
    public ICommand NewRevenu { get; }
    private RevenuDatabase revenuDatabase;

    public TRevenuViewModel(RevenuDatabase revenuDatabase)
    {
        this.revenuDatabase = revenuDatabase;
        Task task = GetAllRevenusAsync();
        SelectRevenuCommand = new AsyncRelayCommand<RevenuViewModel>(SelectRevenuAsync);
        revenuDatabase.IsModify += GetAllRevenusAsync;
        NewRevenu = new AsyncRelayCommand(GotoRevenuPage);
    }

    async Task GotoRevenuPage()
    {
        await Shell.Current.GoToAsync(nameof(Views.RevenuPage));
    }

    public async Task GetAllRevenusAsync()
    {
        AllRevenus.Clear();
        Task<List<Revenu>> revenus = revenuDatabase.GetRevenusAsync();
        foreach (Revenu revenu in await revenus)
        {
            AllRevenus.Add(new RevenuViewModel(revenu, revenuDatabase));
        }
    }
    async Task SelectRevenuAsync(RevenuViewModel? revenu)
    {
        if (revenu == null) return;
        await Shell.Current.GoToAsync(nameof(Views.RevenuPage), true, new Dictionary<string, object>
        {
            { "load", revenu.revenu}
        });
    }
}
