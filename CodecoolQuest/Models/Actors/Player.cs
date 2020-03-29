using Codecool.Quest.Models.Assets;
using Codecool.Quest.Models.Utilities;

namespace Codecool.Quest.Models.Actors
{
    public class Player : Actor, IFights
    {

        public override string TileName { get; } = "player";

        public int Health { get; set; } = 20;

        public Weapons Weapons { get; set; }

        public bool IsDead => Health <= 0;
        public ItemsCollected ItemsCollected { get; set; }

        public Player(Cell cell) : base(cell)
        {
            Weapons = new Weapons();
            ItemsCollected = new ItemsCollected();
        }


        public bool Fight(IFights actor)
        {
            var isOpponentDead = false;
            if (Weapons.Sword && Weapons.Headmask && Weapons.Gun)
            {
                actor.Health -= 3;
                isOpponentDead = actor.IsDead;
            }

            else if (Weapons.Sword)
            {
                actor.Health -= 1;
                Health -= 2;
                isOpponentDead = actor.IsDead;
            }

            else if (Weapons.Gun)
            {
                actor.Health -= 1;
                Health -= 2;
                isOpponentDead = actor.IsDead;
            }

            else if (Weapons.Sword && Weapons.Gun)
            {
                actor.Health -= 2;
                Health -= 1;
            }

            return isOpponentDead;
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

            switch (actor)
            {
                case ICollectable collectable:
                    return collectable.GetCollected(this);

                case IFights fighter:
                    return Fight(fighter);


                case IOpenable openableDoor:
                    return openableDoor.OpenDoor(this);


                default:
                    return false;
            }

        }
    }
}