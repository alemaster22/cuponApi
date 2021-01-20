using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CuponApi.Data.ItemProductos;

namespace CuponApi.Aplicacion
{
    public class OptimizacionItems
    {
        public OptimizacionItems( )
        {
            
        }        

        public Items Resultado(Items items)
        {
            Dictionary<string, float> itemsOptimizar = new Dictionary<string, float>();


            HashSet<string> idSinRepetir = new HashSet<string>();


            foreach(string idItem in items.item_ids)
            {
                idSinRepetir.Add(idItem);
            }

            foreach (string id in idSinRepetir)
            {
                var client = new RestClient("https://api.mercadolibre.com/items/");

                var request = new RestRequest(id, Method.GET);

                var result = client.Execute(request);

                if (result.StatusCode.ToString() != "OK" && result.StatusCode.ToString() !=  "NotFound")
                {
                    throw new Exception("url resource https://api.mercadolibre.com/items/ unavaliable");
                }

                var producto = JsonConvert.DeserializeObject<Productos>(result.Content);

                if (producto.id != null && producto.price <= items.amount) itemsOptimizar.Add(id, producto.price);    // Excluye productos inexistentes y con precio mayor al monto posible
            }

            ArrayOptimizado Optimizado = new ArrayOptimizado();

            ItemPrecios ItemPrecios = new ItemPrecios();


            ItemPrecios.items  = itemsOptimizar;
            ItemPrecios.amount = items.amount;

            return Optimizado.Optimizar(ItemPrecios, items.amount); 
        }
    }
}
