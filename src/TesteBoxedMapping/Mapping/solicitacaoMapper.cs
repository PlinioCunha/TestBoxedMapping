using Boxed.Mapping;
using TesteBoxedMapping.Dtos;
using TesteBoxedMapping.Entities;
using TesteBoxedMapping.Mapping.Interfaces;

namespace TesteBoxedMapping.Mapping
{
    public class SolicitacaoMapper : ISolicitacaoMapper
    {
        private readonly IMapper<SolicitacaoItem, SolicitacaoItemDto> solicitacaoItemMapper;

        public SolicitacaoMapper(IMapper<SolicitacaoItem, SolicitacaoItemDto> solicitacaoItemMapper) => this.solicitacaoItemMapper = solicitacaoItemMapper;

        public void Map(Solicitacao source, SolicitacaoDto destination)
        {
            destination.DataHoraCriacao = source.DataHoraCriacao;
            destination.Id = source.Id;
            destination.Items = solicitacaoItemMapper.MapList(source.Items);
        }

    }

    public class SolicitacaoItemMapper : IMapper<SolicitacaoItem, SolicitacaoItemDto>
    {
        public void Map(SolicitacaoItem source, SolicitacaoItemDto destination)
        {
            destination.Codigo = source.Codigo;
            destination.Descricao = source.Descricao;
            destination.Id = source.Id;
        }
    }

}
