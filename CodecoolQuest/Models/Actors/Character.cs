using Codecool.Quest.Models.Utilities;

namespace Codecool.Quest.Models.Actors
{
    public abstract class Character : Actor
    {
        protected Character(Cell cell) : base(cell)
        {
            Weapons = new Weapons();
            ItemsCollected = new ItemsCollected();
        }
        public abstract bool DropCollectedItem();

        public int Health { get; set; }

        public Weapons Weapons { get; set; }
        public ItemsCollected ItemsCollected { get; set; }

        public bool IsDead => Health <= 0;

        public abstract bool Fight(Character actor);

        public void Move(int dx, int dy)
        {
            var nextCell = Cell.GetTheNeighbouringCell(dx, dy);
            Cell.Actor = null;
            nextCell.Actor = this;
            Cell = nextCell;
        }



    }
}