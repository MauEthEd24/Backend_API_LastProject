using Backend_API_LastProject.Request;
using Domain;
using Infraestructure;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Backend_API_LastProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductosController : Controller
    {
        [HttpGet]
        public List<Productos> Get(string? filter)
        {
            var service = new ProductosServices();
            return service.Get(filter);
        }
        //[HttpPost]
        //public void Insert(Productos productos)
        //{
        //    var service = new ProductosServices();
        //    service.Insert(productos);
        //}

        [HttpPost]
        public void InsertRequest(ProductosRequests_V1 productosRequest)
        {
            ProductosServices productosService = new ProductosServices();

            //Transformar el request a domain
            Productos domain = new Productos()
            {
                Nombre = productosRequest.Nombre,
                Precio = productosRequest.Precio,
                Stock = productosRequest.Stock,
                FechaCreacion = DateTime.Now,
                Activo = true
            };
            productosService.InsertConRequest(domain);
        }


        [HttpDelete]
        public bool DeleteLogico(int id)
        {
            try
            {
                APIContext _context = new APIContext();

                var productos = _context.Productos.Find(id);
                productos.Activo = false;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
