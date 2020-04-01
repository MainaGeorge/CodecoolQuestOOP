using Codecool.Quest.Models.Assets;
using Codecool.Quest.Models.Utilities;

namespace Codecool.Quest.Models.Actors
{
    public class Player : Character
    {

        public override string TileName { get; } = "player";

        public Player(Cell cell) : base(cell)
        {
            Health = 20;
        }

        public override bool DropCollectedItem()
        {
            return true;
        }

        public override bool Fight(Character actor)
        {

            if (Weapons.IsNotVulnerable)
            {
                actor.Health -= 3;
                return actor.DropCollectedItem();
            }

            else if (Weapons.SlightlyVulnerable)
            {
                actor.Health -= 2;
                Health -= 1;
                return actor.DropCollectedItem();
            }

            else
            {
                actor.Health -= 1;
                Health -= 2;
                return actor.DropCollectedItem();
            }

        }

        public (int, int) DirectionToVector(MoveDirection move)
        {
            return move switch
            {
                MoveDirection.Right => (1, 0),
                MoveDirection.Left => (-1, 0),
                MoveDirection.Up => (0, -1),
                MoveDirection.Down => (0, 1),
                _ => (0, 0)
            };
        }

        public void MovePlayer(MoveDirection move)
        {
            var (x, y) = DirectionToVector(move);

            Move(x, y);
        }

        public bool HandleWhatIsInTheCell(Actor actor)
        {
            return actor switch
            {
                Item collectable => collectable.GetCollected(this),
                Character fighter => Fight(fighter),
                _ => false
            };
        }
    }
}