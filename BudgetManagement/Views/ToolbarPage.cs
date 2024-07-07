using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace BudgetManagement.Views;

public partial class ToolbarPage : ContentPage
{
    public ICommand NewDepense { get; }
    public ICommand NewRevenu { get; }
    public ICommand NewEpargne { get; }
    public ToolbarPage()
    {
        NewDepense = new AsyncRelayCommand(GotoDepensePage);
        NewRevenu = new AsyncRelayCommand(GotoRevenuPage);
        NewEpargne = new AsyncRelayCommand(GotoEpargnePage);

        var depense = new ToolbarItem
        {
            Text = "Ajouter une dépense",
            Order = ToolbarItemOrder.Secondary,
            Command = NewDepense
        };
        var revenu = new ToolbarItem
        {
            Text = "Ajouter un revenu",
            Order = ToolbarItemOrder.Secondary,
            Command = NewRevenu
        };
        var epargne = new ToolbarItem
        {
            Text = "Ajouter une épargne",
            Order = ToolbarItemOrder.Secondary,
            Command = NewEpargne
        };
        var notification = new ToolbarItem
        {
            Text = "Notification",
            Order = ToolbarItemOrder.Default,
            IconImageSource = "notification.svg"
        };

        ToolbarItems.Add(depense);
        ToolbarItems.Add(revenu);
        ToolbarItems.Add(epargne);
        ToolbarItems.Add(notification);
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