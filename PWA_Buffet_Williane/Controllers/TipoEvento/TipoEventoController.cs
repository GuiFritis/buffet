using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PWA_Buffet_Williane.Data;
using PWA_Buffet_Williane.Models.Buffet.Evento;
using PWA_Buffet_Williane.Models.Buffet.TipoEvento;
using PWA_Buffet_Williane.RequestModels;
using PWA_Buffet_Williane.ViewModels.Buffet.TipoEvento;


namespace PWA_Buffet_Williane.Controllers.TipoEvento
{
    public class TipoEventoController : Controller
    {
        private readonly TipoEventoService _tipoEventoService;
        private readonly DatabaseContext _context;

        public TipoEventoController(TipoEventoService tipoEventoService, DatabaseContext context)
        {
            _tipoEventoService = tipoEventoService;
            _context = context;
        }

        [HttpGet]
        public IActionResult ListaTiposDeEvento()
        {
            var viewmodel = new TipoEventoViewModel()
            {
                MsgSucesso = (string) TempData["MsgSucesso"],
                MsgErro = (string) TempData["MsgErro"]
            };

            var tiposDeEvento = _tipoEventoService.ObterTiposDeEvento();
            
            foreach (var tipoEvento in tiposDeEvento)
            {
                viewmodel.ListaTiposDeEvento.Add(new ViewModels.Buffet.TipoEvento.TipoEvento()
                {
                    Id = tipoEvento.Id,
                    Descricao = tipoEvento.Descricao
                });
            }
            
            return View("~/Views/TipoEvento/ListaTiposDeEvento.cshtml", viewmodel);
        }
        
        [HttpGet]
        public IActionResult CadastraTipoEvento()
        {
            var viewmodel = new TipoEventoViewModel()
            {
                MsgSucesso = (string) TempData["MsgSucesso"],
                MsgErro = (string) TempData["MsgErro"]
            };
            
            return View(viewmodel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<RedirectToActionResult> CadastraTipoEvento(TipoEventoCadastroRequestModel request)
        {
            var tipoEvento = new TipoEventoEntity();
            tipoEvento.Descricao = request.Descricao;
            
            if (ModelState.IsValid && !_tipoEventoService.existeTipoEvento(null, tipoEvento.Descricao))
            {
                tipoEvento.Id = Guid.NewGuid();
                _context.Add(tipoEvento);
                await _context.SaveChangesAsync();
                
                TempData["MsgSucesso"] = "Tipo de Evento cadastrado com sucesso!";
                
                return RedirectToAction("ListaTiposDeEvento");
            }
            else
            {
                TempData["MsgErro"] = "Já existe um Tipo de Evento cadastrado com essa descrição!";
               
                return RedirectToAction("CadastraTipoEvento");   
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> Editar(Guid? id)
        {
            var viewmodel = new TipoEventoViewModel()
            {
                MsgSucesso = (string) TempData["MsgSucesso"],
                MsgErro = (string) TempData["MsgErro"]
            };
            
            if (id == null)
            {
                return NotFound();
            }

            viewmodel.TipoEvento = await _context.TipoEvento.FindAsync(id);
            if (viewmodel.TipoEvento == null)
            {
                return NotFound();
            }
            
            return View(viewmodel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Guid id, TipoEventoViewModel tipoEventoEntity)
        {
            TipoEventoEntity tipoEvento = tipoEventoEntity.TipoEvento;
            
            if (id != tipoEvento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid && _tipoEventoService.existeTipoEvento(tipoEvento.Id, tipoEvento.Descricao) == false)
            {
                try
                {
                    _context.Update(tipoEvento);
                    await _context.SaveChangesAsync();
                    
                    TempData["MsgSucesso"] = "Tipo de Evento editado com sucesso!";
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["MsgErro"] = "Erro ao editar Tipo de Evento!";
                    throw;
                }
                
                return RedirectToAction("ListaTiposDeEvento");
            }
            TempData["MsgErro"] = "Já existe um Tipo de Evento com essa descrição!";
            return RedirectToAction("Editar");
        }

        [HttpGet]
        public async Task<IActionResult> Deletar(Guid? id)
        {
            var viewmodel = new TipoEventoViewModel()
            {
                MsgSucesso = (string) TempData["MsgSucesso"],
                MsgErro = (string) TempData["MsgErro"]
            };
            
            if (id == null)
            {
                return NotFound();
            }

            viewmodel.TipoEvento  = await _context.TipoEvento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (viewmodel.TipoEvento == null)
            {
                return NotFound();
            }

            return View(viewmodel);
        }
        
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarDelete(Guid id)
        {
            TipoEventoEntity tipoEvento =  await _context.TipoEvento.FindAsync(id);

            List<EventoEntity> eventos = _tipoEventoService.getEventosTipoEvento(id);

            if (eventos == null || eventos.Count == 0)
            {
                _context.TipoEvento.Remove(tipoEvento);
                await _context.SaveChangesAsync();
                
                TempData["MsgSucesso"] = "Tipo de Evento deletado com sucesso!";
            }
            else
            {
                TempData["MsgErro"] = "Não é possível deletar Tipos de Evento que estejam sendo utilizados em Eventos cadastrados!";
               
                return RedirectToAction("Deletar");
            }
            
            return RedirectToAction("ListaTiposDeEvento");
        }

        private bool TipoEventoEntityExists(Guid id)
        {
            return _context.TipoEvento.Any(e => e.Id == id);
        }
    }
}
