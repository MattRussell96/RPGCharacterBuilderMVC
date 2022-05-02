namespace RPGCharacterBuilderMVC.Models.Character
{
    public class CharacterCreateModel
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Stamina { get; set; }
        public int Speed { get; set; }
        public int Mana { get; set; }
    }
}
