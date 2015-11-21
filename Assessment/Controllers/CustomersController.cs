using System.Web.Mvc;
using System.Net;
using Assessment.Domain.Models;
using Assessment.Domain.Repositories;

namespace Assessment.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository repository;

        public CustomersController(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        // GET: Customers/5
        // This should be separated out into an ApiController
        [Route("Customers/{id:int?}")]
        public JsonResult Get(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Id not present.", JsonRequestBehavior.AllowGet);
            }
            var customer = repository.Select(id.Value);
            return Json(repository.Select(id.Value),JsonRequestBehavior.AllowGet);
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View(repository.Select());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            return View(repository.Select(id));
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerInformation customer)
        {
            try
            {
                repository.Insert(customer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.Select(id));
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerInformation customer)
        {
            try
            {
                repository.Update(customer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repository.Select(id));
        }

        // POST: Customers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                repository.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
