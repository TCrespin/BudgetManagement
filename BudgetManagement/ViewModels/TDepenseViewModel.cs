using System.Collections.ObjectModel;
using System.Windows.Input;
using BudgetManagement.Models;
using BudgetManagement.Models.Table;
using CommunityToolkit.Mvvm.Input;

namespace BudgetManagement.ViewModels;

public partial class TDepenseViewModel
{
    public ObservableCollection<DepenseViewModel> AllDepenses { get; } = new();  
    public ICommand SelectDepenseCommand { get; }
    public ICommand NewDepense { get; }
    private DepenseDatabase depenseDatabase;

    public TDepenseViewModel(DepenseDatabase depenseDatabase)
    {
        this.depenseDatabase = depenseDatabase;
        Task task = GetAllDepensesAsync();
        SelectDepenseCommand = new AsyncRelayCommand<DepenseViewModel>(SelectDepenseAsync);
        depenseDatabase.IsModify += GetAllDepensesAsync;
        NewDepense = new AsyncRelayCommand(GotoDepensePage);
    }

    async Task GotoDepensePage()
    {
        await Shell.Current.GoToAsync(nameof(Views.DepensePage));
    }

    public async Task GetAllDepensesAsync()
    {
        AllDepenses.Clear();
        Task<List<Depense>> depenses = depenseDatabase.GetDepensesAsync();
        foreach(Depense depense in await depenses)
        {
            AllDepenses.Add(new DepenseViewModel(depense,depenseDatabase));
        }
    }
    async Task SelectDepenseAsync(DepenseViewModel? depense)
    {
        if (depense == null) return;
        await Shell.Current.DisplayAlert("Transaction Selected", $"Description: {depense.depense.Name}\nAmount: {depense.depense.Montant}", "OK");
        await Shell.Current.GoToAsync(nameof(Views.DepensePage), true, new Dictionary<string, object>
        {
            { "load", depense.depense}
        });
    }
}
