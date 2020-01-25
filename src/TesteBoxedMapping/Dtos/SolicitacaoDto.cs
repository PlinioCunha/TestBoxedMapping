using System;
using System.Collections.Generic;
using System.Text;

namespace TesteBoxedMapping.Dtos
{
   

    public class SolicitacaoDto
    {

        public Guid Id { get; set; }
        public DateTime DataHoraCriacao { get; set; }

        public string Descricao { get; set; }

        public List<SolicitacaoItemDto> Items { get; set; }

    }
}
