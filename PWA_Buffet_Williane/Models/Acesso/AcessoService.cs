using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;
using PWA_Buffet_Williane.Data;

namespace PWA_Buffet_Williane.Models.Acesso
{
    public class AcessoService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public AcessoService(DatabaseContext databaseContext, UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager)
        {
            _databaseContext = databaseContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task RegistrarUsuario(string email, string senha)
        {
            var newUser = new Usuario()
            {
                UserName = email,
                Email = email
            };

            var resultado = await _userManager.CreateAsync(newUser, senha);

            if (!resultado.Succeeded)
            {
                throw new CadastroUsuarioException(resultado.Errors);
            }
        }

        public async Task RealizarLogin(string login, string senha)
        {
            await VerificarLogin(login);

            var resultado = await _signInManager.PasswordSignInAsync(login, senha, false, false);

            if (!resultado.Succeeded)
            {
                throw new Exception("Senha incorreta.");
            }

            await GravarHistorico(login);
        }

        public async Task VerificarLogin(string login)
        {
            var user = await _userManager.FindByEmailAsync(login);

            if (user == null)
            {
                throw new Exception("Esse login está incorreto ou não existe.");
            }
        }

        public async Task GravarHistorico(string login)
        {
            var user = _userManager.FindByEmailAsync(login);

            var historico = new HistoricoLoginEntity();
            historico.Id = Guid.NewGuid();
            historico.Usuario = user.Result;
            historico.DataHoraLogin = DateTime.Now;

            _databaseContext.Add(historico);
            await _databaseContext.SaveChangesAsync();

        }
    }
}
