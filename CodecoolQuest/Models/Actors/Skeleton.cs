using Codecool.Quest.Models.Utilities;

namespace Codecool.Quest.Models.Actors
{
    public class Skeleton : PlayerCharacter
    {
        public Skeleton(Cell cell) : base(cell)
        {
            Health = 15;
        }

        public override string TileName { get; } = "skeleton";

        public override bool Fight(PlayerCharacter actor)
        {

            if (!(actor is IPlayer) || actor.Weapons.IsNotVulnerable) return false;
            actor.Health -= 1;
            return actor.IsDead;

        }
    }
}