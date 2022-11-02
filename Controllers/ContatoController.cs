using Microsoft.AspNetCore.Mvc;
using cadastro_contatos.Models;
using cadastro_contatos.Repositorio;
using System;
using System.Collections.Generic;
using cadastro_contatos.Filters;

namespace cadastro_contatos.Controllers
{
    [PaginaLogada]
    public class ContatoController : Controller
    {
        //string de ligacão de interface com controlador
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        //Controle da página Contatos/Index e suas funções
        public IActionResult Index()
        {
           List<ContatoModel> contatosLista = _contatoRepositorio.BuscarTodos();
            return View(contatosLista);
        }

        //Controle da página Adicionar contato e suas funções
        public IActionResult Adicionar()
        {
            return View();
        }

        //Controle da página Editar contato e suas funções
        public IActionResult Editar(int id)
        {
            ContatoModel contatoEditar =  _contatoRepositorio.ListarPorId(id);
            return View(contatoEditar);
        }

        //Controle da página Confirmar Exclus4ao contato e suas funções
        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contatoApagar =  _contatoRepositorio.ListarPorId(id);
            return View(contatoApagar);
        }

        //Controle da exclusão do contato e suas funções do BD
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato excluído com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos excluir o contato selecionado!";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos excluir o contato selecionado, detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        //Inclusão de novo contato no BD
        [HttpPost]
        public IActionResult Adicionar(ContatoModel contato)
        {
             try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);

                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception erro)
            { 
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        //Edição de contato no BD
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
             try
             {
                if(ModelState.IsValid)
                {
                    _contatoRepositorio.Alterar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);
             }
             catch (System.Exception erro)
             {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar seu contato, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
             }
        }
    }
}