using Codecool.Quest.Models.Actors;
using Codecool.Quest.Models.Utilities;

namespace Codecool.Quest.Models.Assets
{
    public class Sword : Item
    {
        public Sword(Cell cell) : base(cell)
        {
        }

        public override ItemType ItemType { get; } = ItemType.Sword;

        public override string TileName { get; } = "sword";
        public override bool GetCollected(Character character)
        {
            character.Weapons.Sword = true;
            character.ItemsCollected.AddItemToTheCollection(this);
            return true;

        }
    }
}