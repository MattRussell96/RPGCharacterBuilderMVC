namespace RPGCharacterBuilderMVC.Models.Weapon
{
    public class WeaponCreateModel
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int DamageIncreasedBy { get; set; }
        public int MagicDamage { get; set; }
        public int Weight { get; set; }
    }
}
