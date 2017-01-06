using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using DAL.Models;
using DAL;
using System.Data.Entity;

namespace BL.Controllers
{
    public class UsuariosController : Controller
    {
        private UnitOfWork UoW = new UnitOfWork();

        // GET: /Usuarios/
        public async Task<ActionResult> Index()
        {
            return View(await UoW.KbcUsuarios.Queryable().ToListAsync());
        }        

        // GET: /Usuarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            KbcUsuario kbcusuario = await UoW.KbcUsuarios.FindAsync(id);

            if (kbcusuario == null)
            {
                return HttpNotFound();
            }
            return View(kbcusuario);
        }

        // GET: /Usuarios/Create
        public async Task<ActionResult> Create()
        {            
            ViewBag.perfId = new SelectList(await UoW.KbcPerfiles.Queryable().ToListAsync(), "perfId", "perfNombre");
            ViewBag.perId = new SelectList(await UoW.KbcPersonas.Queryable().ToListAsync(), "perId", "perNombre");
            return View();
        }

        // POST: /Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="usuId,perfId,perId,usuUserName,usuClave,usuTipo,usuVigente")] KbcUsuario kbcusuario)
        {
            if (ModelState.IsValid)
            {                
                UoW.KbcUsuarios.Create(kbcusuario);
                await UoW.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewBag.perfId = new SelectList(await UoW.KbcPerfiles.Queryable().ToListAsync(), "perfId", "perfNombre");
            ViewBag.perId = new SelectList(await UoW.KbcPersonas.Queryable().ToListAsync(), "perId", "perNombre");            
            return View(kbcusuario);
        }

        // GET: /Usuarios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KbcUsuario kbcusuario = await UoW.KbcUsuarios.FindAsync(id);
            if (kbcusuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.perfId = new SelectList(await UoW.KbcPerfiles.Queryable().ToListAsync(), "perfId", "perfNombre");
            ViewBag.perId = new SelectList(await UoW.KbcPersonas.Queryable().ToListAsync(), "perId", "perNombre");            
            return View(kbcusuario);
        }

        // POST: /Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="usuId,perfId,perId,usuUserName,usuClave,usuTipo,usuVigente")] KbcUsuario kbcusuario)
        {
            if (ModelState.IsValid)
            {                
                UoW.KbcUsuarios.Update(kbcusuario);
                await UoW.SaveChangesAsync();
                
                return RedirectToAction("Index");
            }
            ViewBag.perfId = new SelectList(await UoW.KbcPerfiles.Queryable().ToListAsync(), "perfId", "perfNombre", kbcusuario.perfId);
            ViewBag.perId = new SelectList(await UoW.KbcPersonas.Queryable().ToListAsync(), "perId", "perNombre", kbcusuario.perId);
            return View(kbcusuario);
        }

        // GET: /Usuarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KbcUsuario kbcusuario = await UoW.KbcUsuarios.FindAsync(id);
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
            KbcUsuario kbcusuario = await UoW.KbcUsuarios.FindAsync(id);            
            UoW.KbcUsuarios.Delete(kbcusuario);
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
