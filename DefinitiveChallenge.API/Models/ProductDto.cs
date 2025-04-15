using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DefinitiveChallenge.API.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }       
        public string?Type { get; set; }
        public double Value { get; set; }
        public DateTime BuyDate { get; set; }
        public bool State { get; set; }
    }
}
