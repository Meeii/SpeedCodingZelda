﻿//------------------------------------------------------
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Zelda.GameEvent;

namespace Zelda.Manager
{
    public class ManagerEvents
    {
        private static List<IGameEvent> _eventList;
        private static int _index;

        public ManagerEvents()
        {
            _eventList = new List<IGameEvent>();
        }

        public static bool Active
        {
            get; private set;
        }

        public static void AddEvents(List<IGameEvent> events)
        {
            if (_eventList == null)
            {
                _eventList = new List<IGameEvent>();
            }

            if (!_eventList.Any())
            {
                _eventList.AddRange(events);
                ResetEvents();
                Active = true;
            }
            else
            {
                _eventList.AddRange(events);
            }
        }

        public void Update(double gameTime)
        {
            if (!_eventList.Any())
            {
                Active = false;
                return;
            }

            if (!_eventList[_index].Done)
            {
                _eventList[_index].Update(gameTime);
            }
            else
            {
                _index++;
                if (_index > _eventList.Count - 1)
                {
                    Active = false;
                    _eventList.Clear();
                }
                else
                {
                    _eventList[_index].Initialize();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_eventList.Any())
            {
                _eventList[_index].Draw(spriteBatch);
            }
        }

        private static void ResetEvents()
        {
            _index = 0;
            if (_eventList.Any())
            {
                _eventList[0].Initialize();
            }
        }
    }
}