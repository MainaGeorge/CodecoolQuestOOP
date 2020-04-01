using Codecool.Quest.Models.Actors;
using Codecool.Quest.Models.Utilities;

namespace Codecool.Quest.Models.Assets
{
    public class Key : Item
    {
        public Key(Cell cell) : base(cell)
        {
        }

        public override ItemType ItemType { get; } = ItemType.Key;

        public override string TileName { get; } = "key";

        public override bool GetCollected(Character character)
        {
            character.ItemsCollected.AddItemToTheCollection(this);
            return true;
        }
    }
}