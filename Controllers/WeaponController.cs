using Microsoft.AspNetCore.Mvc;
using RPGCharacterBuilderMVC.Data;
using RPGCharacterBuilderMVC.Models.Weapon;
using System.Linq;

namespace RPGCharacterBuilderMVC.Controllers
{
    public class WeaponController : Controller
    {
    
    private readonly RPGCharacterBuilderDbContext _ctx;
    public WeaponController(RPGCharacterBuilderDbContext ctx)
    {
        _ctx = ctx;
    }

        public IActionResult Index()
        {
            var weapon = _ctx.Weapons.Select(weapon => new WeaponIndexModel
            {
                Id = weapon.Id,
                CharacterId = weapon.CharacterId,
                Name = weapon.Name,
                Type = weapon.Type,
            });
            return View(weapon);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(WeaponCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMsg"] = "Model State is Invalid";
                return View(model);
            }
            _ctx.Weapons.Add(new Weapon
            {
                CharacterId = model.CharacterId,
                Name = model.Name,
                Type = model.Type,
                DamageIncreasedBy = model.DamageIncreasedBy,
                MagicDamage = model.MagicDamage,
                Weight = model.Weight,
            });
            if (_ctx.SaveChanges() == 1)
            {
                return Redirect("/Weapon");
            }
            TempData["ErrorMsg"] = "Unable to save to the database. Please try again later.";
            return View(model);
        }

        // Get: weapon/details/{id}
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var weapon = _ctx.Weapons.Find(id);
            {
                if (weapon == null)
                {
                    return NotFound();
                }
                var model = new WeaponDetailModel
                {
                    Id = weapon.Id,
                    CharacterId = weapon.CharacterId,
                    Name = weapon.Name,
                    Type = weapon.Type,
                    DamageIncreasedBy = weapon.DamageIncreasedBy,
                    MagicDamage = weapon.MagicDamage,
                    Weight = weapon.Weight,
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
            var weapon = _ctx.Weapons.Find(id);
            {
                if (weapon == null)
                {
                    return NotFound();
                }
                var model = new WeaponEditModel
                {
                    CharacterId = weapon.CharacterId,
                    Name = weapon.Name,
                    Type = weapon.Type,
                    DamageIncreasedBy = weapon.DamageIncreasedBy,
                    MagicDamage = weapon.MagicDamage,
                    Weight = weapon.Weight,
                };
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, WeaponEditModel model)
        {
            var weapon = _ctx.Weapons.Find(id);
            if (weapon == null)
            {
                return NotFound();
            }
            weapon.CharacterId = model.CharacterId;
            weapon.Name = model.Name;
            weapon.Type = model.Type;
            weapon.DamageIncreasedBy = model.DamageIncreasedBy;
            weapon.MagicDamage = model.MagicDamage;
            weapon.Weight = model.Weight;

            if (_ctx.SaveChanges() == 1)
            {
                return Redirect("/Weapon");
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
            var weapon = _ctx.Weapons.Find(id);
            if (weapon == null)
            {
                return NotFound();
            }
            var model = new WeaponDetailModel
            {
                Id = id,
                CharacterId = weapon.CharacterId,
                Name = weapon.Name,
                Type = weapon.Type,
                DamageIncreasedBy = weapon.DamageIncreasedBy,
                MagicDamage = weapon.MagicDamage,
                Weight = weapon.Weight
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int? id, WeaponDetailModel model)
        {
            var weapon = _ctx.Weapons.Find(id);
            if (weapon == null)
            {
                return NotFound();
            }
            _ctx.Weapons.Remove(weapon);
            _ctx.SaveChanges();
            return Redirect("/Weapon");
        }
    }
}
