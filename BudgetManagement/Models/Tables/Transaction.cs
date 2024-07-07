using SQLite;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetManagement.Models.Table;
public abstract class Transaction
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string? Name { get; set; }
    [Required]
    public float Montant {  get; set; }
    public DateTime Date { get; set; }
    public string? Description {  get; set; }
}
