using Microsoft.AspNetCore.Mvc;
using PWA_Buffet_Williane.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
using PWA_Buffet_Williane.Data;
using PWA_Buffet_Williane.Models.Acesso;
using PWA_Buffet_Williane.RequestModels;
using PWA_Buffet_Williane.ViewModels.Acesso;

namespace PWA_Buffet_Williane.Controllers
{
    public class PainelDoUsuarioController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly DatabaseContext _context;
        private readonly AcessoService _acessoService;

        public PainelDoUsuarioController(DatabaseContext context, AcessoService acessoService, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
            _acessoService = acessoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Usuario()
        {
            var viewmodel = new UsuarioViewModel()
            {
                MsgSucesso = (string) TempData["MsgSucesso"],
                MsgErro = (string) TempData["MsgErro"]
            };

            var login = HttpContext.User.Identity.Name;
            viewmodel.Usuario = await _context.Users.Where(u => u.Email.Equals(login)).FirstAsync();

            var queryHistorico = _context.HistoricoLogin
                    .Include(h=> h.Usuario)
                    .Where(h => h.Usuario.Id.Equals(viewmodel.Usuario.Id)
                    ).OrderByDescending(h => h.DataHoraLogin);

            List<HistoricoLoginEntity> historicos = queryHistorico.ToList();
            
            viewmodel.HistoricoLoginUser = historicos;

            return View(viewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> Atualizar(AtualizarSenhaRequestModel request)
        {
            var viewmodel = new UsuarioViewModel()
            {
                MsgSucesso = (string) TempData["MsgSucesso"],
                MsgErro = (string) TempData["MsgErro"]
            };
            
            var login = HttpContext.User.Identity.Name;
            
            var user = await _context.Users.Where(u => u.Email.Equals(login)).FirstAsync();
            
            if(request.Senha.Equals(request.ConfirmaSenha))
            {
                await _userManager.ChangePasswordAsync(user, request.SenhaAtual, request.Senha);
                _context.Update(user);
                await _context.SaveChangesAsync();
                
                TempData["MsgSucesso"] = "Senha atualizada com sucesso!";
            }
            else
            {
                TempData["MsgErro"] = "As senhas não coincidem!";
            }

            viewmodel.Usuario = user;
            
            var queryHistorico = _context.HistoricoLogin
                .Include(h=> h.Usuario)
                .Where(h => h.Usuario.Id.Equals(viewmodel.Usuario.Id)
                ).OrderByDescending(h => h.DataHoraLogin);

            List<HistoricoLoginEntity> historicos = queryHistorico.ToList();
            
            viewmodel.HistoricoLoginUser = historicos;
            
            return RedirectToAction("Usuario", viewmodel);
        }
    }
}
