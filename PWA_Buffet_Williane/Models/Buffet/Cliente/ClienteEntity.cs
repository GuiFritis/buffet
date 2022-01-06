using PWA_Buffet_Williane.Models.Buffet.Evento;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_Buffet_Williane.Models.Buffet.Cliente
{
    public class ClienteEntity
    {
        public ClienteEntity()
        {
            Id = new Guid();
        }

        public ClienteEntity(Guid id, string nome, string email, string endereco, string observacoes, string cpf, DateTime dataNasc, string cnpj, TipoClienteEntity tipoCliente, ICollection<EventoEntity> eventos, DateTime registroDataInsert, DateTime? registroDataUpdate)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Endereco = endereco;
            Observacoes = observacoes;
            CPF = cpf;
            DataNasc = dataNasc;
            CNPJ = cnpj;
            TipoCliente = tipoCliente;
            Eventos = eventos;
            RegistroDataInsert = registroDataInsert;
            RegistroDataUpdate = registroDataUpdate;

            if (TipoCliente.Descricao.Equals("Pessoa Física") && cpf != null & dataNasc != null)
            {
                CPF = cpf;
                DataNasc = dataNasc;
                CNPJ = null;
            }
            else
            {
                CPF = null;
                CNPJ = cnpj;
            }
        }   

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Endereco { get; set; }

        public string Observacoes { get; set; }

        [MinLength(14)]
        [MaxLength(14)]
        public string CPF { get; set; }

        [Display(Name = "Data de Nascimento")]
        
        public DateTime DataNasc { get; set; }

        [MinLength(18)]
        [MaxLength(18)]
        public string CNPJ { get; set; }
        
        [Required]
        [Display(Name = "Tipo de Cliente")]
        public TipoClienteEntity TipoCliente { get; set; }

        public ICollection<EventoEntity> Eventos { get; set; }

        [Required]
        [Display(Name = "Data de Inserção do Registro")]
        public DateTime RegistroDataInsert { get; set; }

        [Display(Name = "Data de Alteração do Registro")]
        public DateTime? RegistroDataUpdate { get; set; }       
    }
}
