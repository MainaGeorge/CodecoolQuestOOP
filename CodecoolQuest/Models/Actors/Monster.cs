using Codecool.Quest.Models.Utilities;

namespace Codecool.Quest.Models.Actors
{
    public class Monster : PlayerCharacter
    {
        public Monster(Cell cell) : base(cell)
        {
            Health = 15;
        }

        public override string TileName { get; } = "monster";

        public override bool Fight(PlayerCharacter actor)
        {
            if (!(actor is IPlayer) || actor.Weapons.IsBulletProof) return false;
            actor.Health -= 2;
            return actor.IsDead;

        }
    }
}