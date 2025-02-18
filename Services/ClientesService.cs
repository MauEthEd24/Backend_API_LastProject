using Domain;
using Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ClientesService
    {
        public List<Clientes> Get(string filter)
        {
            using (var contex = new APIContext())
            {
                if (filter.IsNullOrEmpty())
                {
                    return contex.Clientes.Where(x=>x.Activo==true).ToList();
                }
                else
                {
                    return contex.Clientes.Where(x => x.Nombre.Contains(filter)&& x.Activo== true).ToList();
                }
            }
        }



        public void Insert(Clientes clientes)
        {
            {
                using (var contex = new APIContext())
                {
                    contex.Clientes.Add(clientes);
                    contex.SaveChanges();

                }
            }
        }

        public void InsertConRequest(Clientes clientes)
        {

            {
                using (var contex = new APIContext())
                {
                    contex.Clientes.Add(clientes);
                    contex.SaveChanges();

                }
            }
        }

        //no se usa desde el controller
        public bool DeleteClienteLogico(int id)
        {
            try
            {
                //APIContext _context = new APIContext();

                //var clientes = _context.Clientes.Find(id);
                //clientes.Activo = false;
                //_context.SaveChanges();
                using (var contex = new APIContext())
                {
                    var clientes = contex.Clientes.Find(id);
                    clientes.Activo = false;
                    contex.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
