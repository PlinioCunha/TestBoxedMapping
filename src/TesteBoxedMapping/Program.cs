using Boxed.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using TesteBoxedMapping.Dtos;
using TesteBoxedMapping.Entities;
using TesteBoxedMapping.Mapping;
using TesteBoxedMapping.Mapping.Interfaces;

namespace TesteBoxedMapping
{
    class Program
    {

        private static ISolicitacaoMapper solicitacaoMapper;

        static void Main(string[] args)
        {
            RegisterDependency();

            var solicitacao = CriarSolicitacao();

            var dto = solicitacaoMapper.Map(solicitacao);
        }


        static Solicitacao CriarSolicitacao()
        {
            var solicitacao = new Solicitacao();
            solicitacao.Id = Guid.NewGuid();
            solicitacao.Descricao = "Descricao teste " + Guid.NewGuid();
            solicitacao.DataHoraCriacao = DateTime.Now;

            var items = new List<SolicitacaoItem>();

            items.Add(new SolicitacaoItem()
            {
                Codigo = "xpto " + Guid.NewGuid(),
                Descricao = "Descricao do item " + Guid.NewGuid(),
                Id = Guid.NewGuid()
            });

            solicitacao.Items = items;

            return solicitacao;
        }

        static void RegisterDependency()
        {
            var serviceProvider = new ServiceCollection()
                    .AddSingleton<IMapper<Solicitacao, SolicitacaoDto>, SolicitacaoMapper>()
                    .AddSingleton<IMapper<SolicitacaoItem, SolicitacaoItemDto>, SolicitacaoItemMapper>()
                    .AddSingleton<ISolicitacaoMapper, SolicitacaoMapper>()
                    .BuildServiceProvider();

            solicitacaoMapper = serviceProvider.GetService<ISolicitacaoMapper>();
        }

    }



}

/*
public class UsageExample
{
    private readonly IMapper<MapFrom, MapTo> mapper = new DemoMapper();
    
    public MapTo MapOneObject(MapFrom source) => this.mapper.Map(source);
    
    public MapTo[] MapArray(List<MapFrom> source) => this.mapper.MapArray(source);
    
    public List<MapTo> MapList(List<MapFrom> source) => this.mapper.MapList(source);
    
    public IAsyncEnumerable<MapTo> MapAsyncEnumerable(IAsyncEnumerable<MapFrom> source) =>
        this.mapper.MapAsyncEnumerable(source);
}
*/
