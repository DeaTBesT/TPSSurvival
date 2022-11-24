using UnityEngine;
using UnityEngine.AI;

public class UnitMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;

    public virtual void SetPoint(Vector3 point)
    {
        navMeshAgent.SetDestination(point);
    }
}
