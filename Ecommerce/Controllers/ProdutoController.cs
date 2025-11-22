using Ecommerce.Services;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoService _service;

        public ProdutoController(ProdutoService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _service.GetTodosAsync();
            return View(produtos);
        }

        public async Task<IActionResult> Seed()
        {
            await _service.CriarProduto(new Produto
            {
                Nome = "Camiseta Ninja",
                Preco = 99,
                Descricao = "A mais furtiva das camisetas."
            });

            return RedirectToAction("Index");
        }

    }
}
