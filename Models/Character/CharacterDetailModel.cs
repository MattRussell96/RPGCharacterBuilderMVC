namespace RPGCharacterBuilderMVC.Models.Character
{
    public class CharacterDetailModel
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Stamina { get; set; }
        public int Speed { get; set; }
        public int Mana { get; set; }
    }
}
