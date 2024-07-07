using SQLite;
using System.ComponentModel.DataAnnotations;

namespace BudgetManagement.Models.Table;

public class Epargne
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [Required]
    public string Objectifs {  get; set; }
    public float Montant {  get; set; }
    public float Balance { get; set; }
    public DateTime Date {  get; set; }
    public int NombreJours {  get; set; }
    public int Periode {  get; set; }
    public string? Description {  get; set; }
}
