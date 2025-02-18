using Backend_API_LastProject.Request;
using Domain;
using Infraestructure;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Backend_API_LastProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientesController : Controller
    {
        [HttpGet]
        public List<Clientes> Get(string? filter)
        {
            var service = new ClientesService();
            return service.Get(filter);
        }
        
        
        [HttpPost]
        public void InsertRequest(ClientesRequests_V1 clientesRequest)
        {
            ClientesService clientesService = new ClientesService();

            //Transformar el request a domain
            Clientes domain = new Clientes()
            {
                Nombre = clientesRequest.Nombre,
                Correo = clientesRequest.Correo,
                Telefono = clientesRequest.Telefono,
                FechaCreacion = DateTime.Now,
                Activo = true
            };
            clientesService.InsertConRequest(domain);
        }

        /*este si funciona*/
        [HttpDelete]
        public bool DeleteLogico(int id)
        {
            try
            {
                APIContext _context = new APIContext();

                var clientes = _context.Clientes.Find(id);
                clientes.Activo = false;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }



        /*PRUEBAS INICIALES DE INSERT
        [HttpPost]
        public void Insert(Clientes clientes)
        {
            var service = new ClientesService();
            service.Insert(clientes);
        }


        //por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> GetClientesPorID(int id)
        {

            using (var context = new APIContext())
            {
                var cliente = await context.Clientes.FindAsync(id);

                if (cliente == null)
                {
                    return NotFound();
                }

                return cliente;

            }

        }*/

    }
}
