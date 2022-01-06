using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PWA_Buffet_Williane.Data;
using PWA_Buffet_Williane.Models.Buffet.Local;
using PWA_Buffet_Williane.RequestModels;
using PWA_Buffet_Williane.ViewModels;
using PWA_Buffet_Williane.ViewModels.Buffet.Local;

namespace PWA_Buffet_Williane.Controllers.Local
{
    public class LocalController : Controller
    {
        
        private readonly LocalService _localService;
        private readonly DatabaseContext _context;
        
        public LocalController(DatabaseContext context, LocalService localService)
        {
            _localService = localService;
            _context = context;
        }

        [HttpGet]
        public IActionResult ListaLocal(FiltroListagemLocais request)
        {
            var viewmodel = new LocalViewModel()
            {
                MsgSucesso = (string) TempData["MsgSucesso"],
                MsgErro = (string) TempData["MsgErro"]
            };

            var filtroDescricao = request.Descricao;
            var filtroEndereco = request.Endereco;

            var locais = _localService.ObterLocaisComFiltro(filtroDescricao, filtroEndereco);

            foreach (var local in locais)
            {
                viewmodel.ListaLocais.Add(new ViewModels.Buffet.Local.Local()
                {
                    Id = local.Id,
                    Descricao = local.Descricao,
                    Endereco = local.Endereco,
                    Eventos = local.Eventos
                });
            }

            viewmodel.Filtros = new Filtros()
            {
                Descricao = filtroDescricao,
                Endereco = filtroEndereco
            };
            
            return View("~/Views/Local/ListaLocal.cshtml", viewmodel);
        }

        [HttpGet]
        public IActionResult CadastraLocal()
        {
            var viewmodel = new LocalViewModel()
            {
                MsgSucesso = (string) TempData["MsgSucesso"],
                MsgErro = (string) TempData["MsgErro"]
            };
            
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<RedirectToActionResult> CadastraLocal(LocalCadastroRequestModel request)
        {
            var local = new LocalEntity();
            local.Descricao = request.Descricao;
            local.Endereco = request.Endereco;

            if (_localService.existeLocal(null, local.Descricao) == false)
            {
                local.Id = Guid.NewGuid();
                _context.Add(local);
                await _context.SaveChangesAsync();
                
                TempData["MsgSucesso"] = "Local cadastrado com sucesso!";

                return RedirectToAction("ListaLocal");
            }
            else
            {
                TempData["MsgErro"] = "Já existe um Local cadastrado com essa descrição!";
               
                return RedirectToAction("CadastraLocal");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Editar(Guid? id)
        {
            var viewmodel = new LocalViewModel()
            {
                MsgSucesso = (string) TempData["MsgSucesso"],
                MsgErro = (string) TempData["MsgErro"]
            };
            
            if (id == null)
            {
                return NotFound();
            }

            viewmodel.Local = _localService.getLocalById(id);
            if (viewmodel.Local == null)
            {
                return NotFound();
            }

            return View(viewmodel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Guid id, LocalViewModel localEntity)
        {
            LocalEntity local = localEntity.Local;
            
            if (id != local.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid && !_localService.existeLocal(local.Id, local.Descricao))
            {
                try
                {
                    _context.Update(local);
                    await _context.SaveChangesAsync();

                    TempData["MsgSucesso"] = "Local editado com sucesso!";

                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["MsgErro"] = "Erro ao editar Local!";
                    throw;
                }
                
                return RedirectToAction("ListaLocal");
            }
            TempData["MsgErro"] = "Já existe um local com essa descrição!";
            return RedirectToAction("Editar");
        }

        [HttpGet]
        public async Task<IActionResult> Deletar(Guid? id)
        {
            var viewmodel = new LocalViewModel()
            {
                MsgSucesso = (string) TempData["MsgSucesso"],
                MsgErro = (string) TempData["MsgErro"]
            };
            
            if (id == null)
            {
                return NotFound();
            }

            viewmodel.Local = _localService.getLocalById(id);
            if (viewmodel.Local == null)
            {
                return NotFound();
            }
            
            return View(viewmodel);
        }
        
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarDelete(Guid id)
        {
            LocalEntity local = _localService.getLocalById(id);
            
            if (local.Eventos == null || local.Eventos.Count == 0)
            {
                _context.Local.Remove(local);
                await _context.SaveChangesAsync();
                
                TempData["MsgSucesso"] = "Local deletado com sucesso!";
            }
            else
            {
                TempData["MsgErro"] = "Não é possível deletar Locais que contenham eventos associados!";
               
                return RedirectToAction("Deletar");
            }
            
            return RedirectToAction("ListaLocal");
        }

        private bool LocalEntityExists(Guid id)
        {
            return _context.Local.Any(e => e.Id == id);
        }
    }
}
