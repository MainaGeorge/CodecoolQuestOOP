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

        private GameMap gameMap;
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

            gameMap = MapLoader.LoadMap();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape) || gameMap.Player.IsDead)
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
                MovePlayer(gameMap, MoveDirection.Left, NeighbouringCell.Left);
                _lastMoveTime = gameTime.TotalGameTime;
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                MovePlayer(gameMap, MoveDirection.Right, NeighbouringCell.Right);
                _lastMoveTime = gameTime.TotalGameTime;
            }
            else if (keyboardState.IsKeyDown(Keys.Up))
            {
                MovePlayer(gameMap, MoveDirection.Up, NeighbouringCell.Top);
                _lastMoveTime = gameTime.TotalGameTime;
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                MovePlayer(gameMap, MoveDirection.Down, NeighbouringCell.Bottom);
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

            for (var x = 0; x < gameMap.Width; x++)
            {
                for (var y = 0; y < gameMap.Height; y++)
                {
                    var cell = gameMap.GetCell(x, y);

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

            GUI.Text(new Vector2(900, 25), $"Player Health {gameMap.Player.Health}", Color.BlanchedAlmond);

            GUI.Text(new Vector2(900, 50), "items collected".ToUpperInvariant(), Color.AliceBlue);

            ShowCollectedItems(900, 75, 25, gameMap);


            SpriteBatch.End();

            base.Draw(gameTime);
        }

        private static void ShowCollectedItems(int width, int height, int spaceBetweenWords, GameMap gameMap)
        {
            var itemsToDisplay = gameMap.Player.ItemsCollected.AllItems;
            for (var i = 0; i < itemsToDisplay.Count; i++)
            {
                GUI.Text(new Vector2(width, height + (i * spaceBetweenWords)),
                    itemsToDisplay[i].TileName.ToUpperInvariant(), Color.Aqua);

            }
        }

        private static void MovePlayer(GameMap gameMap,
            MoveDirection moveDirection, NeighbouringCell neighbouringCell)
        {
            var neighbourCell = gameMap.Player.Cell.GetTheNeighbouringCell(neighbouringCell);

            if (neighbourCell.IsCellFree())
            {
                gameMap.Player.MovePlayer(moveDirection);
            }
            else
            {
                var hasTheItemInCellBeenHandled = gameMap.Player.HandleWhatIsInTheCell(neighbourCell.Actor);
                if (hasTheItemInCellBeenHandled)
                {
                    neighbourCell.ClearCell();
                    gameMap.Player.MovePlayer(moveDirection);
                }
            }
        }

    }
}
