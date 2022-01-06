using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PWA_Buffet_Williane.Data;
using PWA_Buffet_Williane.Models.Buffet.Cliente;
using PWA_Buffet_Williane.RequestModels;
using PWA_Buffet_Williane.ViewModels;
using PWA_Buffet_Williane.ViewModels.Buffet.Cliente;

namespace PWA_Buffet_Williane.Controllers.Cliente
{
    public class ClienteController : Controller
    {
        private readonly ClienteService _clienteService;
        private readonly DatabaseContext _context;

        public ClienteController(DatabaseContext context, ClienteService clienteService)
        {
            _clienteService = clienteService;
            _context = context;
        }

        [HttpGet]
        public IActionResult ListaCliente(FiltroListagemClientes request)
        {
            var viewmodel = new ClienteViewModel()
            {
                MsgSucesso = (string) TempData["MsgSucesso"],
                MsgErro = (string) TempData["MsgErro"]
            };
           
            var filtroNome = request.Nome;
            var filtroEmail = request.Email;
            var filtroEndereco = request.Endereco;
            var filtroObservacoes = request.Observacoes;
            var filtroCPF = request.CPF;
            var filtroDataNasc = request.DataNasc;
            var filtroCNPJ = request.CNPJ;
            
            var clientesPF = _clienteService.ObterClientesPFComFiltro(filtroNome, filtroEmail, filtroEndereco, filtroObservacoes, filtroCPF);

            foreach (var clientePF in clientesPF)
            {
                viewmodel.ListaClientesPF.Add(new ViewModels.Buffet.Cliente.ClientePF()
                {
                    Id = clientePF.Id.ToString(),
                    Nome = clientePF.Nome,
                    Email = clientePF.Email,
                    Endereco = clientePF.Endereco,
                    Observacoes = clientePF.Observacoes,
                    CPF = clientePF.CPF,
                    DataNasc = clientePF.DataNasc,
                    Eventos = clientePF.Eventos,
                });
            }
            
            var clientesPJ = _clienteService.ObterClientesPJComFiltro(filtroNome, filtroEmail, filtroEndereco, filtroObservacoes, filtroCNPJ);

            foreach (var clientePJ in clientesPJ)
            {
                viewmodel.ListaClientesPJ.Add(new ViewModels.Buffet.Cliente.ClientePJ()
                {
                    Id = clientePJ.Id.ToString(),
                    Nome = clientePJ.Nome,
                    Email = clientePJ.Email,
                    Endereco = clientePJ.Endereco,
                    Observacoes = clientePJ.Observacoes,
                    CNPJ = clientePJ.CNPJ,
                    Eventos = clientePJ.Eventos,
                });
            }

            viewmodel.Filtros = new Filtros()
            {
                Nome = filtroNome, 
                Email = filtroEmail, 
                Endereco = filtroEndereco, 
                Observacoes = filtroObservacoes,
                CPF = filtroCPF,
                CNPJ = filtroCNPJ
            };
            
            return View("~/Views/Cliente/ListaCliente.cshtml", viewmodel);
        }
        
