using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target; // The target the enemy will follow (e.g., the player)
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer(){
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }
}