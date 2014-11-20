using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Template.Core.Models;
using Template.Core.Service;
using Template.Data.Infrastructure;
using Template.ViewModels;
using Template.Web.Core.Extensions;

namespace Template.Controllers
{
    public class DummyItensController : Controller
    {
        private IDummyService dummyService;

        public DummyItensController(IDummyService dummyService)
        {
            this.dummyService = dummyService;
        }

        // GET: /DummyItens/
        public ActionResult Index()
        {
            var dummyItens = Mapper.Map<List<DummyItemViewModel>>(dummyService.GetAll());
            return View(dummyItens);
        }

        // GET: /DummyItens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DummyItem dummyitem = dummyService.GetByID(id);
            if (dummyitem == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<DummyItemViewModel>(dummyitem));
        }

        // GET: /DummyItens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /DummyItens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DummyDescription")] DummyItemViewModel dummyitemVM)
        {
            var dummyItem = Mapper.Map<DummyItem>(dummyitemVM);
            ModelState.AddModelErrors(dummyService.CanAdd(dummyItem));
            if (ModelState.IsValid)
            {
                dummyService.Create(dummyItem);
                return RedirectToAction("Index");
            }

            return View(dummyitemVM);
        }

        // GET: /DummyItens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DummyItem dummyitem = dummyService.GetByID(id);
            if (dummyitem == null)
            {
                return HttpNotFound();
            }
            var dummyItemVM = Mapper.Map<DummyItemViewModel>(dummyitem);
            return View(dummyItemVM);
        }

        // POST: /DummyItens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DummyItemID,DummyDescription")] DummyItemViewModel dummyitemVM)
        {
            var dummyItem = dummyService.GetByID(dummyitemVM.DummyItemID);
            if (dummyItem == null)
            {
                return HttpNotFound();
            }
            Mapper.Map(dummyitemVM, dummyItem);
            ModelState.AddModelErrors(dummyService.CanAdd(dummyItem));
            if (ModelState.IsValid)
            {
                dummyService.Update(dummyItem);
                return RedirectToAction("Index");
            }
            return View(dummyitemVM);
        }

        // GET: /DummyItens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DummyItem dummyitem = dummyService.GetByID(id);
            if (dummyitem == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<DummyItemViewModel>(dummyitem));
        }

        // POST: /DummyItens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DummyItem dummyitem = dummyService.GetByID(id);
            dummyService.Delete(dummyitem);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dummyService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