        [HttpGet]
        public IActionResult CadastraCliente()
        {
            var viewmodel = new ClienteViewModel()
            {
                MsgSucesso = (string) TempData["MsgSucesso"],
                MsgErro = (string) TempData["MsgErro"]
            };
            
            return View(viewmodel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastraCliente(ClienteCadastroRequestModel request)
        {
            var cliente = new ClienteEntity();
            cliente.Nome = request.Nome;
            cliente.Endereco = request.Endereco;
            cliente.Email = request.Email;
            cliente.Observacoes = request.Observacoes;
            cliente.DataNasc = request.DataNasc;
            cliente.TipoCliente = _clienteService.getTipoClienteByDescricao(request.TipoCliente);
            cliente.CPF = request.CPF;
            cliente.CNPJ = request.CNPJ;
            
            if(cliente.TipoCliente.Descricao.Equals("Pessoa Física"))
            {
                if(_clienteService.existeCPF(null, cliente.CPF) == false)
                {
                    cliente.Id = Guid.NewGuid();
                    cliente.RegistroDataInsert = DateTime.Now;
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                    
                    TempData["MsgSucesso"] = "Cliente cadastrado com sucesso!";
                    
                    return RedirectToAction("ListaCliente");
                }
                else
                {
                    TempData["MsgErro"] = "Já existe um Cliente cadastrado para esse CPF!";
                    
                    return RedirectToAction("CadastraCliente");
                }
            } else
            {
                if(_clienteService.existeCNPJ(null, cliente.CNPJ) == false)
                {
                    cliente.Id = Guid.NewGuid();
                    cliente.RegistroDataInsert = DateTime.Now;
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                    
                    TempData["MsgSucesso"] = "Cliente cadastrado com sucesso!";
                    
                    return RedirectToAction("ListaCliente");
                }
                else
                {
                    TempData["MsgErro"] = "Já existe um Cliente cadastrado para esse CNPJ!";
                    
                    return RedirectToAction("CadastraCliente");
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Editar(Guid? id)
        {
            var viewmodel = new ClienteViewModel()
            {
                MsgSucesso = (string) TempData["MsgSucesso"],
                MsgErro = (string) TempData["MsgErro"]
            };
            
            if (id == null)
            {
                return NotFound();
            }

            viewmodel.Cliente = _clienteService.getClienteById(id);
            if (viewmodel.Cliente == null)
            {
                return NotFound();
            }
            
            return View(viewmodel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Guid id, ClienteViewModel clienteEntity)
        {
            ClienteEntity cliente = _clienteService.getClienteById(id);
            cliente.Nome = clienteEntity.Cliente.Nome;
            cliente.Email = clienteEntity.Cliente.Email;
            cliente.Endereco = clienteEntity.Cliente.Endereco;
            cliente.Observacoes = clienteEntity.Cliente.Observacoes;
            cliente.CPF = clienteEntity.Cliente.CPF;
            cliente.DataNasc = clienteEntity.Cliente.DataNasc;
            cliente.CNPJ = clienteEntity.Cliente.CNPJ;
            
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (cliente.TipoCliente.Descricao.Equals("Pessoa Física"))
            {
                if (!_clienteService.existeCPF(cliente.Id, cliente.CPF))
                {
                    try
                    {
                        cliente.RegistroDataUpdate = DateTime.Now;
                        _context.Update(cliente);
                        await _context.SaveChangesAsync();

                        TempData["MsgSucesso"] = "Cliente editado com sucesso!";
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        TempData["MsgErro"] = "Erro ao editar Cliente!";
                        throw;
                    }

                    return RedirectToAction("ListaCliente");
                }
                else
                {
                    TempData["MsgErro"] = "Já existe um cliente com esse CPF!";
                    return RedirectToAction("Editar");
                }
            } else {
                if (!_clienteService.existeCNPJ(cliente.Id, cliente.CNPJ))
                {
                    try
                    {
                        cliente.RegistroDataUpdate = DateTime.Now;
                        _context.Update(cliente);
                        await _context.SaveChangesAsync();

                        TempData["MsgSucesso"] = "Cliente editado com sucesso!";
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        TempData["MsgErro"] = "Erro ao editar Cliente!";
                        throw;
                    }

                    return RedirectToAction("ListaCliente");
                }
                else
                {
                    TempData["MsgErro"] = "Já existe um cliente com esse CNPJ!";
                    return RedirectToAction("Editar");
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Deletar(Guid? id)
        {
            var viewmodel = new ClienteViewModel()
            {
                MsgSucesso = (string) TempData["MsgSucesso"],
                MsgErro = (string) TempData["MsgErro"]
            };
            
            if (id == null)
            {
                return NotFound();
            }

            viewmodel.Cliente = _clienteService.getClienteById(id);
            if (viewmodel.Cliente == null)
            {
                return NotFound();
            }
            
            return View(viewmodel);
        }
        
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarDelete(Guid id)
        {
            ClienteEntity cliente = _clienteService.getClienteById(id);
            
            if (cliente.Eventos == null || cliente.Eventos.Count == 0)
            {
                _context.Cliente.Remove(cliente);
                await _context.SaveChangesAsync();
                
                TempData["MsgSucesso"] = "Cliente deletado com sucesso!";
            } 
            else
            {
                TempData["MsgErro"] = "Não é possível deletar Clientes que contenham eventos associados!";
                
                return RedirectToAction("Deletar");
            }
            
            return RedirectToAction("ListaCliente");
        }

        private bool ClienteEntityExists(Guid id)
        {
            return _context.Cliente.Any(e => e.Id == id);
        }
    }
}
