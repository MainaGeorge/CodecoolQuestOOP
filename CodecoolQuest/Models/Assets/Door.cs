using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models.Assets
{
    public class Door : Actor, IOpenable
    {

        public Door(Cell cell) : base(cell)
        {
        }

        public override string TileName { get; } = "door";

        public bool OpenDoor(Player player)
        {
            return player.ItemsCollected.Key != null;
        }
    }
}