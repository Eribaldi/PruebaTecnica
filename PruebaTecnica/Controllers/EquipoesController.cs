﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica.Models;

namespace PruebaTecnica.Controllers
{
    public class EquipoesController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly EquiposContext _context;


        public EquipoesController(EquiposContext context, IWebHostEnvironment environment)
        {
            _environment = environment;
            _context = context;
            
        }

        // GET: Equipoes
        public async Task<IActionResult> Index(string estado = "Todos")
        {
            List<string> stateList = new List<string>();
             await _context.Estados.ForEachAsync(e =>{ stateList.Add(e.NombreEstado); });
            stateList.Add("Todos");
            ViewData["opciones"] = stateList;

            List <Equipo> estadoJugadores = new List<Equipo>();
            var equiposContext = _context.Equipos.Include(e => e.Estado);

            switch (estado)
            {
                case "Todos":
                    await equiposContext.ForEachAsync(e => estadoJugadores.Add(e));
                    break;
                case "Activo":
                    await equiposContext.Where(e => e.Estado.Id == 1).ForEachAsync(e => estadoJugadores.Add(e));
                    break; 
                case "Cancelado":
                    await equiposContext.Where(e => e.Estado.Id == 2).ForEachAsync(e => estadoJugadores.Add(e));
                    break; 
                default:
                    await equiposContext.Where(e => e.Estado.Id == 3).ForEachAsync(e => estadoJugadores.Add(e));
                    break;
            }
            return View(estadoJugadores);
        }

        // GET: Equipoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos
                .Include(e => e.Estado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // GET: Equipoes/Create
        public IActionResult Create()
        {
            List<ISO3> lista = ISO3.RetornarListaPaises(_environment.ContentRootPath);
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "NombreEstado");
            ViewData["Paises"] = lista.Select(pais=> new SelectListItem() { Text = pais.Nombre, Value = pais.Codigo });
            return View();
        }

        // POST: Equipoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Pais,EstadoId,FechaCreacion")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "Id", equipo.EstadoId);
            return View(equipo);
        }

        // GET: Equipoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "NombreEstado", equipo.EstadoId);
            return View(equipo);
        }



        // POST: Equipoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Pais,EstadoId,FechaCreacion")] Equipo equipo)
        {
            if (id != equipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoExists(equipo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "NombreEstado", equipo.EstadoId);
            return View(equipo);
        }

        // GET: Equipoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos
                .Include(e => e.Estado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // POST: Equipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            _context.Equipos.Remove(equipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoExists(int id)
        {
            return _context.Equipos.Any(e => e.Id == id);
        }

        public async Task<IActionResult> ObtenerJugadores(int? id, string estado = "Todos")
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipo equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }

            ViewData["equipoData"] = equipo;

            List<string> stateList = new List<string>();
            await _context.Estados.ForEachAsync(e => { stateList.Add(e.NombreEstado); });
            stateList.Add("Todos");
            ViewData["opciones"] = stateList;

            List<Jugador> estadoJugadores = new List<Jugador>();
            var jugadoresContext = _context.Jugadores.Include(e => e.Estado);

            switch (estado)
            {
                case "Todos":
                    await jugadoresContext.Where(e => e.EquipoId == id).ForEachAsync(e => estadoJugadores.Add(e));
                    break;
                case "Activo":
                    await jugadoresContext.Where(e => e.EquipoId == id && e.EstadoId == 1).ForEachAsync(e => estadoJugadores.Add(e));
                    break;
                case "Cancelado":
                    await jugadoresContext.Where(e => e.EquipoId == id && e.EstadoId == 2).ForEachAsync(e => estadoJugadores.Add(e));
                    break;
                default:
                    await jugadoresContext.Where(e => e.EquipoId == id && e.EstadoId == 3).ForEachAsync(e => estadoJugadores.Add(e));
                    break;
            }

            return View("JPorEstados", estadoJugadores);
        }
    }
}
