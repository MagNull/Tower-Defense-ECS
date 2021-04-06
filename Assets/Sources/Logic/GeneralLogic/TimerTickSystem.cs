using System;
using Entitas;
using UnityEngine;

namespace Sources.Logic.GeneralLogic
{
    public class TimerTickSystem : IExecuteSystem  
    {
        private Contexts _contexts;
        private IGroup<GameEntity> _timers;

        public TimerTickSystem(Contexts contexts) 
        {
            _contexts = contexts;
            _timers = _contexts.game.GetGroup(GameMatcher.Timer);
        }

        public void Execute() //TODO: Fix entity.RemoveTimer() (Collection modification error)
        {
            if (!_contexts.game.globals.value.IsPaused)
            {
                try
                {
                    foreach (var entity in _timers)
                    {
                        float tick = entity.timer.Tick - Time.deltaTime;
                        if (tick <= 0)
                        {
                            Action a = entity.timer.Action;
                            if (entity.timer.IsLoop)
                            {
                                entity.ReplaceTimer(entity.timer.StartTick,
                                    entity.timer.StartTick,
                                    entity.timer.Action,
                                    entity.timer.IsLoop);
                            }
                            else
                            {
                                entity.RemoveTimer();
                            }
                            a.Invoke();
                        }
                        else
                        {
                            entity.ReplaceTimer(entity.timer.StartTick,
                                tick, 
                                entity.timer.Action,
                                entity.timer.IsLoop);
                        }
                    }
                }
                catch 
                {
                    
                }
                
            }
        }
    }
}