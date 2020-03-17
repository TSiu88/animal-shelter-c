using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AnimalShelter.Controllers
{
  public class AnimalsController : Controller
  {
    private readonly AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Animal> model = _db.Animals.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Animal animal)
    {
      _db.Animals.Add(animal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      return View(thisAnimal);
    }

    public ActionResult Edit(int id)
    {
      var thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      // ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View(thisAnimal);
    }

    [HttpPost]
    public ActionResult Edit(Animal animal)
    {
      _db.Entry(animal).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      return View(thisAnimal);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      _db.Animals.Remove(thisAnimal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult SortByType()
    {
      List<Animal> model = _db.Animals.ToList();
      List<Animal> sortedModel = new List<Animal>{};
      sortedModel = model.OrderBy(x => x.Type).ToList();
      return View(sortedModel);
    }

    public ActionResult SortByDate()
    {
      List<Animal> model = _db.Animals.ToList();
      List<Animal> sortedModel = new List<Animal>{};
      sortedModel = model.OrderBy(x => x.DateAdmittance).ToList();
      return View(sortedModel);
    }

    public ActionResult Search()
    {
      Animal someAnimal = new Animal();
      return View(someAnimal);
    }

    [HttpPost]
     public ActionResult Search(string searchCriteria)
     {
      List<Animal> allModels = _db.Animals.ToList();
      List<Animal> foundModels = allModels.FindAll(x => x.Type == searchCriteria);
      return RedirectToAction("Index", foundModels);  
     }

  }
}