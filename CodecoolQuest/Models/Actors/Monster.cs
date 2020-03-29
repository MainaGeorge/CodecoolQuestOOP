using Codecool.Quest.Models.Utilities;

namespace Codecool.Quest.Models.Actors
{
    public class Monster : Actor, IFights
    {
        public Monster(Cell cell) : base(cell)
        {
        }

        public override string TileName { get; } = "monster";

        public int Health { get; set; } = 10;
        public Weapons Weapons { get; set; }
        public bool IsDead => Health <= 0;
        public bool Fight(IFights actor)
        {
            throw new System.NotImplementedException();
        }
    }
}