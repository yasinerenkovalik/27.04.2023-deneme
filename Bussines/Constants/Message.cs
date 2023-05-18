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
        public static string MaintenanceTime="bakım var looo";
        public static string ProductsList="ürünler listelendi";
        public static string ProductCountOfCategory = "bir kategoride en fazla 10 olabilir";
        public static string ProductNameAlreadyExists = "böyle bir ürün var";
        public static string? AuthorizationDenied="yetkiniz yok";
    }
}
