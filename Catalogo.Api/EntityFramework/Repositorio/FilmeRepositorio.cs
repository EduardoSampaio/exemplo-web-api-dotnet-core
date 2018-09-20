using Catalogo.Api.Entidade;
using Catalogo.Api.EntityFramework.DataSource;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace Catalogo.Api.EntityFramework.Repositorio
{
    public class FilmeRepositorio : Repository<Filme>
    {
        public FilmeRepositorio(DataContext context) : base(context)
        {

        }

        public IList<Filme> BuscarFilmesComCategoria() {
            return Db.Filme
                .Include(x => x.Categoria)
                .Where(x => x.CategoriaId.Equals(x.Categoria.Id))
                .ToList();
        }
    }
}