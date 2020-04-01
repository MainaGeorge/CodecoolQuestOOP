using Codecool.Quest.Models.Actors;
using Codecool.Quest.Models.Utilities;

namespace Codecool.Quest.Models.Assets
{
    public class Gun : Item
    {
        public Gun(Cell cell) : base(cell)
        {
        }

        public override ItemType ItemType { get; } = ItemType.Gun;

        public override string TileName { get; } = "gun";
        public override bool GetCollected(Character character)
        {

            character.Weapons.Gun = true;
            character.ItemsCollected.AddItemToTheCollection(this);
            return true;
        }
    }
}