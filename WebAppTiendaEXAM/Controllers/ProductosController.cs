using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using WebAppTiendaEXAM.Data;
using WebAppTiendaEXAM.Models;

namespace WebAppTiendaEXAM.Controllers;

public class ProductosController : Controller

{

    private readonly ApplicationDbContext _context;

    public ProductosController(ApplicationDbContext context)

    {

        _context = context;

    }
// Mostrar listado de productos

    public IActionResult Index()

    {

        var productos = _context.Productos.ToList();

        return View(productos);

    }
// Crear producto (GET)

    public IActionResult Crear()

    {

        return View();

    }
// Crear producto (POST)

    [HttpPost]

    public IActionResult Crear(Productos producto)

    {

        if (ModelState.IsValid)

        {

            _context.Productos.Add(producto);

            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        return View(producto);

    }

    private IActionResult View(Productos viewName)
    {
        throw new NotImplementedException();
    }
    // Editar producto (GET)

    public IActionResult Editar(int id)

    {

        var producto = _context.Productos.Find(id);

        if (producto == null) return NotFound();

        return View(producto);

    }
// Editar producto (POST)

    [HttpPost]

    public IActionResult Editar(Productos producto)

    {

        if (ModelState.IsValid)

        {

            _context.Productos.Update(producto);

            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        return View(producto);

    }
// Borrar producto

    public IActionResult Borrar(int id)

    {

        var producto = _context.Productos.Find(id);

        if (producto == null) return NotFound();

        _context.Productos.Remove(producto);

        _context.SaveChanges();

        return RedirectToAction("Index");

    }

}