using System;
using System.Collections.Generic;

#nullable disable

namespace RPGCharacterBuilderMVC.Data
{
    public partial class Character
    {
        public Character()
        {
            Armors = new HashSet<Armor>();
            MagicItems = new HashSet<MagicItem>();
            Weapons = new HashSet<Weapon>();
        }

        public int Id { get; set; }
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Stamina { get; set; }
        public int Speed { get; set; }
        public int Mana { get; set; }

        public virtual User CharacterNavigation { get; set; }
        public virtual ICollection<Armor> Armors { get; set; }
        public virtual ICollection<MagicItem> MagicItems { get; set; }
        public virtual ICollection<Weapon> Weapons { get; set; }
    }
}
