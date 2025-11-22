using Ecommerce.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Ecommerce.Services
{
    public class ProdutoService
    {
        private readonly IMongoCollection<Produto> _produtos;
        public ProdutoService(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);

            _produtos = database.GetCollection<Produto>("Produto");
        }

        public async Task<List<Produto>> GetTodosAsync() =>
            await _produtos.Find(_ => true).ToListAsync();

        public async Task CriarProduto(Produto produto) =>
            await _produtos.InsertOneAsync(produto);
    }
}
