using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuponApi.Data
{
    public class ItemProductos

    {
        public class Items
        {
            public string[] item_ids { get; set; }
            
            public float amount { get; set; }
        }
        
        public class Productos
        {
            public string id { get; set; }
            public float price { get; set; }
        }

        public class ItemPrecios
        {
            public Dictionary<string, float> items { get; set; } 
            public float amount { get; set; }
        }
    }


}
