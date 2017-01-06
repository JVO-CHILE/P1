using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.Models;
using DAL;

namespace PL.Controllers
{
    public class PersonasController : Controller
    {
        private UnitOfWork UoW = new UnitOfWork();

        // GET: /Personas/
        public async Task<ActionResult> Index()
        {
            return View(await UoW.KbcPersonas.Queryable().ToListAsync());
        }

        // GET: /Personas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KbcPersona kbcpersona = await UoW.KbcPersonas.FindAsync(id);
            if (kbcpersona == null)
            {
                return HttpNotFound();
            }
            return View(kbcpersona);
        }

        // GET: /Personas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="perId,perRut,perNombre,perPaterno,perMaterno,perMail")] KbcPersona kbcpersona)
        {
            if (ModelState.IsValid)
            {
                UoW.KbcPersonas.Create(kbcpersona);
                await UoW.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(kbcpersona);
        }

        // GET: /Personas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KbcPersona kbcpersona = await UoW.KbcPersonas.FindAsync(id);
            if (kbcpersona == null)
            {
                return HttpNotFound();
            }
            return View(kbcpersona);
        }

        // POST: /Personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="perId,perRut,perNombre,perPaterno,perMaterno,perMail")] KbcPersona kbcpersona)
        {
            if (ModelState.IsValid)
            {                
                UoW.KbcPersonas.Update(kbcpersona);
                await UoW.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(kbcpersona);
        }

        // GET: /Personas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KbcPersona kbcpersona = await UoW.KbcPersonas.FindAsync(id);
            if (kbcpersona == null)
            {
                return HttpNotFound();
            }
            return View(kbcpersona);
        }

        // POST: /Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            KbcPersona kbcpersona = await UoW.KbcPersonas.FindAsync(id);
            UoW.KbcPersonas.Delete(kbcpersona);
            await UoW.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UoW.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
