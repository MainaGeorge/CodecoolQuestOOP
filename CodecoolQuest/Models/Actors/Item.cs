using Codecool.Quest.Models.Utilities;

namespace Codecool.Quest.Models.Actors
{
    public abstract class Item : Actor
    {
        public abstract bool GetCollected(Character character);

        public abstract ItemType ItemType { get; }

        protected Item(Cell cell) : base(cell)
        {
        }
    }
}