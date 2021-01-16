using System.Net;
using System.Web.Mvc;
using WebApp.Core.Dto;
using WebApp.Core.Services;

namespace WebApp.Controllers
{
    public class LaptopModelsController : Controller
    {
        private ILaptopService laptopService;

        public LaptopModelsController(ILaptopService laptopService)
        {
            this.laptopService = laptopService;
        }

        // GET: dtos
        public ActionResult Index()
        {
            var dtos = this.laptopService.GetAllLaptops();
            return View(dtos);
        }

        // GET: dtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaptopDto dto = this.laptopService.GetLaptopById(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            return View(dto);
        }

        // GET: dtos/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: dtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Model,Make,Price,Description")] LaptopDto dto)
        {
            if (ModelState.IsValid)
            {
                this.laptopService.CreateLaptop(dto);
                //db.dtos.Add(dto);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dto);
        }

        // GET: dtos/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaptopDto dto = this.laptopService.GetLaptopById(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            return View(dto);
        }

        // POST: dtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Model,Make,Price,Description")] LaptopDto dto)
        {
            if (ModelState.IsValid)
            {
                this.laptopService.EditLaptop(dto);
                //db.Entry(dto).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dto);
        }

        // GET: dtos/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var laptop = this.laptopService.GetLaptopById(id.Value);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        // POST: dtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            this.laptopService.DeleteLaptop(id);
            //dto dto = db.dtos.Find(id);
            //db.dtos.Remove(dto);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}