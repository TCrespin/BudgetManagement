using System.ComponentModel;
using System.Windows.Input;
using BudgetManagement.Models;
using BudgetManagement.Models.Table;
using CommunityToolkit.Mvvm.Input;

namespace BudgetManagement.ViewModels;

public class RevenuViewModel : INotifyPropertyChanged, IQueryAttributable
{
    public Revenu revenu;
    private RevenuDatabase revenuDatabase;

    public string Name
    {
        get => revenu.Name;
        set
        {
            if (revenu.Name != value)
            {
                revenu.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }
    public float Montant
    {
        get => (float)revenu.Montant;
        set
        {
            if (revenu.Montant != value)
            {
                revenu.Montant = value;
                OnPropertyChanged(nameof(Montant));
            }
        }
    }
    public string Datetime
    {
        get => revenu.Date.ToString();
    }
    public DateTime Date
    {
        get => revenu.Date.Date;
        set
        {
            if (revenu.Date.Date != value.Date)
            {
                revenu.Date = new DateTime(value.Year, value.Month, value.Day,
                    revenu.Date.Hour, revenu.Date.Minute, revenu.Date.Second);
                OnPropertyChanged(nameof(Date));
            }
        }
    }
    public TimeSpan Time
    {
        get => revenu.Date.TimeOfDay;
        set
        {
            if (revenu.Date.TimeOfDay != value)
            {
                revenu.Date = new DateTime(revenu.Date.Year, revenu.Date.Month, revenu.Date.Day,
                    value.Hours, value.Minutes, value.Seconds);
                OnPropertyChanged(nameof(Time));
            }
        }
    }
    public string? Description
    {
        get => revenu.Description;
        set
        {
            if (revenu.Description != value)
            {
                revenu.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
    }

    public ICommand SaveRevenu { get; }
    public ICommand DeleteRevenu { get; }

    public RevenuViewModel(RevenuDatabase revenuDatabase)
    {
        this.revenuDatabase = revenuDatabase;
        revenu = new()
        {
            Date = DateTime.Now
        };
        SaveRevenu = new AsyncRelayCommand(Save);
        DeleteRevenu = new AsyncRelayCommand(Delete);
    }
    public RevenuViewModel(Revenu revenu, RevenuDatabase revenuDatabase)
    {
        this.revenuDatabase = revenuDatabase;
        this.revenu = revenu;
        SaveRevenu = new AsyncRelayCommand(Save);
        DeleteRevenu = new AsyncRelayCommand(Delete);
    }

    async Task Delete()
    {
        if (revenu == null) return;
        await revenuDatabase.DeleteRevenuAsync(revenu);
        await Shell.Current.GoToAsync("//TRevenuPage");
    }
    async Task Save()
    {
        if (revenu.Montant <= 0)
            return;
        await revenuDatabase.SaveRevenuAsync(revenu);
        await Shell.Current.GoToAsync("//TRevenuPage");
    }

    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("load", out object obj) && obj is Revenu revenu)
        {
            this.revenu = revenu;
            RefreshProperties();
        }
    }

    private void RefreshProperties()
    {
        OnPropertyChanged(nameof(Name));
        OnPropertyChanged(nameof(Montant));
        OnPropertyChanged(nameof(Datetime));
        OnPropertyChanged(nameof(Date));
        OnPropertyChanged(nameof(Time));
        OnPropertyChanged(nameof(Description));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
