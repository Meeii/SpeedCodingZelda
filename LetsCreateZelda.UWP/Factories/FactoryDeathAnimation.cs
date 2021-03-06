﻿//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using LetsCreateZelda.UWP.Components;
using LetsCreateZelda.UWP.Components.DeathAnimations;
using LetsCreateZelda.UWP.Manager;
using Microsoft.Xna.Framework;

namespace LetsCreateZelda.UWP.Factories
{
    class FactoryDeathAnimation
    {
        private static ManagerCamera _camera; 

        public static void Initailize(ManagerCamera camera)
        {
            _camera = camera; 
        }

        public static BaseObject GetDeathAnimationObject(DeathAnimation deathAnimation, Vector2 position)
        {
            var baseObject = new BaseObject {Id = "deathAnimation"};
            switch (deathAnimation)
            {
                    case DeathAnimation.Explosion:
                    baseObject.AddComponent(new Sprite(ManagerContent.LoadTexture("death_effect"), 16, 16, position));
                    baseObject.AddComponent(new Animation(16, 16, 3,100));
                    baseObject.AddComponent(new DeathAnimationExplosion());
                    baseObject.AddComponent(new Camera(_camera));
                    break; 
            }

            return baseObject;
        }
    }
}




