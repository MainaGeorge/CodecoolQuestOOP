using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models.Assets
{
    public class Sword : Actor, ICollectable
    {
        public Sword(Cell cell) : base(cell)
        {
        }

        public override string TileName { get; } = "sword";
        public bool GetCollected(Player player)
        {
            player.Weapons.Sword = true;
            player.ItemsCollected.AddItemToTheCollection(this);
            return true;

        }
    }
}