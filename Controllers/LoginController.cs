using Microsoft.AspNetCore.Mvc;
using cadastro_contatos.Models;
using cadastro_contatos.Helper;
using cadastro_contatos.Repositorio;
using System;

namespace cadastro_contatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        private readonly IEmail _email;
        
        public LoginController(IUsuarioRepositorio usuarioRepositorio,
                               ISessao sessao,
                               IEmail email)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _email = email;
        }

        public IActionResult Index()
        {
            //caso o usuário esteja logado, redirecionar para a home

            if(_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();

            return RedirectToAction("Index","Login");
        }
    

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {   
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if(usuario != null)
                    {
                        if(usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha inválida, tente novamente";
                    }
                    TempData["MensagemErro"] = $"Email ou Senha incorretos. Tente Novamente";
                
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível realizar o seu login, tente mais tarde {erro.Message}";
                return RedirectToAction("Index");
            }  
       }
    

    [HttpPost] 
    public IActionResult EnvioLinkRedefinicao(RedefinirSenhaModel redefinirSenhaModel)
    {
        try
            {
                if(ModelState.IsValid)
                {   
                    UsuarioModel usuario = _usuarioRepositorio.BuscarEmailLogin(redefinirSenhaModel.Email,
                                                                                redefinirSenhaModel.Login);

                    if(usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        string mensagem = $"Sua nova senha é: {novaSenha}";
                        
                        bool emailEnviado = _email.Enviar(usuario.Email, "Meus Contatos - Nova Senha", mensagem);

                        if(emailEnviado)
                        {
                            _usuarioRepositorio.Atualizar(usuario);
                            TempData["MensagemSucesso"] = $"Uma nova senha foi enviada ao email cadastrado";
                        }else
                        {
                            TempData["MensagemErro"] = $"Não foi possível enviar sua nova senha. Tente novamente";
                        }
     
                        return RedirectToAction("Index", "Login");
                    }
                    TempData["MensagemErro"] = $"Não foi possível enviar o email. Verifique os dados informados";
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos enviar email com sua nova senha{erro.Message}";
                return RedirectToAction("Index");
            }  
        }
    }
}