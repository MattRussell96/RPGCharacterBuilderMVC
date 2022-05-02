namespace RPGCharacterBuilderMVC.Models.Armor
{
    public class ArmorDetailModel
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int DamageNegation { get; set; }
        public int Weight { get; set; }
     }
}
