namespace RPGCharacterBuilderMVC.Models.MagicItem
{
    public class MagicItemDetailModel
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int MagicDamageIncreasedBy { get; set; }
        public int Weight { get; set; }
    }
}
