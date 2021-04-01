using System;
using Xunit;
using Xunit.Abstractions;
using Trades2.Application;
using Trades2.Domain;
using Trades2.Repository;
using Trades2.Entities;
using System.Collections.Generic;

namespace Trades2.Tests
{
    public class TradeTests
    {
        private readonly ITestOutputHelper _output;
        TradeApp app;
        int totalInteracoes = 100;

        public TradeTests(ITestOutputHelper output)
        {
            _output = output;
            app = new TradeApp(new TradeServices(new TradeRepository()));
        }

        [Fact]
        public void Testar_Incluir_Trade()
        {                   
            var random = new Random();
            var erros = new List<string>();
            for(var i = 0; i < totalInteracoes; i++)
            {
                var trade = new Trade
                {
                    ClientSector = i % 2 == 0 ? "Public" : "Private",
                    Value = random.Next(200000, 3500000)
                };
                try
                {                    
                    app.Add(trade);
                }
                catch(Exception ex)
                {
                    erros.Add($"ClientSector={trade.ClientSector} Value={trade.Value} Error={ex}|");                    
                }
            }
            _output.WriteLine(string.Join('|', erros));
            Assert.True(erros.Count == 0);
        }

        [Fact]
        public void Testar_Listar_Categorias_Full()
        {
            Testar_Incluir_Trade();
            var res = app.GetCategories();
            Assert.NotNull(res);
            Assert.True(res.Count == totalInteracoes);
        }
    }
}
