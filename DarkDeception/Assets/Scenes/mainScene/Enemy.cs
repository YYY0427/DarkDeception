using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�ǂ�������Ώ�")]
    //   private GameObject target;
    public Transform target;
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            navMeshAgent.destination =target.position; 
        //    navMeshAgent.SetDestination(target.position);
        //   navMeshAgent.destination = target.transform.position;
        }
    }
}
