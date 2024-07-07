using SQLite;
namespace BudgetManagement.Models.Table;

public class User
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string? Pseudo {  get; set; }
    public string? Password {  get; set; }
    public string? Email {  get; set; }
    public float Salaire {  get; set; }
    public float Epargne {  get; set; }
    public float Balance {  get; set; }
    public float RestantDuMois {  get; set; }
    public DateTime? LastLogin { get; set; }
    public DateTime? LastLogout { get; set; }
    public DateTime? LastLoginMonth { get; set; }
    public bool IsConnect {  get; set; }
    public float[] DaysDepenses { get; set; } = new float[31];
    public float[] DaysRevenus { get; set; } = new float[31];
    public float[] DaysEpargnes { get; set; } = new float[31];
    public float[] MonthsDepenses { get; set; } = new float[12];
    public float[] MonthsRevenus { get; set; } = new float[12];
    public float[] MonthsEpargnes { get; set; } = new float[12];
}
