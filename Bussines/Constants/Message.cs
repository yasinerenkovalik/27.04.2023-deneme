using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Constants
{
    public static class Message
    {
        public static string ProductAdded = "ürün eklendi";
        public static string ProductNameInavlind = "ürün ismi geçersiz";
        internal static List<Product> MaintenanceTime;
        internal static string ProductsList="ürünler listelendi";
    }
}
