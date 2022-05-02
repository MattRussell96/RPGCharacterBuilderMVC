using System;
using System.Collections.Generic;

#nullable disable

namespace RPGCharacterBuilderMVC.Data
{
    public partial class MagicItem
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int MagicDamageIncreasedBy { get; set; }
        public int Weight { get; set; }

        public virtual Character Character { get; set; }
    }
}
