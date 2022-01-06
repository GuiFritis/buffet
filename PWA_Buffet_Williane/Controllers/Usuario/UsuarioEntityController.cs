using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PWA_Buffet_Williane.Data;
using PWA_Buffet_Williane.Models.Buffet.Cliente;

namespace PWA_Buffet_Williane.Controllers.Usuario
{
    public class UsuarioEntityController : Controller
    {
        private readonly DatabaseContext _context;

        public UsuarioEntityController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: UsuarioEntity
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        // GET: UsuarioEntity/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteEntity = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteEntity == null)
            {
                return NotFound();
            }

            return View(clienteEntity);
        }

        // GET: UsuarioEntity/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsuarioEntity/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Endereco,Observacoes,CPF,DataNasc,CNPJ,RegistroDataInsert,RegistroDataUpdate")] ClienteEntity clienteEntity)
        {
            if (ModelState.IsValid)
            {
                clienteEntity.Id = Guid.NewGuid();
                _context.Add(clienteEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteEntity);
        }

        // GET: UsuarioEntity/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteEntity = await _context.Clientes.FindAsync(id);
            if (clienteEntity == null)
            {
                return NotFound();
            }
            return View(clienteEntity);
        }

        // POST: UsuarioEntity/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Email,Endereco,Observacoes,CPF,DataNasc,CNPJ,RegistroDataInsert,RegistroDataUpdate")] ClienteEntity clienteEntity)
        {
            if (id != clienteEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteEntityExists(clienteEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clienteEntity);
        }

        // GET: UsuarioEntity/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteEntity = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteEntity == null)
            {
                return NotFound();
            }

            return View(clienteEntity);
        }

        // POST: UsuarioEntity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var clienteEntity = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(clienteEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteEntityExists(Guid id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
