using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuponApi.Aplicacion;
using CuponApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static CuponApi.Data.ItemProductos;



namespace CuponApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {  
        public IConfiguration Configuration { get; }

        // GET: api/<ItemsController>
        /// <summary>
        /// Método que devuelve JSON con los ítems a comprar 
        /// </summary>
        /// <param name="items"></param>        
        /// <returns>Objeto JSON con los items que tendría que comprar el usuario</returns>
        [HttpPost, Route("coupon")]
        public IActionResult  GetList(Items items)
        {            
            OptimizacionItems optimizacionItem = new OptimizacionItems();

            var result = optimizacionItem.Resultado(items);

            if (result.item_ids.Length == 0 || result.amount == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
    }
}
