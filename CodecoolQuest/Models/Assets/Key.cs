using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models.Assets
{
    public class Key : Actor, ICollectable
    {
        public Key(Cell cell) : base(cell)
        {
        }

        public override string TileName { get; } = "key";

        public bool GetCollected(Player player)
        {
            player.ItemsCollected.Key = this;
            player.ItemsCollected.AddItemToTheCollection(this);
            return true;
        }


    }
}