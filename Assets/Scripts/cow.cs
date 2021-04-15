using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class cow : MonoBehaviour
{
    public List<Transform> targets;
    Transform closest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targets.Count > 0)
        {
            
            float closestDistance = Mathf.Infinity;
            foreach(Transform obj in targets)
            {
                float Distance = Vector3.Distance(transform.position, obj.position);
                if(Distance < closestDistance)
                {
                    closest = obj;
                    closestDistance = Distance;
                }
            }

            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = closest.position;
        }
        else
        {
            closest = null;
        }



    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targets.Add(other.gameObject.transform);
        }
    }
}
