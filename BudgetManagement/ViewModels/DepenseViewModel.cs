using System.ComponentModel;
using System.Windows.Input;
using BudgetManagement.Models;
using BudgetManagement.Models.Table;
using CommunityToolkit.Mvvm.Input;

namespace BudgetManagement.ViewModels;

public class DepenseViewModel : INotifyPropertyChanged, IQueryAttributable
{
    public Depense depense;
    private DepenseDatabase depenseDatabase;

    public string Name
    {
        get => depense.Name;
        set {
            if (depense.Name != value)
            {
                depense.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }
    public float Montant
    {
        get => (float)depense.Montant;
        set
        {
            if (depense.Montant != value)
            {
                depense.Montant = value;
                OnPropertyChanged(nameof(Montant));
            }
        }
    }
    public string Datetime
    {
        get => depense.Date.ToString();
    }
    public DateTime Date
    {
        get => depense.Date.Date;
        set
        {
            if (depense.Date.Date != value.Date)
            {
                depense.Date = new DateTime(value.Year, value.Month, value.Day, 
                    depense.Date.Hour, depense.Date.Minute, depense.Date.Second);
                OnPropertyChanged(nameof(Date));
            }
        }
    }
    public TimeSpan Time
    {
        get => depense.Date.TimeOfDay;
        set
        {
            if (depense.Date.TimeOfDay != value)
            {
                depense.Date = new DateTime(depense.Date.Year, depense.Date.Month, depense.Date.Day,
                    value.Hours, value.Minutes, value.Seconds);
                OnPropertyChanged(nameof(Time));
            }
        }
    }
    public string? Description
    {
        get => depense.Description;
        set
        {
            if (depense.Description != value)
            {
                depense.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
    }
    public int IdCategorie;
    
    public int DegreImportance
    {
        get
        {
            if (depense.DegreImportance == -1 || depense.DegreImportance == 0)
                return depense.DegreImportance;
            else
                return depense.DegreImportance/25;
        }
        set
        {
            if ((value == -1 || value == 0) && depense.DegreImportance != value)
            {
                depense.DegreImportance = value;
                OnPropertyChanged(nameof(DegreImportance));
            }
            else if(depense.DegreImportance != value*25)
            {
                depense.DegreImportance = value*25;
                OnPropertyChanged(nameof(DegreImportance));
            }
        }
    }

    public ICommand SaveDepense { get; }
    public ICommand DeleteDepense { get; }

    public DepenseViewModel(DepenseDatabase depenseDatabase)
    {
        this.depenseDatabase = depenseDatabase;
        depense = new()
        {
            IdCategorie = 0,
            Date = DateTime.Now
        };
        SaveDepense = new AsyncRelayCommand(Save);
        DeleteDepense = new AsyncRelayCommand(Delete);
    }
    public DepenseViewModel(Depense depense, DepenseDatabase depenseDatabase)
    {
        this.depenseDatabase = depenseDatabase;
        this.depense = depense;
        SaveDepense = new AsyncRelayCommand(Save);
        DeleteDepense = new AsyncRelayCommand(Delete);
    }

    async Task Delete()
    {
        if (depense == null) return;
        await depenseDatabase.DeleteDepenseAsync(depense);
        await Shell.Current.GoToAsync("//TDepensePage");
    }
    async Task Save()
    {
        if (depense.Montant <= 0)
            return;
        await depenseDatabase.SaveDepenseAsync(depense);
        await Shell.Current.GoToAsync("//TDepensePage");
    }

    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("load", out object obj) && obj is Depense depense)
        {
            this.depense =depense;
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
        OnPropertyChanged(nameof(IdCategorie));
        OnPropertyChanged(nameof(DegreImportance));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
