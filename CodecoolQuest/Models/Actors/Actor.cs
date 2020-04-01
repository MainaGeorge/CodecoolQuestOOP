namespace Codecool.Quest.Models.Actors
{
    public abstract class Actor : IDrawable
    {
        public Cell Cell { get; protected set; }

        public int X => Cell.X;

        public int Y => Cell.Y;

        public abstract string TileName { get; }

        protected Actor(Cell cell)
        {
            Cell = cell;
            Cell.Actor = this;
        }
    }
}