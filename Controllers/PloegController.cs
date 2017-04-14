using System;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using PHT.Models.PhtModels;
using PHT.Implementation.Repo;
using PHT.Repo;
using System.Collections.Generic;
using System.Linq;

namespace PHT.Controllers
{
    [Authorize]
    public class PloegController : Controller
    {
        private IPloegRepo _PloegRepo;

        // GET: Ploeg
        public async Task<ActionResult> Index()
        {
            _PloegRepo = new PloegRepo();
            var ploegenList = await _PloegRepo.GetPloegen();

            List<PloegViewModel> vmList = new List<PloegViewModel>();

            foreach (var item in ploegenList)
            {
                vmList.Add(PloegMapper(item));
            }
            return View(vmList.OrderByDescending(x => x.PintenAantal));
        }

        // GET: Ploeg/Details/5
        public async Task<ActionResult> Details(Guid? ploeg_ID)
        {
            _PloegRepo = new PloegRepo();
            var ploegVm = new PloegViewModel();

            if (ploeg_ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ploeg = await _PloegRepo.getPloeg(ploeg_ID);
            if (ploeg == null)
            {
                return HttpNotFound();
            }
            return View(PloegMapper(ploeg));
        }

        // GET: Ploeg/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ploeg/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ploeg_ID,Naam,PintenAantal")] Ploeg ploeg)
        {
            _PloegRepo = new PloegRepo();
            var ploegVm = new PloegViewModel();

            if (ModelState.IsValid)
            {
                _PloegRepo.SavePloeg(ploeg);
                return RedirectToAction("Index");
            }

            return View(PloegMapper(ploeg));
        }

        // GET: Ploeg/Edit/5
        public async Task<ActionResult> Edit(Guid? ploeg_ID)
        {
            _PloegRepo = new PloegRepo();

            if (ploeg_ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ploeg = await _PloegRepo.getPloeg(ploeg_ID);
            if (ploeg == null)
            {
                return HttpNotFound();
            }
            return View(PloegMapper(ploeg));
        }

        // POST: Ploeg/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ploeg_ID,Naam,PintenAantal")] Ploeg ploeg)
        {
            _PloegRepo = new PloegRepo();

            if (ModelState.IsValid)
            {
                _PloegRepo.UpdatePloeg(ploeg);
                return RedirectToAction("Index", "Home");
            }
            return View(PloegMapper(ploeg));
        }

        // POST: Ploeg/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPinten([Bind(Include = "Ploeg_ID,Naam,PintenAantal,PlusPinten")] PloegViewModel ploeg)
        {
            _PloegRepo = new PloegRepo();

            if (ModelState.IsValid)
            {
                ploeg.PintenAantal += ploeg.PlusPinten;

                _PloegRepo.UpdatePloeg(PloegMapper(ploeg));
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Ploeg/Delete/5
        public async Task<ActionResult> Delete(Guid? ploeg_ID)
        {
            _PloegRepo = new PloegRepo();

            if (ploeg_ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ploeg = await _PloegRepo.getPloeg(ploeg_ID);
            if (ploeg == null)
            {
                return HttpNotFound();
            }
            return View(PloegMapper(ploeg));
        }

        // POST: Ploeg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid? ploeg_ID)
        {
            _PloegRepo = new PloegRepo();

            _PloegRepo.DeletePloeg(ploeg_ID);
            return RedirectToAction("Index");
        }

        private PloegViewModel PloegMapper(Ploeg ploeg)
        {
            PloegViewModel viewModel = new PloegViewModel();
            viewModel.Ploeg_ID = ploeg.Ploeg_ID;
            viewModel.Naam = ploeg.Naam;
            viewModel.PintenAantal = ploeg.PintenAantal;

            return viewModel;
        }

        private Ploeg PloegMapper(PloegViewModel viewModel)
        {
            Ploeg ploeg = new Ploeg();
            ploeg.Ploeg_ID = viewModel.Ploeg_ID;
            ploeg.Naam = viewModel.Naam;
            ploeg.PintenAantal = viewModel.PintenAantal;

            return ploeg;
        }
    }
}
