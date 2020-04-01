using Codecool.Quest.Models.Actors;
using System.Linq;
using Codecool.Quest.Models.Utilities;

namespace Codecool.Quest.Models.Assets
{
    public class Door : Item
    {

        public Door(Cell cell) : base(cell)
        {
        }

        public override ItemType ItemType { get; } = ItemType.Door;

        public override string TileName { get; } = "door";

        public override bool GetCollected(Character character)
        {
            var key = character.ItemsCollected.GetCollectedItems()
                .FirstOrDefault(item => item.ItemType == ItemType.Key);

            if (key == null) return false;

            character.ItemsCollected.RemoveAnItemFromTheCollection(key);
            return true;

        }
    }
}