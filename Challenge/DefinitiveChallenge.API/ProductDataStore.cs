using DefinitiveChallenge.API.Models;
using System.Linq;

namespace DefinitiveChallenge.API
{
    public class ProductDataStore 
    {
        public List<ProductDto>Productos { get; set; }
        //public static ProductDataStore Current { get; } = new ProductDataStore();
        public ProductDataStore()
        {
            Productos = new List<ProductDto>()
            {
                new ProductDto()
                {
                    Id = 1,
                    Description = "Automovil Twingo",
                    Type =  "Vehículos",
                    Value = 20000000.00,
                    BuyDate = new DateTime(2022, 3, 28),
                    State = true
                },

                new ProductDto()
                {
                    Id = 2,
                    Description = "Finca con piscina, salón de juegos, patio, cuarto de cocina, cuarto de ropas y 8 habitaciones",
                    Type = "Terrenos",
                    Value = 400000000.00,
                    BuyDate = new DateTime(2022, 3, 28),
                    State = false
                },

                new ProductDto()
                {
                    Id = 3,
                    Description = "Telefono móvil iphone 14",
                    Type = "Bienes",
                    Value = 5487599.99,
                    BuyDate = new DateTime(2022, 3, 28),
                    State = true
                },
            };   
        }
        //public void AddProduct(ProductDto newProduct)
        //{
        //    Productos.Add(newProduct);
        //}
    }

}
