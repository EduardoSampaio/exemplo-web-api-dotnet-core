using System.Collections.Generic;

namespace Catalogo.Api.Entidade
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Filme> Filmes { get; set; }
    }
}