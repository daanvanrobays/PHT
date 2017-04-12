using PHT.Implementation.Repo;
using PHT.Models.PhtModels;
using PHT.Repo;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PHT.Controllers
{
    public class HomeController : Controller
    {
        private IPloegRepo _PloegRepo;

        // GET: Ploeg
        [AllowAnonymous]
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

        private PloegViewModel PloegMapper(Ploeg ploeg)
        {
            PloegViewModel viewModel = new PloegViewModel();
            viewModel.Ploeg_ID = ploeg.Ploeg_ID;
            viewModel.Naam = ploeg.Naam;
            viewModel.PintenAantal = ploeg.PintenAantal;

            return viewModel;
        }
    }
}