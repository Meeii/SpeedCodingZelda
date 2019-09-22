﻿//------------------------------------------------------
using System.Collections.Generic;
using Zelda.Common;

namespace Zelda.Manager
{
    public class ManagerLists
    {
        private static Dictionary<int, EventSwitch> _eventSwitches;

        public static bool GetEventSwitchValue(int id)
        {
            return _eventSwitches.ContainsKey(id) && _eventSwitches[id].Value;
        }

        public static void SetEventSwitch(int id, EventSwitch eventSwitch)
        {
            if (!_eventSwitches.ContainsKey(id))
            {
                _eventSwitches.Add(id, eventSwitch);
                return;
            }

            _eventSwitches[id] = eventSwitch;
        }

        public static void SetEventSwitchValue(int id, bool value)
        {
            if (_eventSwitches.ContainsKey(id))
            {
                _eventSwitches[id].Value = value;
            }
        }

        public void Initialize()
        {
            _eventSwitches = new Dictionary<int, EventSwitch>();
            _eventSwitches.Add(0, new EventSwitch { Description = "Default", Value = true });
            _eventSwitches.Add(1, new EventSwitch { Description = "test1", Value = false });
            _eventSwitches.Add(2, new EventSwitch { Description = "test2", Value = false });
        }
    }
}