using Codecool.Quest.Models.Actors;
using Codecool.Quest.Models.Utilities;

namespace Codecool.Quest.Models.Assets
{
    public class Headmask : Item
    {
        public Headmask(Cell cell) : base(cell)
        {
        }

        public override ItemType ItemType { get; } = ItemType.Headmask;

        public override string TileName { get; } = "headmask";
        public override bool GetCollected(Character character)
        {
            character.Weapons.Headmask = true;
            character.ItemsCollected.AddItemToTheCollection(this);
            return true;

        }
    }
}