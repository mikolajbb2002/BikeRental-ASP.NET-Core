using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels
{
    public class RoweryViewModel
    {
        public int IdRoweru { get; set; }
    
        public string Producent { get; set; }
        public string Nazwa { get; set; }
        public string Napęd { get; set; }
        public string Hamulce { get; set; }
        public string Amortyzacja { get; set; }
        public string RozmiarRamy { get; set; }
        public string TypRoweru { get; set; }
        public decimal Cena { get; set; }
        public string Status { get; set; }
        
    }

    }
