﻿using System.Threading;

namespace Codecool.Quest.Models.Actors
{

    public abstract class Actor : IDrawable
    {
        public Cell Cell { get; private set; }

        public int X => Cell.X;

        public int Y => Cell.Y;

        public abstract string TileName { get; }

        protected Actor(Cell cell)
        {
            Cell = cell;
            Cell.Actor = this;
        }

        public void Move(int dx, int dy)
        {
            var nextCell = Cell.GetTheNeighbouringCell(dx, dy);
            Cell.Actor = null;
            nextCell.Actor = this;
            Cell = nextCell;
        }


    }
}