using StreamFy.Core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamFy.Core.Interfaces
{
    public interface IAutorRepository
    {
        Task<List<Autor>> RecuperarAutores(int quantidade);
    }
}
