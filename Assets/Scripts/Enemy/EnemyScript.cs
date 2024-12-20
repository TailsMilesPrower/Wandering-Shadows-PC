using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public List<Transform> waypointPos = new List<Transform>();
    public int index = 0;
    public bool forward = true;
    public float time;
    public bool isPlayerInRange;
    public Transform targetObject;
    [SerializeField] EnemyRaycast enemyRaycast;

    // Tor Arne, Kri & Jonas helped me with this code

    void Start()
    {
        agent.SetDestination(waypointPos[index].position);
    }
    // Sprinkle messages throughout my code, and try to fix the enemy location and the enemy raycast.
    // Update is called once per frame
    void Update()
    {
        if (DestinationReached())
        {
            SetNextWaypoint();
            Debug.Log("ello");

        }
        else if (isPlayerInRange == true)
        {
            Debug.Log("I am chasing");
            ChasePlayer();
        }

    }

    private void ChasePlayer()
    {
        SceneManager.LoadScene("EndMenu");
        transform.position = Vector3.MoveTowards(transform.position, targetObject.position, 10 * Time.deltaTime);
    }

    private bool DestinationReached()
    {
        float distance = Vector3.Distance(transform.position, waypointPos[index].position);
        return distance < 1.7f;
    }

    private void SetNextWaypoint()
    {
        if (forward)
        {
            /*
            bool underwaypointCheck = index + 1 < waypointPos.Count;
            index = (underwaypointCheck) ? index + 1 : index - 1;
                        if (!underwaypointCheck)
            {
                forward = false;
            }*/
            index++;
            if (index == waypointPos.Count - 1) 
            {
                forward = false;
                /*if (isPlayerInRange == true)
                {
                    ChasePlayer();
                }*/
            }
            else if (isPlayerInRange == true)
            {
                ChasePlayer();
            }

            // Move Character
            agent.SetDestination(waypointPos[index].position);
        }
        else
        {
            /*
            bool underwaypointCheck = index - 1 > 0;
            index = (underwaypointCheck) ? index - 1 : 1;

            if (!underwaypointCheck)
            {
                forward = true;
            }
            */

            index--;
            if (index == 0)
            {
                forward = true;
                /*if (isPlayerInRange == true)
                {
                    ChasePlayer();
                }*/
            }
            else if (isPlayerInRange == true)
            {
                ChasePlayer();
            }

                // Move Character
                agent.SetDestination(waypointPos[index].position);
        }

    }
}
