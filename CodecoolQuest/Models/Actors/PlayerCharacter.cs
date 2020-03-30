using Codecool.Quest.Models.Utilities;

namespace Codecool.Quest.Models.Actors
{
    public abstract class PlayerCharacter : Actor
    {
        protected PlayerCharacter(Cell cell) : base(cell)
        {
            Weapons = new Weapons();
        }

        public int Health { get; set; }

        public Weapons Weapons { get; set; }

        public bool IsDead => Health <= 0;

        public abstract bool Fight(PlayerCharacter actor);

        public void Move(int dx, int dy)
        {
            var nextCell = Cell.GetTheNeighbouringCell(dx, dy);
            Cell.Actor = null;
            nextCell.Actor = this;
            Cell = nextCell;
        }



    }
}