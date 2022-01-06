

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PWA_Buffet_Williane.Data;
using PWA_Buffet_Williane.Models.Buffet.Evento;
using PWA_Buffet_Williane.RequestModels;
using PWA_Buffet_Williane.ViewModels.Buffet.SituacaoConvidado;

namespace PWA_Buffet_Williane.Controllers.SituacaoEvento
{
    public class SituacaoEventoController : Controller
    {
        private readonly DatabaseContext _context;

        public SituacaoEventoController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: SituacaoEvento
        public async Task<IActionResult> Lista()
        {
            var viewModel = new ListaSituacaoEventoViewModel()
            {
                Situacoes = await _context.SituacaoEvento.ToListAsync()
            };

            viewModel.MsgErro = (string) TempData["msgErro"];
            viewModel.MsgSucesso = (string) TempData["msgSucesso"];
            
            return View("ListaSituacaoEvento", viewModel);
        }
        
        // GET: SituacaoEvento/Create
        public IActionResult Cadastro()
        {
            var viewModel = new CadastroSituacaoEventoViewModel();
            
            viewModel.MsgErro = (string) TempData["msgErro"];
            viewModel.MsgSucesso = (string) TempData["msgSucesso"];
            
            return View("CadastroSituacaoEvento", viewModel);
        }

        // POST: SituacaoEvento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro([Bind("Id,Descricao")] SituacaoTipoRequestModel situacao)
        {
            if (ModelState.IsValid)
            {
                var situacaoEntity = new SituacaoEventoEntity()
                {
                    Descricao = situacao.Descricao
                };
                
                if (situacao.Id == null)
                {
                    if (await new SituacaoEventoService(_context).ExisteDescricao(situacao.Descricao, ""))
                    {
                        TempData["msgErro"] = "Já existe uma situação com essa descrição!";
                        return RedirectToAction(nameof(Cadastro));
                    }
                    situacaoEntity.Id = new Guid();
                    _context.Add(situacaoEntity);
                    await _context.SaveChangesAsync();
                    TempData["msgSucesso"] = "Situação inserido com sucesso!";
                }
                else
                {
                    if (await new SituacaoEventoService(_context).ExisteDescricao(situacao.Descricao, situacao.Id))
                    {
                        TempData["msgErro"] = "Já existe uma situação com essa descrição!";
                        return RedirectToAction(nameof(Edit), new Guid(situacao.Id));
                    }

                    try
                    {
                        situacaoEntity.Id = new Guid(situacao.Id);
                        _context.Update(situacaoEntity);
                        await _context.SaveChangesAsync();
                        TempData["msgSucesso"] = "Situação alterada com sucesso!";
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SituacaoEventoEntityExists(situacaoEntity.Id))
                        {
                            TempData["msgErro"] = "Não encontramos essa situação!";
                        }
                        else
                        {
                            TempData["msgErro"] = "Ocorreu algum erro!";
                        }
                    }
                }
            }

            return RedirectToAction(nameof(Lista));
        }
        
        // GET: SituacaoEvento/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                TempData["msgErro"] = "Algum erro ocorreu!";
                return RedirectToAction(nameof(Lista));
            }

            var situacaoEntity = await _context.SituacaoEvento.FindAsync(id);
            if (situacaoEntity == null)
            {
                TempData["msgErro"] = "Não encontramos essa situação!";
                return RedirectToAction(nameof(Lista));
            }

            var viewModel = new CadastroSituacaoEventoViewModel()
            {
                Situacao = situacaoEntity
            };
            
            return View("CadastroSituacaoEvento", viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                TempData["erro"] = "Algo deu errado!";
                return RedirectToAction(nameof(Lista));
            }
            var situacao = await _context.SituacaoEvento
                .FirstOrDefaultAsync(s => s.Id == id);
            if (situacao == null)
            {
                TempData["erro"] = "Situação não encontrado!";
                return RedirectToAction(nameof(Lista));
            }
            _context.SituacaoEvento.Remove(situacao);
            await _context.SaveChangesAsync();
            TempData["sucesso"] = "Situação deletado com sucesso!";
            return RedirectToAction(nameof(Lista));
        }

        private bool SituacaoEventoEntityExists(Guid id)
        {
            return _context.SituacaoEvento.Any(e => e.Id == id);
        }
    }
}
