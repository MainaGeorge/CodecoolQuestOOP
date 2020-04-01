namespace Codecool.Quest.Models.Actors
{
    public class Skeleton : Character, IEnemy
    {
        public Skeleton(Cell cell) : base(cell)
        {
            Health = 15;
        }

        public override string TileName { get; } = "skeleton";

        public override bool Fight(Character actor)
        {

            if (!(actor is IEnemy) || actor.Weapons.IsNotVulnerable) return false;
            actor.Health -= 1;
            return actor.IsDead;

        }

        public override bool DropCollectedItem()
        {
            return IsDead;
        }
    }
}