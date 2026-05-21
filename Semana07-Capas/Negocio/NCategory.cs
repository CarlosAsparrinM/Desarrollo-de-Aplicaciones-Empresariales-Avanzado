using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NCategory
    {
        DCategory datos = new DCategory();
        public List<Category> Get()
        {
            var categories = datos.Get();

            return categories;
        }
        public Category GetById(int id)
        {
            var category = datos.Get().Where(x => x.IdCategory == id).FirstOrDefault();
            return category;
        }

        public List<Category> GetByName(string name)
        {
            var categories = datos.Get().Where(x => x.Name.Contains(name)).ToList();
            return null;
        }
    }
}