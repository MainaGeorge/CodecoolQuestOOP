using Codecool.Quest.Models.Actors;
using Codecool.Quest.Models.Utilities;

namespace Codecool.Quest.Models.Assets
{
    public class Crown : Item
    {
        public Crown(Cell cell) : base(cell)
        {
        }

        public override ItemType ItemType { get; } = ItemType.Crown;

        public override string TileName { get; } = "crown";

        public override bool GetCollected(Character character)
        {
            character.ItemsCollected.AddItemToTheCollection(this);
            return true;
        }
    }
}