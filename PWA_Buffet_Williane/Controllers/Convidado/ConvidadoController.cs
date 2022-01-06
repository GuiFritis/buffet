using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PWA_Buffet_Williane.Data;
using PWA_Buffet_Williane.Models.Buffet.Cliente;
using PWA_Buffet_Williane.Models.Buffet.Convidado;
using PWA_Buffet_Williane.RequestModels.Convidado;
using PWA_Buffet_Williane.ViewModels;
using PWA_Buffet_Williane.ViewModels.Buffet.Convidado;

namespace PWA_Buffet_Williane.Controllers.Convidado
{
    public class ConvidadoController : Controller
    {
        private readonly DatabaseContext _context;

        public ConvidadoController(DatabaseContext context)
        {
            _context = context;
        }
        
        // GET: Convidado/Create
        public async Task<IActionResult> CadastraConvidado(Guid? evento)
        {
            if (evento == null)
            {
                return NotFound();
            }

            var viewModel = new CadastroConvidadoViewModel()
            {
                Evento = await _context.Evento.FindAsync(evento),
                Situacoes = await _context.SituacaoConvidado.ToListAsync()
            };
            
            viewModel.MsgErro = (string) TempData["erro"];
            viewModel.MsgSucesso = (string) TempData["sucesso"];
                
            return View(viewModel);
        }

        // POST: Convidado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastraConvidado([Bind("Id,Evento,Email,Nome,CPF,DataNasc,SituacaoConvidado," +
                                                                 "Observacoes,RegistroDataInsert,RegistroDataUpdate")] CadastroConvidadoRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                var convidado = new ConvidadoEntity()
                {
                    Evento = await _context.Evento.FindAsync(new Guid(requestModel.Evento)),
                    Nome = requestModel.Nome,
                    Email = requestModel.Email,
                    DataNasc = requestModel.DataNasc,
                    CPF = requestModel.CPF,
                    Observacoes = requestModel.Observacoes,
                    SituacaoConvidado = await _context.SituacaoConvidado.FindAsync(new Guid(requestModel.SituacaoConvidado)),
                };
                if (requestModel.Id == null)
                {
                    if (!await new ConvidadoService(_context).ExisteCpf(requestModel.CPF, new Guid(requestModel.Evento))
                    )
                    {
                        convidado.Id = new Guid();
                        convidado.RegistroDataInsert = DateTime.Now;
                        _context.Add(convidado);
                        await _context.SaveChangesAsync();
                        TempData["sucesso"] = "Convidado cadastrado com sucesso!";
                    }
                }
                else
                {
                    convidado.Id = new Guid(requestModel.Id);
                    convidado.RegistroDataUpdate = DateTime.Now;
                    try
                    {
                        _context.Update(convidado);
                        await _context.SaveChangesAsync();
                        TempData["sucesso"] = "Convidado atualizado com sucesso!";
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ConvidadoEntityExists(convidado.Id))
                        {
                            TempData["erro"] = "Não encontramos esse convidado!";
                            return RedirectToRoute(new {controller = "Evento", action = "Edit", id = new Guid(requestModel.Evento)});
                        }
                        else
                        {
                            TempData["erro"] = "Ocorreu algum erro!";
                            return RedirectToRoute(new {controller = "Evento", action = "Edit", id = new Guid(requestModel.Evento)});
                        }
                    }
                }
            }
            return RedirectToRoute(new {controller = "Evento", action = "Edit", id = new Guid(requestModel.Evento)});
        }

        // GET: Convidado/Edit/5
        public async Task<IActionResult> Edit(Guid? id, Guid? evento)
        {
            if (id == null)
            {
                TempData["erro"] = "Ocorreu algum erro!";
                return RedirectToRoute(new {controller = "Evento", action = "Edit", id = evento});
            }

            var convidadoEntity = await _context.Convidado.FindAsync(id);
            if (convidadoEntity == null)
            {
                TempData["erro"] = "Não encontramos esse convidado!";
                return RedirectToRoute(new {controller = "Evento", action = "Edit", id = evento});
            }

            convidadoEntity.Evento = await _context.Evento.FindAsync(evento);
            
            var viewModel = new CadastroConvidadoViewModel()
            {
                Evento = await _context.Evento.FindAsync(convidadoEntity.Evento.Id),
                Situacoes = await _context.SituacaoConvidado.ToListAsync(),
                Convidado = convidadoEntity
            };
            
            return View("CadastraConvidado", viewModel);
        }

        // POST: Convidado/Delete/5
        public async Task<IActionResult> Delete(Guid? id, Guid? evento)
        {
            if (id == null)
            {
                TempData["erro"] = "Ocorreu algum erro!";
                return RedirectToRoute(new {controller = "Evento", action = "Edit", id = evento});
            }
            var convidado = await _context.Convidado
                .FirstOrDefaultAsync(c => c.Id == id);
            if (convidado == null)
            {
                TempData["erro"] = "Não encontramos esse convidado!";
                return RedirectToRoute(new {controller = "Evento", action = "Edit", id = evento});
            }
            _context.Convidado.Remove(convidado);
            await _context.SaveChangesAsync();
            TempData["sucesso"] = "Convidado deletado com sucesso!";
            
            return RedirectToRoute(new {controller = "Evento", action = "Edit", id = evento});
        }

        private bool ConvidadoEntityExists(Guid id)
        {
            return _context.Convidado.Any(e => e.Id.Equals(id));
        }
    }
}
