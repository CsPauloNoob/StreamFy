using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamFy.Core.Modelos
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public List<Musica> Musicas { get; set; } = new List<Musica>();
    }
}
