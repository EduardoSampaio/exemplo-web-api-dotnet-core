namespace Catalogo.Api.Models
{
    public partial class FilmeModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public double Nota { get; set; }
        public string UrlImagem { get; set; }
        public int CategoriaId { get; set; }
        public string Categoria { get; set; }
    }

    public partial class FilmeCadastroModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public double Nota { get; set; }
        public string UrlImagem { get; set; }
        public int CategoriaId { get; set; }
    }
}