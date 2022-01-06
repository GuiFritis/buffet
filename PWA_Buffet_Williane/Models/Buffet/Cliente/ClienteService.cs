using PWA_Buffet_Williane.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PWA_Buffet_Williane.Models.Buffet.Evento;

namespace PWA_Buffet_Williane.Models.Buffet.Cliente
{
    public class ClienteService
    {
        private readonly DatabaseContext _databaseContext;

        public ClienteService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        
        public List<ClienteEntity> ObterClientesPFComFiltro(string filtroNome, string filtroEmail, string filtroEndereco, string filtroObservacoes, string filtroCPF)
        {
            var listaClientesPF = _databaseContext.Cliente
                .Include(c => c.Eventos)
                .Include(c => c.TipoCliente)
                .Where(c=> c.TipoCliente.Descricao.Contains("Pessoa Física"))
                .AsQueryable();

            if (filtroNome != null)
            {
                listaClientesPF = listaClientesPF.Where(c => c.Nome.Contains(filtroNome));
            }

            if (filtroEmail != null)
            {
                listaClientesPF = listaClientesPF.Where(c => c.Email.Contains(filtroEmail));
            }
            
            if (filtroEndereco != null)
            {
                listaClientesPF = listaClientesPF.Where(c => c.Endereco.Contains(filtroEndereco));
            }
            
            if (filtroObservacoes != null)
            {
                listaClientesPF = listaClientesPF.Where(c => c.Observacoes.Contains(filtroObservacoes));
            }
            
            if (filtroCPF != null)
            {
                listaClientesPF = listaClientesPF.Where(c => c.CPF.Contains(filtroCPF));
            }
            
            return listaClientesPF.ToList();
        }
        
        public List<ClienteEntity> ObterClientesPJComFiltro(string filtroNome, string filtroEmail, string filtroEndereco, string filtroObservacoes, string filtroCNPJ)
        {
            var listaClientesPJ = _databaseContext.Cliente
                .Include(c => c.Eventos)
                .Include(c => c.TipoCliente)
                .Where(c=> c.TipoCliente.Descricao.Contains("Pessoa Jurídica"))
                .AsQueryable();

            if (filtroNome != null)
            {
                listaClientesPJ = listaClientesPJ.Where(c => c.Nome.Contains(filtroNome));
            }

            if (filtroEmail != null)
            {
                listaClientesPJ = listaClientesPJ.Where(c => c.Email.Contains(filtroEmail));
            }
            
            if (filtroEndereco != null)
            {
                listaClientesPJ = listaClientesPJ.Where(c => c.Endereco.Contains(filtroEndereco));
            }
            
            if (filtroObservacoes != null)
            {
                listaClientesPJ = listaClientesPJ.Where(c => c.Observacoes.Contains(filtroObservacoes));
            }
            
            if (filtroCNPJ != null)
            {
                listaClientesPJ = listaClientesPJ.Where(c => c.CNPJ.Contains(filtroCNPJ));
            }

            return listaClientesPJ.ToList();
        }

        public bool existeCPF(Guid? id, string cpf)
        {

            var query = _databaseContext.Cliente.
                Where(c => c.CPF.Equals(cpf) && c.Id != id).ToList();

            return query.Any();
        }
        
        public bool existeCNPJ(Guid? id, string cnpj)
        {

            var query = _databaseContext.Cliente.
                Where(c => c.CNPJ.Equals(cnpj) && c.Id != id).ToList();

            return query.Any();
        }

        public TipoClienteEntity getTipoClienteByDescricao(string descricao)
        {
            var query = _databaseContext.TipoCliente
                .Where(tc => tc.Descricao.Equals(descricao));

            return query.First();
        }
        
        public ClienteEntity getClienteById(Guid? id)
        {
            var queryEvento = _databaseContext.Evento
                .Include(e => e.SituacaoEvento)
                .Include(e => e.TipoEvento)
                .Include(e => e.Local)
                .Include(e => e.Cliente)
                .Where(e => e.Cliente.Id.Equals(id));

            List<EventoEntity> eventos = queryEvento.ToList();
            
            var query = _databaseContext.Cliente
                .Include(c => c.TipoCliente)
                .Where(c => c.Id.Equals(id));

            ClienteEntity cliente = query.First();
            cliente.Eventos = eventos;

            return cliente;
        }
    }
}
