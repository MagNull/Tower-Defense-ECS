using System;
using Entitas;

[Game]
public class TimerComponent : IComponent
{
    public float Tick;
    public Action Action;
}