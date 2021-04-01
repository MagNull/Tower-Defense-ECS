using System;
using Entitas;

[Game]
public class TimerComponent : IComponent
{
    public float StartTick;
    public float Tick;
    public Action Action;
    public bool IsLoop;
}