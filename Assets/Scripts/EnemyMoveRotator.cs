using UnityEngine;

public class EnemyMoveRotator : MonoBehaviour
{
    [SerializeField] private float _angle;
    private Contexts _contexts;

    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EntityLink link))
        {
            if (link.LinkedEntity.isEnemy && link.LinkedEntity.hasMove)
            {
                Vector3 newMove = Quaternion.AngleAxis(_angle, Vector3.up) * link.LinkedEntity.move.Movement;
                link.LinkedEntity.ReplaceMove(newMove);
            }
        }
    }
}
