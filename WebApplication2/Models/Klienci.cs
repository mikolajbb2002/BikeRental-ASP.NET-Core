namespace WebApplication2.Models;

using System.ComponentModel.DataAnnotations;

public class Klienci
{
    [Key]
    public int IdKlienta { get; set; }
    
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
    public string Telefon { get; set; }
    
    public ICollection<Wypozyczenia> Wypozyczenia { get; set; }
}
