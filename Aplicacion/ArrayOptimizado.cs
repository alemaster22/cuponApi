using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CuponApi.Data.ItemProductos;

namespace CuponApi.Aplicacion
{
    public class ArrayOptimizado
    {
        public class Resultado
        {
            public float amount { get; set; }
            public string[] ids { get; set; }
        }

        public Items Optimizar(ItemPrecios inputItems, float amount)
        {
            Dictionary<string, float> items = inputItems.items;

            List<float> preciosArray = new List<float>();
            List<string> idsArrayInput = new List<string>();
            List<string> idsArrayOutPut = new List<string>();

            Items ItemsOutPut = new Items();

            Resultado result1 = new Resultado();
            Resultado result2 = new Resultado();
            Resultado result3 = new Resultado();


            Dictionary<string, float> itemsOutput = new Dictionary<string, float>();
                       
            result1 = ObtenerMax(preciosArray, idsArrayInput, idsArrayOutPut, items, amount);  // resultado items original  

            itemsOutput.Clear();

            foreach (KeyValuePair<string, float> kvp in items.OrderByDescending(key => key.Value))
            {
                itemsOutput.Add(kvp.Key, kvp.Value);
            }

            result2 = ObtenerMax(preciosArray, idsArrayInput, idsArrayOutPut, itemsOutput, amount);  // resultado descendente 

            itemsOutput.Clear();

            foreach (KeyValuePair<string, float> kvp in items.OrderBy(key => key.Value))
            {
                itemsOutput.Add(kvp.Key, kvp.Value);
            }

            result3 = ObtenerMax(preciosArray, idsArrayInput, idsArrayOutPut, itemsOutput, amount); // resultado Ascendente

            var maximo = Math.Max(result3.amount, (Math.Max(result1.amount, result2.amount)));

            if (result1.amount == maximo) {
                   ItemsOutPut.amount = result1.amount;
                   ItemsOutPut.item_ids = result1.ids;
            }
            else if (result2.amount == maximo)
            {
                ItemsOutPut.amount = result2.amount;
                ItemsOutPut.item_ids = result3.ids;
            }
            else
            {
                ItemsOutPut.amount = result3.amount;
                ItemsOutPut.item_ids = result3.ids;
            }

            return ItemsOutPut;
        }

        
        public Resultado ObtenerMax(List<float> preciosArray, List<string> idsArrayInput, List<string> idsArrayOutPut,Dictionary<string, float> items , float amount) // Método que devuelve el monto máximo e ítems luego de probar 3 formas del arreglo de entrada
        {
            preciosArray.Clear();
            idsArrayInput.Clear();
            idsArrayOutPut.Clear();

            foreach (var pair in items)
            {
                preciosArray.Add(pair.Value);
                idsArrayInput.Add(pair.Key);
            }

            float[] InputArray = preciosArray.ToArray();

            float max_sum = 0;
            float current_sum = 0;
            int n = InputArray.Length;


            for (int i = 0; i < n; i++)
            {
                current_sum = current_sum + InputArray[i];
                if (current_sum < 0 || current_sum > amount )
                {
                    current_sum = current_sum - InputArray[i];
                }
                else
                {
                    idsArrayOutPut.Add(idsArrayInput[i]);     // nuevo arreglo de productos que cumplen
                }

                if (max_sum < current_sum)
                { max_sum = current_sum; }
            }

            amount = max_sum;

            Resultado result = new Resultado();

            result.amount = amount;
            result.ids = idsArrayOutPut.ToArray();

            return result;
        }

    }
}
