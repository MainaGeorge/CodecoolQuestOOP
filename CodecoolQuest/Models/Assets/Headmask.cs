using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models.Assets
{
    public class Headmask : Actor, ICollectable
    {
        public Headmask(Cell cell) : base(cell)
        {
        }

        public override string TileName { get; } = "headmask";
        public bool GetCollected(Player player)
        {
            player.Weapons.Headmask = true;
            player.ItemsCollected.AddItemToTheCollection(this);
            return true;

        }
    }
}