using System;
using System.Collections.Generic;
using System.Text;

namespace TesteBoxedMapping.Entities
{
    public class Solicitacao
    {

        public Guid Id { get; set; }
        public DateTime DataHoraCriacao { get; set; }

        public string Descricao { get; set; }

        public List<SolicitacaoItem> Items { get; set; }

    }
}
