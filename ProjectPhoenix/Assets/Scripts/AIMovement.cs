using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    private GameObject room;
    public GameObject[] rooms;
    private Vector3 AiDestination;
    private NavMeshAgent agent;
    [SerializeField]
    private bool patrollingRoom;
    public bool test;
    int whichRoom;
    bool test2 = true;
    GameObject macroAI;
    // Start is called before the first frame update
    void Start()
    {
        macroAI = GameObject.FindGameObjectWithTag("Enemy");
        MacroAI macroAIScript = macroAI.GetComponent<MacroAI>();

        agent = GetComponent<NavMeshAgent>();
        rooms = GameObject.FindGameObjectsWithTag("Room");
    }

    // Update is called once per frame
    void Update()
    {
        if (macroAI.GetComponent<MacroAI>().currentState == MacroAI.States.Wandering && test2 == true)
        {
            Debug.Log("It's alive");
            test2 = false;
        }

        Debug.Log(AiDestination);

        if (!patrollingRoom)
        {
            room = rooms[UnityEngine.Random.Range(0, rooms.Length)];
            AiDestination = GetRandomPosInsideBox(room.transform.position, room.GetComponent<Collider>().bounds.size);

            if (Physics.CheckSphere(AiDestination, 0.5f))
            {
                agent.SetDestination(AiDestination);
                patrollingRoom = true;
            }

        }
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= 0.5f)
            {
                Invoke("ResetRoomPatrol", 2);
            }
        }


    }
    void ResetRoomPatrol()
    {
        CancelInvoke("ResetRoomPatrol");
        patrollingRoom = false;
    }


    Vector3 GetRandomPosInsideBox(Vector3 center, Vector3 size)
    {
        Vector3 rndP = new Vector3(size.x * (UnityEngine.Random.value - .5f), 0, size.z * (UnityEngine.Random.value - .5f));
        return center + rndP;

    }
}
