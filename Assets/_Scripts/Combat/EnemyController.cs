using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;

    //patrol
    // public Vector3 walkPoint;
    // bool walkPointSet;
    // public float walkPointRange;

    // //a2
    // public float range;
    // public Transform centrePoint;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        // player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        // centrePoint = agent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                // Attack
                FaceTarget();
            }
        }
        // if (distance >= lookRadius)
        // {
        //     Patrol();
        // }
        // if(distance > lookRadius) 
        // {
        //     Vector3 point;
        //     if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
        //     {
        //         Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
        //         agent.SetDestination(point);
        //     }
        // }
        
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    // void Patrol()
    // {   
    //     if (!walkPointSet) SearchWalkPoint();
        
    //     if (walkPointSet)
    //         agent.SetDestination(walkPoint);
        
    //     Vector3 distanceToWalkPoint = transform.position - walkPoint;
    //     //reached
    //     if (distanceToWalkPoint.magnitude < 1f)
    //         walkPointSet = false;


    // }
    // void SearchWalkPoint()
    // {
    //     //find random point in range
    //     float randomZ = Random.Range(-walkPointRange, walkPointRange);
    //     float randomX = Random.Range(-walkPointRange, walkPointRange);

    //     walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
    //     // check if its in map
    //     // if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
    //     walkPointSet = true;
    // }
    // bool RandomPoint(Vector3 center, float range, out Vector3 result)
    // {

    //     Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
    //     NavMeshHit hit;
    //     if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
    //     { 
    //         //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
    //         //or add a for loop like in the documentation
    //         result = hit.position;
    //         return true;
    //     }

    //     result = Vector3.zero;
    //     return false;
    // }

}
