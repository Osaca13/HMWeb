using HMWeb.Biblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMWeb.Core.Servicios
{
    public class MaquinariasServicio
    {
        private readonly HMContext _context;

        public MaquinariasServicio(HMContext context)
        {
            _context = context;
        }
    }
}
