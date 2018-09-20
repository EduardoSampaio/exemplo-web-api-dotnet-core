using Catalogo.Api.Entidade;
using Catalogo.Api.EntityFramework.DataSource;
using Catalogo.Api.EntityFramework.Repositorio;
using Catalogo.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace Catalogo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class CatalogoController : Controller
    {
        private readonly DataContext _context;
        private readonly FilmeRepositorio _filmeRepositorio;
        private readonly CategoriaRepositorio _categoriaRepositorio;

        public CatalogoController()
        {
            _context = new DataContext();
            _filmeRepositorio = new FilmeRepositorio(_context);
            _categoriaRepositorio = new CategoriaRepositorio(_context);
        }

        #region Filmes

        [HttpGet]
        [Route("Filmes/{id}")]
        public IActionResult BuscarFilmesPorId(int id)
        {
            var filme = _filmeRepositorio.Find(id);
            var model = new FilmeModel()
            {
                Id = filme.Id,
                Ano = filme.Ano,
                Descricao = filme.Descricao,
                Nota = filme.Nota,
                Titulo = filme.Titulo,
                UrlImagem = filme.UrlImagem
            };

            return Json(new HandlerMessage(HttpStatusCode.OK, "", model));
        }

        [HttpGet]
        [Route("Filmes")]
        public IActionResult BuscarTodosFilmes()
        {
            var filmes = _filmeRepositorio.BuscarFilmesComCategoria();
            var lista = new List<FilmeModel>();

            foreach (var filme in filmes)
            {
                var model = new FilmeModel()
                {
                    Id = filme.Id,
                    Ano = filme.Ano,
                    Descricao = filme.Descricao,
                    Nota = filme.Nota,
                    Titulo = filme.Titulo,
                    UrlImagem = filme.UrlImagem,
                    CategoriaId = filme.CategoriaId,
                    Categoria = filme.Categoria.Nome
                    
                };

                lista.Add(model);
            }

            return Json(new HandlerMessage(HttpStatusCode.OK,"",lista));
        }

        [HttpPost]
        [Route("Filmes")]
        public IActionResult SalvarFilmes(FilmeCadastroModel model)
        {
            try
            {
                var filme = new Filme()
                {
                    Ano = model.Ano,
                    Descricao = model.Descricao,
                    Nota = model.Nota,
                    Titulo = model.Titulo,
                    UrlImagem = model.UrlImagem,
                    CategoriaId = model.CategoriaId
                    
                };

                _filmeRepositorio.Add(filme);
                _filmeRepositorio.SaveChanges();
                return Json(new HandlerMessage(HttpStatusCode.OK, "Salvo com sucesso!", filme));
            }
            catch (Exception ex)
            {
                return Json(new HandlerMessage(HttpStatusCode.BadRequest, $"Erro ao salvar {ex.Message}"));
            }
        }

        [HttpPut]
        [Route("Filmes")]
        public IActionResult AtualizarFilmes(FilmeModel model)
        {
            var filme = _filmeRepositorio.Find(model.Id);
            filme.Nota = model.Nota;
            filme.Titulo = model.Titulo;
            filme.UrlImagem = model.UrlImagem;
            filme.Ano = model.Ano;
            filme.Descricao = model.Descricao;
            filme.CategoriaId = model.CategoriaId;

            try
            {
                _filmeRepositorio.Update(filme);
                _filmeRepositorio.SaveChanges();
                return Json(new HandlerMessage(HttpStatusCode.OK, "Atualizado com sucesso!", filme));
            }
            catch (Exception ex)
            {
                return Json(new HandlerMessage(HttpStatusCode.BadRequest, $"Erro ao Atualizar {ex.Message}"));
            }
        }

        [HttpDelete]
        [Route("Filmes")]
        public IActionResult RemoverFilmes(int id)
        {
            try
            {
                _filmeRepositorio.Remove(id);
                _filmeRepositorio.SaveChanges();
                return Json(new HandlerMessage(HttpStatusCode.OK, "Removido com sucesso!"));
            }
            catch (Exception ex)
            {
                return Json(new HandlerMessage(HttpStatusCode.BadRequest, $"Erro ao Remover {ex.Message}"));
            }
        }

        #endregion Filmes

        #region Categoria

        [HttpGet]
        [Route("Categoria/{id}")]
        public IActionResult BuscarCategoriaPorId(int id)
        {
            var categoria = _categoriaRepositorio.Find(id);

            var model = new CategoriaModel()
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            };

            return Json(model);
        }

        [HttpGet]
        [Route("Categoria")]
        public IActionResult BuscarTodasCategorias()
        {
            var categorias = _categoriaRepositorio.FindAll();
            var lista = new List<CategoriaModel>();

            foreach (var categoria in categorias)
            {
                var model = new CategoriaModel()
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome
                };

                lista.Add(model);
            }
            return Json(lista);
        }

        [HttpDelete]
        [Route("Categoria")]
        public IActionResult RemoverCategoria(int id)
        {
            try
            {
                _categoriaRepositorio.Remove(id);
                _categoriaRepositorio.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpPost]
        [Route("Categoria")]
        public IActionResult SalvarCategoria(CategoriaCadastroModel model)
        {
            try
            {
                var categoria = new Categoria()
                {
                    Nome = model.Nome
                };

                _categoriaRepositorio.Add(categoria);
                _categoriaRepositorio.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Categoria")]
        public IActionResult AtaualizarCategoria(CategoriaModel model)
        {
            var entidade = _categoriaRepositorio.Find(model.Id);
            entidade.Nome = model.Nome;

            try
            {
                _categoriaRepositorio.Update(entidade);
                _categoriaRepositorio.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion Categoria
    }
}