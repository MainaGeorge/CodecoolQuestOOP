using Codecool.Quest.Models.Assets;
using Codecool.Quest.Models.Utilities;

namespace Codecool.Quest.Models.Actors
{
    public class Monster : Character, IEnemy
    {
        public Monster(Cell cell) : base(cell)
        {
            Health = 15;
        }

        public override string TileName { get; } = "monster";

        public override bool Fight(Character actor)
        {
            if (!(actor is IEnemy) || actor.Weapons.IsNotVulnerable) return false;
            actor.Health -= 2;
            return actor.IsDead;
        }

        public override bool DropCollectedItem()
        {
            if (!IsDead) return false;

            var topCell = this.Cell.GetTheNeighbouringCell(NeighbouringCell.Top);
            var bottomCell = this.Cell.GetTheNeighbouringCell(NeighbouringCell.Bottom);

            var cell = topCell.IsCellFree() ? topCell : bottomCell;

            var crown = new Crown(cell);
            cell.Actor = crown;

            return true;
        }
    }
}