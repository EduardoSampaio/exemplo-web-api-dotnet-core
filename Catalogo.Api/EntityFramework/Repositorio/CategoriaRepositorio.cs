using Catalogo.Api.Entidade;
using Catalogo.Api.EntityFramework.DataSource;

namespace Catalogo.Api.EntityFramework.Repositorio
{
    public class CategoriaRepositorio : Repository<Categoria>
    {
        public CategoriaRepositorio(DataContext context) : base(context)
        {
        }
    }
}