using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Logic.TowerLogic
{
    public class MageShootSystem : ReactiveSystem<GameEntity> 
    {
        private Contexts _contexts;

        public MageShootSystem (Contexts contexts) : base(contexts.game) 
        {
            _contexts = contexts;
        }
		
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Shooter);
        }
		
        protected override bool Filter(GameEntity entity)
        {
            return entity.shooter.Type == TowerType.MAGE;
        }

        protected override void Execute(List<GameEntity> entities) 
        {
            if (!_contexts.game.globals.value.IsPaused)
            {
                foreach (var e in entities)
                {
                    if (!e.hasTimer)
                        e.AddTimer(_contexts.game.globals.value.MageShootDelay, 
                            _contexts.game.globals.value.MageShootDelay, () =>
                            {
                                CreateBlast(e);
                            }, true);
                }
            }
        }
	
        private void CreateBlast(GameEntity e) //TODO: Optimize to 1 blast per tower
        {
            if (e.shooter.Target)
            {
                if (!e.shooter.ShootPoint)
                    e.shooter.ShootPoint = GameObject.Instantiate(
                        _contexts.game.globals.value.MagicBlastPrefab).transform;
                e.shooter.ShootPoint.GetComponent<Collider>().enabled = false;
                e.shooter.ShootPoint.transform.position = e.shooter.Target.position + Vector3.down;
                e.shooter.ShootPoint.transform.parent = e.shooter.Target;
                
                CreateLine(e.view.View.transform.GetChild(0).GetComponent<LineRenderer>(), e.shooter.Target);
                e.shooter.ShootPoint.GetComponent<ParticleSystem>().Play();

                GameEntity blastEntity = _contexts.game.CreateEntity();
                
                blastEntity.AddDamageDealer(_contexts.game.globals.value.MagicBlastDamage, false);
                blastEntity.AddView(e.shooter.ShootPoint.gameObject);
                
                if(e.shooter.ShootPoint.gameObject.TryGetComponent(out EntityLink link)) link.Link(blastEntity);
                else e.shooter.ShootPoint.gameObject.AddComponent<EntityLink>().Link(blastEntity);
                e.shooter.ShootPoint.GetComponent<Collider>().enabled = true;
            }
        }

        private void CreateLine(LineRenderer lineRenderer, Transform target)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(1, lineRenderer.transform.InverseTransformPoint(target.position));
            _contexts.game.CreateEntity().AddTimer(.1f,.1f, () =>
            {
                lineRenderer.enabled = false;
            }, false);
        }
    }
}