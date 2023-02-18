using ClothingShop.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShop.ClassHelper
{
    public class EFClass
    {
        public static ClothingStoreEntities Context { get; } = new ClothingStoreEntities();
    }
}
