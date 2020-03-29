using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models.Assets
{
    public class Gun : Actor, ICollectable
    {
        public Gun(Cell cell) : base(cell)
        {
        }

        public override string TileName { get; } = "gun";
        public bool GetCollected(Player player)
        {

            player.Weapons.Gun = true;
            player.ItemsCollected.AddItemToTheCollection(this);
            return true;
        }
    }
}