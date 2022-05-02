using Microsoft.AspNetCore.Mvc;
using RPGCharacterBuilderMVC.Data;
using RPGCharacterBuilderMVC.Models.Character;
using System.Linq;

namespace RPGCharacterBuilderMVC.Controllers
{
    public class CharacterController : Controller
    {
        private readonly RPGCharacterBuilderDbContext _ctx;
        public CharacterController(RPGCharacterBuilderDbContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            var character = _ctx.Characters.Select(character => new CharacterIndexModel
            {
                Id = character.Id,
                CharacterId = character.CharacterId,
                Name = character.Name,
            });
            return View(character);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CharacterCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMsg"] = "Model State is Invalid";
                return View(model);
            }
            _ctx.Characters.Add(new Character
            {
                CharacterId = model.CharacterId,
                Name = model.Name,
                Health = model.Health,
                Strength = model.Strength,
                Stamina = model.Stamina,
                Speed = model.Speed,
                Mana = model.Mana,

            });
            if (_ctx.SaveChanges() == 1)
            {
                return Redirect("/Character");
            }
            TempData["ErrorMsg"] = "Unable to save to the database. Please try again later.";
            return View(model);
        }

        // Get: character/details/{id}
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var character = _ctx.Characters.Find(id);
            {
                if (character == null)
                {
                    return NotFound();
                }
                var model = new CharacterDetailModel
                {
                    Id = character.Id,
                    CharacterId = character.CharacterId,
                    Name = character.Name,
                    Health = character.Health,
                    Strength = character.Strength,
                    Stamina = character.Stamina,
                    Speed = character.Speed,
                    Mana = character.Mana,
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
            var character = _ctx.Characters.Find(id);
            {
                if (character == null)
                {
                    return NotFound();
                }
                var model = new CharacterEditModel
                {
                    CharacterId = character.CharacterId,
                    Name = character.Name,
                    Health = character.Health,
                    Strength = character.Strength,
                    Stamina = character.Stamina,
                    Speed = character.Speed,
                    Mana = character.Mana,
                };
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, CharacterEditModel model)
        {
            var character = _ctx.Characters.Find(id);
            if (character == null)
            {
                return NotFound();
            }
            character.CharacterId = model.CharacterId;
            character.Name = model.Name;
            character.Health = model.Health;
            character.Strength = model.Strength;
            character.Stamina = model.Stamina;
            character.Speed = model.Speed;
            character.Mana = model.Mana;

            if (_ctx.SaveChanges() == 1)
            {
                return Redirect("/Character");
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
            var character = _ctx.Characters.Find(id);
            if (character == null)
            {
                return NotFound();
            }
            var model = new CharacterDetailModel
            {
                Id = id,
                CharacterId = character.CharacterId,
                Name = character.Name,
                Health = character.Health,
                Strength = character.Strength,
                Stamina = character.Stamina,
                Speed = character.Speed,
                Mana = character.Mana,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int? id, CharacterDetailModel model)
        {
            var character = _ctx.Characters.Find(id);
            if (character == null)
            {
                return NotFound();
            }
            _ctx.Characters.Remove(character);
            _ctx.SaveChanges();
            return Redirect("/Character");
        }
    }
}
