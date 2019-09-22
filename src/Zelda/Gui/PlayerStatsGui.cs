﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Components;
using Zelda.Manager;

namespace Zelda.Gui
{
    public class PlayerStatsGui
    {
        private readonly int _lessY;
        private Texture2D _rupeeTexture;
        private Texture2D _heartTexture;
        private Texture2D _containerTexture;
        private Texture2D _backgroundTexture;
        private SpriteFont _font;
        private Stats _stats;
        private Equipment _equipment;

        public PlayerStatsGui(WindowPosition windowPosition = WindowPosition.Down)
        {
            if (windowPosition == WindowPosition.Up)
            {
                _lessY = 128;
            }
        }

        public void LoadContent(ContentManager content)
        {
            _rupeeTexture = ManagerContent.LoadTexture("rupee_gui");
            _heartTexture = ManagerContent.LoadTexture("heart_gui");
            _containerTexture = ManagerContent.LoadTexture("container_gui");
            _font = ManagerContent.LoadFont("Font_GUI");
            _backgroundTexture = ManagerContent.LoadTexture("white_background");
        }

        public void Update(Stats stats, Equipment equipment)
        {
            _stats = stats;
            _equipment = equipment;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_stats == null)
            {
                return;
            }

            spriteBatch.Draw(_backgroundTexture, new Rectangle(0, 128 - _lessY, 160, 16), new Color(245, 245, 135));

            spriteBatch.Draw(_containerTexture, new Rectangle(9, 130 - _lessY, 30, 12), Color.Black);
            spriteBatch.DrawString(_font, "B", new Vector2(1, 129 - _lessY), Color.Black);
            _equipment?.DrawGui(spriteBatch, ItemSlot.A, new Rectangle(12, 131 - _lessY, 22, 10));

            spriteBatch.Draw(_containerTexture, new Rectangle(47, 130 - _lessY, 30, 12), Color.Black);
            spriteBatch.DrawString(_font, "A", new Vector2(40, 129 - _lessY), Color.Black);
            _equipment?.DrawGui(spriteBatch, ItemSlot.B, new Rectangle(50, 131 - _lessY, 22, 10));

            spriteBatch.Draw(_rupeeTexture, new Rectangle(80, 130 - _lessY, 9, 9), Color.White);
            spriteBatch.DrawString(_font, "999", new Vector2(80, 135 - _lessY), Color.Black);

            for (int n = 0; n < _stats.CurrentHealth; n++)
            {
                spriteBatch.Draw(_heartTexture, new Rectangle(100 + (n * 10), 130 - _lessY, 9, 9), Color.White);
            }
        }
    }
}