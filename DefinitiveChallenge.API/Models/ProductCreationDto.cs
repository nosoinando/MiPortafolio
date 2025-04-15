using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DefinitiveChallenge.API.Models
{
    public class ProductCreationDto
    {
        [Required(ErrorMessage = "Es necesaria una descripción del producto.")]
        [StringLength(150)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Porfavor específique el tipo de producto ('Bienes', 'Vehículos', 'Terrenos' o 'Apartamentos').")]
        //public List<string>?Type { get; set; }

        public string? Type { get; set; }

        [Required(ErrorMessage = "Porfavor del un valor al producto.")]
        [Range (50.00, 1000000000.00, ErrorMessage = "El precio del producto debe estar entre $50.00 pesos y $1.000'000.000 de pesos.")]
        [DisplayFormat(DataFormatString ="{0:c}")]
        public double Value { get; set; }

        [Required(ErrorMessage = "Es requerido que específique cuando se compro el producto.")]
        [DataType(DataType.Date)]
        public DateTime BuyDate { get; set; }

        [Required(ErrorMessage = "Es necesario que mencione si el estado del producto se encuentra 'Activo' escriba 'true', si se encuentra 'Inactivo' escriba 'false'.")]
        public bool State { get; set; }
        
       

        //public bool State (string state)
        //{   
        //    if(state == "Activo")
        //    {
        //        return true;
        //    }
        //    else if (state == "Inactivo")
        //    {
        //        return true;
        //    }
        //    throw new Exception("Ingrese un estado del producto válido, ejemplo: 'Activo','Inactivo'");
            
        //}
    }
}
