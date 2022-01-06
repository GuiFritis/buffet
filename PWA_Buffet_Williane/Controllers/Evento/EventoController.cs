using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PWA_Buffet_Williane.Data;
using PWA_Buffet_Williane.Models.Buffet.Convidado;
using PWA_Buffet_Williane.Models.Buffet.Evento;
using PWA_Buffet_Williane.Models.Buffet.Local;
using PWA_Buffet_Williane.RequestModels;
using PWA_Buffet_Williane.RequestModels.Evento;
using PWA_Buffet_Williane.ViewModels;

namespace PWA_Buffet_Williane.Controllers.Evento
{
    public class EventoController : Controller
    {
        private readonly DatabaseContext _context;

        public EventoController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Evento
        public async Task<IActionResult> ListaEvento([Bind("FiltroNome,FiltroLocal,FiltroSituacao,FiltroTipo")]FiltroEvento requestModel)
        {
            var viewModel = new ListaEventoViewModel()
            {
                Eventos = await new EventoService(_context).GetEventosFiltro(requestModel),
                Locais = await _context.Local.ToListAsync(),
                Situacao = await _context.SituacaoEvento.ToListAsync(),
                TipoEvento = await _context.TipoEvento.ToListAsync()
            };

            viewModel.MsgErro = (string) TempData["erro"];
            viewModel.MsgSucesso = (string) TempData["sucesso"];

            viewModel.FiltroEvento = requestModel;
            
            return View(viewModel);
        }
       
        // GET: Evento/Create
        public async Task<IActionResult> CadastraEvento()
        {

            var locais = await _context.Local.ToListAsync();
            var situacao = await _context.SituacaoEvento.ToListAsync();
            var tipoEvento = await _context.TipoEvento.ToListAsync();
            var clientes = await _context.Cliente.ToListAsync();
            
            var viewModel = new CadastroEventoViewModel
            {
                Locais = locais,
                Situacao = situacao,
                TipoEvento = tipoEvento,
                Clientes = clientes
            };

            viewModel.MsgErro = (string) TempData["erro"];
            viewModel.MsgSucesso = (string) TempData["sucesso"];
            
            return View(viewModel);
        }

        // POST: Evento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastraEvento([Bind("Id,Nome,Descricao,Cliente,Local,SituacaoEvento," +
                                                              "TipoEvento,DataHoraInicio,DataHoraFim,Observacoes,RegistroDataInsert,RegistroDataUpdate")] 
                                                        CadastroEventoRequestModel requestModel)
        {
            
            var evento = new EventoEntity()
            {
                Nome = requestModel.Nome,
                Descricao = requestModel.Descricao,
                Local = await _context.Local.FindAsync(new Guid(requestModel.Local)),
                SituacaoEvento = await _context.SituacaoEvento.FindAsync(new Guid(requestModel.SituacaoEvento)),
                TipoEvento = await _context.TipoEvento.FindAsync(new Guid(requestModel.TipoEvento)),
                Cliente = await _context.Cliente.FindAsync(new Guid(requestModel.Cliente)),
                Observacoes = requestModel.Observacoes,
                DataHoraInicio = requestModel.DataHoraInicio,
                DataHoraFim = requestModel.DataHoraFim,
            };
            
            if (requestModel.DataHoraInicio.CompareTo(requestModel.DataHoraFim) == 0)
            {
                TempData["erro"] = "Selecione um período de tempo!";
                if (requestModel.Id == null)
                {
                    return RedirectToAction(nameof(CadastraEvento));
                }

                return RedirectToAction(nameof(Edit), requestModel.Id);
            }
            
            if(requestModel.DataHoraInicio.CompareTo(requestModel.DataHoraFim) > 0)
            {
                TempData["erro"] = "Data de início não pode ser antes da data de fim!";
                if (requestModel.Id == null)
                {
                    return RedirectToAction(nameof(CadastraEvento));
                }

                return RedirectToAction(nameof(Edit), new Guid(requestModel.Id));
            }
            
            if (requestModel.Id == null)
            {
                if (await new EventoService(_context).DataLivre(evento))
                {
                    TempData["erro"] = "Esse local já etá ocupado nessa data!";
                    return RedirectToAction(nameof(CadastraEvento));
                }
                
                evento.Id = new Guid();
                evento.RegistroDataInsert = DateTime.Now;
                _context.Add(evento);
                await _context.SaveChangesAsync();
                TempData["sucesso"] = "Evento cadastrado com sucesso!";
            }
            else
            {
                evento.Id = new Guid(requestModel.Id);
                
                if (await new EventoService(_context).DataLivre(evento))
                {
                    TempData["erro"] = "Esse local já etá ocupado nessa data!";
                    return RedirectToAction(nameof(Edit), new Guid(requestModel.Id));
                }
                
                evento.RegistroDataInsert = requestModel.RegistroDataInsert;
                evento.RegistroDataUpdate = DateTime.Now;
                try
                {
                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                    TempData["sucesso"] = "Evento atualizado com sucesso!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoEntityExists(evento.Id))
                    {
                        TempData["erro"] = "Não encontramos esse evento!";
                    }
                    else
                    {
                        TempData["erro"] = "Ocorreu algum erro!";
                    }
                }
            }

            return RedirectToAction(nameof(ListaEvento));
        }

        // GET: Evento/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                TempData["erro"] = "Ocorreu algum erro!";
                return RedirectToAction(nameof(ListaEvento));
            }

            var eventoEntity = await _context.Evento.FindAsync(id);
            if (eventoEntity == null)
            {
                TempData["erro"] = "Evento não encontrado!";
                return RedirectToAction(nameof(ListaEvento));
            }
            
            var viewModel = new CadastroEventoViewModel
            {
                Locais = await _context.Local.ToListAsync(),
                Situacao = await _context.SituacaoEvento.ToListAsync(),
                TipoEvento = await _context.TipoEvento.ToListAsync(),
                Clientes = await _context.Cliente.ToListAsync(),
                Convidados = await new ConvidadoService(_context).GetConvidadosEvento(eventoEntity),
                EventoEntity = eventoEntity
            };
            
            viewModel.MsgErro = (string) TempData["erro"];
            viewModel.MsgSucesso = (string) TempData["sucesso"];
            
            return View("CadastraEvento", viewModel);
        }

        // POST: Evento/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                TempData["erro"] = "Algo deu errado!";
                return RedirectToAction(nameof(ListaEvento));
            }
            var eventoEntity = await _context.Evento
                .FirstOrDefaultAsync(e => e.Id == id);
            if (eventoEntity == null)
            {
                TempData["erro"] = "Evento não encontrado!";
                return RedirectToAction(nameof(ListaEvento));
            }

            new ConvidadoService(_context).DeleteConvidadosEvento(eventoEntity);
                
            _context.Evento.Remove(eventoEntity);
            await _context.SaveChangesAsync();
            TempData["sucesso"] = "Evento deletado com sucesso!";
            return RedirectToAction(nameof(ListaEvento));
        }

        private bool EventoEntityExists(Guid id)
        {
            return _context.Evento.Any(e => e.Id.Equals(id));
        }
    }
}
