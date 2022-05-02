using Microsoft.AspNetCore.Mvc;
using RPGCharacterBuilderMVC.Data;
using RPGCharacterBuilderMVC.Models.MagicItem;
using System.Linq;

namespace RPGCharacterBuilderMVC.Controllers
{
    public class MagicItemController : Controller
    {
        private readonly RPGCharacterBuilderDbContext _ctx;
        public MagicItemController(RPGCharacterBuilderDbContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            var magicItem = _ctx.MagicItems.Select(magicItem => new MagicItemIndexModel
            {
                Id = magicItem.Id,
                CharacterId = magicItem.CharacterId,
                Name = magicItem.Name,
                Type = magicItem.Type,
            });
            return View(magicItem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MagicItemCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMsg"] = "Model State is Invalid";
                return View(model);
            }
            _ctx.MagicItems.Add(new MagicItem
            {
                CharacterId = model.CharacterId,
                Name = model.Name,
                Type = model.Type,
                MagicDamageIncreasedBy = model.MagicDamageIncreasedBy,
                Weight = model.Weight,
            });
            if (_ctx.SaveChanges() == 1)
            {
                return Redirect("/MagicItem");
            }
            TempData["ErrorMsg"] = "Unable to save to the database. Please try again later.";
            return View(model);
        }

        // Get: magicItem/details/{id}
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var magicItem = _ctx.MagicItems.Find(id);
            {
                if (magicItem == null)
                {
                    return NotFound();
                }
                var model = new MagicItemDetailModel
                {
                    Id = magicItem.Id,
                    CharacterId = magicItem.CharacterId,
                    Name = magicItem.Name,
                    Type = magicItem.Type,
                    MagicDamageIncreasedBy = magicItem.MagicDamageIncreasedBy,
                    Weight = magicItem.Weight,
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
            var magicItem = _ctx.MagicItems.Find(id);
            {
                if (magicItem == null)
                {
                    return NotFound();
                }
                var model = new MagicItemEditModel
                {
                    CharacterId = magicItem.CharacterId,
                    Name = magicItem.Name,
                    Type = magicItem.Type,
                    MagicDamageIncreasedBy = magicItem.MagicDamageIncreasedBy,
                    Weight = magicItem.Weight,
                };
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, MagicItemEditModel model)
        {
            var magicItem = _ctx.MagicItems.Find(id);
            if (magicItem == null)
            {
                return NotFound();
            }
            magicItem.CharacterId = model.CharacterId;
            magicItem.Name = model.Name;
            magicItem.Type = model.Type;
            magicItem.MagicDamageIncreasedBy = model.MagicDamageIncreasedBy;
            magicItem.Weight = model.Weight;

            if (_ctx.SaveChanges() == 1)
            {
                return Redirect("/MagicItem");
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
            var magicItem = _ctx.MagicItems.Find(id);
            if (magicItem == null)
            {
                return NotFound();
            }
            var model = new MagicItemDetailModel
            {
                Id = id,
                CharacterId = magicItem.CharacterId,
                Name = magicItem.Name,
                Type = magicItem.Type,
                MagicDamageIncreasedBy = magicItem.MagicDamageIncreasedBy,
                Weight = magicItem.Weight
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int? id, MagicItemDetailModel model)
        {
            var magicItem = _ctx.MagicItems.Find(id);
            if (magicItem == null)
            {
                return NotFound();
            }
            _ctx.MagicItems.Remove(magicItem);
            _ctx.SaveChanges();
            return Redirect("/MagicItem");
        }
    }
}
