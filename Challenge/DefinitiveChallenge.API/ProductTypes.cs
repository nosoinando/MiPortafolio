using DefinitiveChallenge.API.Models;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;

namespace DefinitiveChallenge.API
{
    public class ProductTypes
    {
        //public ProductTypes()
        //{
        //    Type = new string[4]
        //    {
        //        "Bienes",
        //        "Vehículos",
        //        "Apartamentos",
        //        "Terrenos"
        //    };
        //    var Bienes = Type[1];
        //    var Vehículos = Type[2];
        //    var Apartamentos = Type[3];
        //    var Terrenos = Type[4];
        //}

        //public List<string>?Type { get; set; }

        public List<string> Type = new List<string>()
        {
            "Bienes",
            "Vehículos",
            "Terrenos",
            "Apartamentos"
        };

        //public string[] Type = new string[4]
        //{
        //    "Bienes",
        //    "Vehículos",
        //    "Terrenos",
        //    "Apartamentos"
        //};

        //public void GetProductType()
        //{
        //    Type = type;
        //    Bienes.ToList();
        //    Vehículos.ToList();
        //    Apartamentos.ToList();
        //    Terrenos.ToList();
        //}

        //public void GetProductType()
        //{
        //    Type = new List<string>(4)
        //    {
        //        "Bienes","Vehículos","Apartamentos","Terrenos"
        //    };
        //    const string Bienes = Type[0];
        //    const string Vehículos = "Vehículos";
        //    const string Apartamentos = "Apartamentos";
        //    const string Terrenos = "Terrenos";
        //}

        //public ProductTypes()
        //{
        //    Type = new List<string>
        //    {
        //        "Bienes","Vehículos","Apartamentos","Terrenos"
        //    };

        //    string Bienes = Type[0];
        //    string Vehículos = Type[1];
        //    string Apartamentos = Type[2];
        //    string Terrenos = Type[3];
        //}

        //public const string Bienes = "Bienes";
        //public const string Vehículos = "Vehículos";
        //public const string Apartamentos = "Apartamentos";
        //public const string Terrenos = "Terrenos";
    }
}
