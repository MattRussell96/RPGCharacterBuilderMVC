using Microsoft.AspNetCore.Mvc;
using RPGCharacterBuilderMVC.Data;
using RPGCharacterBuilderMVC.Models.Armor;
using System.Linq;

namespace RPGCharacterBuilderMVC.Controllers
{
    public class ArmorController : Controller
    {
        private readonly RPGCharacterBuilderDbContext _ctx;
        public ArmorController(RPGCharacterBuilderDbContext ctx)
        { 
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            var armor = _ctx.Armors.Select(armor => new ArmorIndexModel
            {
                Id = armor.Id,
                CharacterId = armor.CharacterId,
                Name = armor.Name,
                Type = armor.Type,
            });
            return View(armor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ArmorCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMsg"] = "Model State is Invalid";
                return View(model);
            }
            _ctx.Armors.Add(new Armor
            {
                CharacterId = model.CharacterId,
                Name = model.Name,
                Type = model.Type,
                DamageNegation = model.DamageNegation,
                Weight = model.Weight,
            });
            if (_ctx.SaveChanges() == 1)
            {
                return Redirect("/Armor");
            }
            TempData["ErrorMsg"] = "Unable to save to the database. Please try again later.";
            return View(model);
        }

        // Get: armor/details/{id}
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var armor = _ctx.Armors.Find(id);
            {
                if (armor == null)
                {
                    return NotFound();
                }
                var model = new ArmorDetailModel
                {
                    Id = armor.Id,
                    CharacterId = armor.CharacterId,
                    Name = armor.Name,
                    Type = armor.Type,
                    DamageNegation = armor.DamageNegation,
                    Weight = armor.Weight,
                };
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var armor = _ctx.Armors.Find(id);
            {
                if (armor == null)
                { 
                    return NotFound();
                }
                var model = new ArmorEditModel
                {
                    CharacterId = armor.CharacterId,
                    Name = armor.Name,
                    Type = armor.Type,
                    DamageNegation = armor.DamageNegation,
                    Weight = armor.Weight,
                };
                return View(model);   
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, ArmorEditModel model)
        {
            var armor = _ctx.Armors.Find(id);
            if (armor == null)
            {
                return NotFound();
            }
            armor.CharacterId = model.CharacterId;
            armor.Name = model.Name;
            armor.Type = model.Type;
            armor.DamageNegation = model.DamageNegation;
            armor.Weight = model.Weight;

            if (_ctx.SaveChanges() == 1)
            {
                return Redirect("/Armor");
            }

            ViewData["ErrorMsg"] = "Unable to save to the database. Please try again later.";
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var armor = _ctx.Armors.Find(id);
            if (armor == null)
            {
                return NotFound();
            }
            var model = new ArmorDetailModel
            {
                Id = id,
                CharacterId = armor.CharacterId,
                Name = armor.Name,
                Type = armor.Type,
                DamageNegation = armor.DamageNegation,
                Weight = armor.Weight
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int? id, ArmorDetailModel model)
        {
            var armor = _ctx.Armors.Find(id);
            if (armor == null)
            {
                return NotFound();
            }
            _ctx.Armors.Remove(armor);
            _ctx.SaveChanges();
            return Redirect("/Armor");
        }
    }
}
