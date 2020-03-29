using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models.Assets
{
    public class Crown : Actor, ICollectable
    {
        public Crown(Cell cell) : base(cell)
        {
        }

        public override string TileName { get; } = "crown";

        public bool GetCollected(Player player)
        {
            player.ItemsCollected.Crown = this;
            player.ItemsCollected.AddItemToTheCollection(this);
            return true;
        }
    }
}