using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _service;    

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var usuario = await _service.GetTodosAsync();
            return View(usuario);
        }

        public async Task<IActionResult> Seed()
        {
            await _service.CriarUsuario(new Usuario
            {
                Nome = "Diogo",
                Email = "diogo@example.com.br",
                Senha = "123456789!"
            });

            return RedirectToAction("Index");
        }

    }
}