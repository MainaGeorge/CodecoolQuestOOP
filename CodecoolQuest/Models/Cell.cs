using System;
using Codecool.Quest.Models.Actors;
using Codecool.Quest.Models.Assets;
using Codecool.Quest.Models.Utilities;

namespace Codecool.Quest.Models
{
    public class Cell : IDrawable
    {
        public Actor Actor { get; set; }


        public CellType CellType { get; set; }

        public int X { get; }
        public int Y { get; }

        public string TileName => CellType.ToString("g").ToLowerInvariant();

        private readonly GameMap _gameMap;

        public Cell(GameMap gameMap, int x, int y, CellType cellType)
        {
            _gameMap = gameMap;
            X = x;
            Y = y;
            CellType = cellType;
        }

        public Cell GetNeighbor(int dx, int dy)
        {
            return _gameMap.GetCell(X + dx, Y + dy) ?? this;
        }

        public Cell GetNeighbor(Neighbour neighbour)
        {
            return neighbour switch
            {
                Neighbour.Right => GetNeighbor(1, 0),
                Neighbour.Left => GetNeighbor(-1, 0),
                Neighbour.Top => GetNeighbor(0, -1),
                Neighbour.Bottom => GetNeighbor(0, 1),
                _ => throw new ArgumentOutOfRangeException(nameof(neighbour), neighbour, null)
            };
        }

        public bool IsCellFree()
        {
            return CellType == CellType.Floor && Actor == null;
        }

        public void ClearCell()
        {
            this.Actor = null;
        }

    }
}