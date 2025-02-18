using Domain;
using Infraestructure;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductosServices
    {
        public List<Productos> Get(string filter)
        {
            using (var contex = new APIContext())
            {
                if (filter.IsNullOrEmpty())
                {
                    return contex.Productos.Where(x => x.Activo == true).ToList();
                }
                else
                {
                    return contex.Productos.Where(x => x.Nombre.Contains(filter) && x.Activo == true).ToList();
                }
            }
        }

        public void Insert(Productos productos)
        {
            {
                using (var contex = new APIContext())
                {
                    contex.Productos.Add(productos);
                    contex.SaveChanges();

                }
            }
        }

        public void InsertConRequest(Productos productos)
        {
            {
                using (var contex = new APIContext())
                {
                    contex.Productos.Add(productos);
                    contex.SaveChanges();

                }
            }
        }
    }
}
