﻿//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Manager;
using Zelda.Map;

namespace Zelda.Components.Enemies
{
    class Octorok : Component
    {

        private BaseObject _player;
        private List<OctorokBullet> _bullets;
        private double _counter; 
        private int _cooldown;
        private Texture2D _bulletTexture;
        private ManagerMap _map;
        private Entities _entities; 

        public Octorok(BaseObject player, Texture2D bulletTexture, ManagerMap map,  Entities entities, int cooldown = 2000)
        {
            _player = player; 
            _bullets = new List<OctorokBullet>();
            _cooldown = cooldown;
            _counter = 0;
            _bulletTexture = bulletTexture;
            _map = map;
            _entities = entities; 
        }


        public override void Update(double gameTime)
        {
            _counter += gameTime;

            var i = 0; 
            while(i < _bullets.Count)
            {
               _bullets[i].Update(gameTime);
               if (_bullets[i].Dead)
                   _bullets.RemoveAt(i);
               else
                   i++; 
            }

            if (_counter < _cooldown)
                return; 
            var sprite = GetComponent<Sprite>();
            var playerSprite = _player.GetComponent<Sprite>();
            var animation = GetComponent<Animation>();
            if (sprite == null || animation == null || playerSprite == null)
                return;
            switch (animation.CurrentDirection)
            {
                    case Direction.Up:
                    if(playerSprite.Position.Y < sprite.Position.Y)
                        NewBullet(Direction.Up);
                    break;
                    case Direction.Down:
                    if (playerSprite.Position.Y > sprite.Position.Y)
                        NewBullet(Direction.Down);
                    break;
                    case Direction.Left:
                    if (playerSprite.Position.X < sprite.Position.X)
                        NewBullet(Direction.Left);
                    break;
                    case Direction.Right:
                    if (playerSprite.Position.X > sprite.Position.X)
                        NewBullet(Direction.Right);
                    break; 
            }

            
        }

        private void NewBullet(Direction direction)
        {
            var sprite = GetComponent<Sprite>();
            _bullets.Add(new OctorokBullet(new Sprite(_bulletTexture,10,10,sprite.Position),new Collision(_map,_entities), _player,direction));
             _counter = 0;
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            foreach (var octorokBullet in _bullets)
            {
                octorokBullet.Draw(spritebatch); 
            }
        }
    }
}



