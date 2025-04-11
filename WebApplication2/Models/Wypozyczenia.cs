using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Wypozyczenia
{
    [Key]
    public int IdWypozyczenia { get; set; }

    [ForeignKey("Klient")]
    public int IdKlienta { get; set; }
    public Klienci Klient { get; set; }

    [ForeignKey("Rower")]
    public int IdRoweru { get; set; }
    public Rowery Rower { get; set; }

    public DateTime DataWypozyczenia { get; set; }
    public DateTime? DataZwrotu { get; set; }
    public decimal KosztWypozyczenia { get; set; }
}


