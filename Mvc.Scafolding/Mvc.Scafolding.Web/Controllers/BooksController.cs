using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContextIdeaData.EF;
using ContextIdeaData.EF.Data;
using ContextIdeaData.EF.Interfaces;

namespace Mvc.Scafolding.Web.Controllers
{
    public class BooksController : BaseController
    {
		private readonly IUnitOfWork _unitOfWork;
		//This is test
        private IRepository<BookContext> _repository;		
        
        public BooksController()
        {
            _unitOfWork = new UnitOfWork(new CiDbContext());
            _repository = _unitOfWork.Repository<BookContext>();
        }

        // GET: Books
		public async Task<ActionResult> Index()
        {
			var items = await _repository.Query().GetAsync();           
			return View(await items.ToListAsync());
        }

        // GET: Books/Details/5
		public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

			var item = await _repository.FindByIdAsync(id);

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
		     return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(Books model)
        {
            if (ModelState.IsValid)
            {
				_repository.Insert(model);
				var result = await _unitOfWork.SaveAsync();

				if (result == 0)
					return View(model);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Books/Edit/5
		public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			var item = await _repository.FindByIdAsync(id);

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(Books model)
        {
            if (!ModelState.IsValid)
				return View(model);

            
            _repository.Update(id, model);
			var result = await _unitOfWork.SaveAsync();

			if (result == 0)
				return View(model);

            return RedirectToAction("Index");
        }

        // GET: Books/Delete/5
		public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			
			var item = await _repository.FindByIdAsync(id);

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int? id)
        {
			var item = await _repository.FindByIdAsync(id);

            if (item == null)
                return HttpNotFound();

            _repository.Delete(id);
            var result = await _unitOfWork.SaveAsync();

			if (result == 0)
				return View(model);

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
