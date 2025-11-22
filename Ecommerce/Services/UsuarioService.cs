using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Ecommerce.Services
{
    public class UsuarioService
    {
        private readonly IMongoCollection<Usuario> _usuarios;
        public UsuarioService(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);

            _usuarios = database.GetCollection<Usuario>("Usuario");
        }

        public async Task<List<Usuario>> GetTodosAsync() =>
            await _usuarios.Find(_ => true).ToListAsync();

        public async Task CriarUsuario(Usuario usuario) =>
            await _usuarios.InsertOneAsync(usuario);
    }
}