using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PWA_Buffet_Williane.Models;
using PWA_Buffet_Williane.Models.Acesso;
using PWA_Buffet_Williane.Models.Buffet.Cliente;
using PWA_Buffet_Williane.RequestModels;
using PWA_Buffet_Williane.ViewModels.Acesso;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PWA_Buffet_Williane.Controllers
{
    public class AcessoController : Controller
    {

        private readonly AcessoService _acessoService;

        public AcessoController(AcessoService acessoService)
        {
            _acessoService = acessoService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var viewModel = new LoginViewModel();

            viewModel.ErroLogin = (string) TempData["erro-login"];
           
            return View(viewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Login(AcessoLoginRequestModel request)
        {
            var login = request.Login;
            var senha = request.Senha;

            try
            {
                await _acessoService.RealizarLogin(login, senha);

                return RedirectToRoute(new
                {
                    controller = "PainelDoUsuario",
                    action = "Index"
                });

            }
            catch (Exception exception)
            {

                TempData["erro-login"] = exception.Message;

                return RedirectToAction("Login");

            }
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            var viewModel = new CadastroViewModel();

            viewModel.ErroSenha = (string) TempData["erro-senha"];
            viewModel.ErroCadastro = (string[]) TempData["erros-cadastro"];

            return View(viewModel);
        }

        [HttpPost]
        public async Task<RedirectToActionResult> Cadastro(AcessoCadastrarRequestModel request)
        {
            var email = request.Email;
            var senha = request.Senha;
            var confirmarSenha = request.ConfirmarSenha;
  
            if ( !senha.Equals(confirmarSenha) ) {
               
                TempData["erro-senha"] = "As senhas não coincidem!";

                return RedirectToAction("Cadastro");

            }

            try
            {
                await _acessoService.RegistrarUsuario(email, senha);

                TempData["msg-cadastro"] = "Cadastro realizado com sucesso!";

                return RedirectToAction("Login");

            } catch (CadastroUsuarioException exception) {

                var listaErros = new List<string>();

                foreach (var IdentityError in exception.Erros)
                {
                    listaErros.Add(IdentityError.Description);
                }

                TempData["erros-cadastro"] = listaErros;

                return RedirectToAction("Cadastro");

            }
        }

        public IActionResult RecuperarConta()
        {
            return View();
        }
    }
}
