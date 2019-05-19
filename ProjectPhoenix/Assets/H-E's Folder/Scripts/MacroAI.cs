using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacroAI : MonoBehaviour
{

    public enum States
    {
        //InRoom1,
        //InRoom2,
        //WalkingToRoom1,
        //WalkingToRoom2,
        Wandering,
        Hunting,
        Guarding,
    }

    public GameObject currentZone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        currentZone = other.gameObject;
    }
}
