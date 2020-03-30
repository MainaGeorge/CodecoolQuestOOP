using System;
using Codecool.Quest.Models;
using Codecool.Quest.Models.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Codecool.Quest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class CodecoolQuestGame : Game
    {
        public static CodecoolQuestGame GameSingleton;

        public SpriteBatch SpriteBatch;

        private GameMap _map;
        private TimeSpan _lastMoveTime;

        public const double MoveInterval = 0.1;

        public CodecoolQuestGame()
        {
            GameSingleton = this;

            using var graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Window.AllowUserResizing = true;
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();

            _lastMoveTime = TimeSpan.Zero;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            GUI.Load();
            Tiles.Load();

            _map = MapLoader.LoadMap();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape) || _map.Player.IsDead)
            {
                // Exit the game
                Exit();
                return;
            }

            var deltaTime = gameTime.TotalGameTime - _lastMoveTime;

            if (deltaTime.TotalSeconds < MoveInterval)
                return;

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                // Move left
                var nextCell = _map.Player.Cell.GetTheNeighbouringCell(Neighbour.Left);

                if (nextCell.IsCellFree())
                {
                    _map.Player.MovePlayer(MoveDirection.Left);
                }
                else
                {
                    var hasTheItemInCellBeenHandled = _map.Player.HandleWhatIsInTheCell(nextCell.Actor);
                    if (hasTheItemInCellBeenHandled)
                    {
                        nextCell.ClearCell();
                        _map.Player.MovePlayer(MoveDirection.Left);
                    }
                }
                _lastMoveTime = gameTime.TotalGameTime;
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                // Move right
                var nextCell = _map.Player.Cell.GetTheNeighbouringCell(Neighbour.Right);

                if (nextCell.IsCellFree())
                {
                    _map.Player.MovePlayer(MoveDirection.Right);
                }
                else
                {
                    var hasTheItemInCellBeenHandled = _map.Player.HandleWhatIsInTheCell(nextCell.Actor);
                    if (hasTheItemInCellBeenHandled)
                    {
                        nextCell.ClearCell();
                        _map.Player.MovePlayer(MoveDirection.Right);
                    }
                }

                _lastMoveTime = gameTime.TotalGameTime;
            }
            else if (keyboardState.IsKeyDown(Keys.Up))
            {
                // Move up
                var nextCell = _map.Player.Cell.GetTheNeighbouringCell(Neighbour.Top);

                if (nextCell.IsCellFree())
                {
                    _map.Player.MovePlayer(MoveDirection.Up);
                }
                else
                {
                    var hasTheItemInCellBeenHandled = _map.Player.HandleWhatIsInTheCell(nextCell.Actor);
                    if (hasTheItemInCellBeenHandled)
                    {
                        nextCell.ClearCell();
                        _map.Player.MovePlayer(MoveDirection.Up);

                    }
                }
                _lastMoveTime = gameTime.TotalGameTime;
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                // Move down
                var nextCell = _map.Player.Cell.GetTheNeighbouringCell(Neighbour.Bottom);

                if (nextCell.IsCellFree())
                {
                    _map.Player.MovePlayer(MoveDirection.Down);

                }
                else
                {
                    var hasTheItemInCellBeenHandled = _map.Player.HandleWhatIsInTheCell(nextCell.Actor);
                    if (hasTheItemInCellBeenHandled)
                    {
                        nextCell.ClearCell();
                        _map.Player.MovePlayer(MoveDirection.Down);
                    }
                }

                _lastMoveTime = gameTime.TotalGameTime;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque, SamplerState.PointClamp);

            for (var x = 0; x < _map.Width; x++)
            {
                for (var y = 0; y < _map.Height; y++)
                {
                    var cell = _map.GetCell(x, y);

                    if (cell.Actor != null)
                    {
                        Tiles.DrawTile(SpriteBatch, cell.Actor, x, y);
                    }
                    else
                    {
                        Tiles.DrawTile(SpriteBatch, cell, x, y);
                    }
                }
            }

            GUI.Text(new Vector2(900, 25), $"Player Health {_map.Player.Health}", Color.BlanchedAlmond);

            GUI.Text(new Vector2(900, 50), "items collected".ToUpperInvariant(), Color.AliceBlue);

            ShowCollectedItems(_map, 900, 75, 25);


            SpriteBatch.End();

            base.Draw(gameTime);
        }

        private void ShowCollectedItems(GameMap map, int width, int height, int spaceBetweenWords)
        {
            var itemsToDisplay = _map.Player.ItemsCollected.AllItems;
            for (var i = 0; i < itemsToDisplay.Count; i++)
            {
                GUI.Text(new Vector2(width, height + (i * spaceBetweenWords)),
                    itemsToDisplay[i].TileName.ToUpperInvariant(), Color.Aqua);

            }
        }

    }
}
