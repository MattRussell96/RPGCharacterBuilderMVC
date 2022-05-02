using System;
using System.Collections.Generic;

#nullable disable

namespace RPGCharacterBuilderMVC.Data
{
    public partial class Weapon
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int DamageIncreasedBy { get; set; }
        public int MagicDamage { get; set; }
        public int Weight { get; set; }

        public virtual Character Character { get; set; }
    }
}
