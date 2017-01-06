using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DL.Models;
using DAL;

namespace PL.Controllers
{
    public class UsuariosController : Controller
    {
        private FreseniusDbContext db = new FreseniusDbContext();

        // GET: /Usuarios/
        public async Task<ActionResult> Index()
        {
            var kbcusuarios = db.KbcUsuarios.Include(k => k.KbcPerfil).Include(k => k.KbcPersona);
            return View(await kbcusuarios.ToListAsync());
        }

        // GET: /Usuarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KbcUsuario kbcusuario = await db.KbcUsuarios.FindAsync(id);
            if (kbcusuario == null)
            {
                return HttpNotFound();
            }
            return View(kbcusuario);
        }

        // GET: /Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.perfId = new SelectList(db.KbcPerfils, "perfId", "perfNombre");
            ViewBag.perId = new SelectList(db.KbcPersonas, "perId", "perNombre");
            return View();
        }

        // POST: /Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="usuId,perfId,perId,usuUserName,usuClave,usuTipo,usuVigente")] KbcUsuario kbcusuario)
        {
            if (ModelState.IsValid)
            {
                db.KbcUsuarios.Add(kbcusuario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.perfId = new SelectList(db.KbcPerfils, "perfId", "perfNombre", kbcusuario.perfId);
            ViewBag.perId = new SelectList(db.KbcPersonas, "perId", "perNombre", kbcusuario.perId);
            return View(kbcusuario);
        }

        // GET: /Usuarios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KbcUsuario kbcusuario = await db.KbcUsuarios.FindAsync(id);
            if (kbcusuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.perfId = new SelectList(db.KbcPerfils, "perfId", "perfNombre", kbcusuario.perfId);
            ViewBag.perId = new SelectList(db.KbcPersonas, "perId", "perNombre", kbcusuario.perId);
            return View(kbcusuario);
        }

        // POST: /Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="usuId,perfId,perId,usuUserName,usuClave,usuTipo,usuVigente")] KbcUsuario kbcusuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kbcusuario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.perfId = new SelectList(db.KbcPerfils, "perfId", "perfNombre", kbcusuario.perfId);
            ViewBag.perId = new SelectList(db.KbcPersonas, "perId", "perNombre", kbcusuario.perId);
            return View(kbcusuario);
        }

        // GET: /Usuarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KbcUsuario kbcusuario = await db.KbcUsuarios.FindAsync(id);
            if (kbcusuario == null)
            {
                return HttpNotFound();
            }
            return View(kbcusuario);
        }

        // POST: /Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            KbcUsuario kbcusuario = await db.KbcUsuarios.FindAsync(id);
            db.KbcUsuarios.Remove(kbcusuario);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
