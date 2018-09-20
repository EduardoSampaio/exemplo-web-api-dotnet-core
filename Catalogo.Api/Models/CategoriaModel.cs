namespace Catalogo.Api.Models
{
    public partial class CategoriaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public partial class CategoriaCadastroModel
    {
        public string Nome { get; set; }
    }
}