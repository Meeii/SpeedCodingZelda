﻿namespace LetsCreateZelda
{
    public enum ComponentType
    {
        Sprite,
        PlayerInput,
        Animation,
        Collision,
        AIMovement,
        EnemyOctorok,
        Camera,
        Items,
        GUI,
        Damage,
        Stats,
        DeathAnimation,
        Script
    }

    public enum Input
    {
        Left,
        Right,
        Up,
        Down,
        None,
        Enter,
        A,
        S,
        Select
    }

    public enum Direction
    {
        Left, 
        Right,
        Up,
        Down
    }


    public enum State
    {
        Standing, 
        Walking,
        Special
    }

    public enum ItemSlot
    {
        A,
        B
    }

    public enum WindowPosition
    {
        Up,
        Down
    }

    public enum GameEventType
    {
        Message,
        EventSwitch
    }

    public enum DeathAnimation
    {
        Link, 
        Explosion
    }
}