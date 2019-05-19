using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This code will decide what the different states will do for the AI. 
/// 
/// Wandering = walking around between different rooms.
/// Hunting = walking around in a specific room (often to looking for the player the player).
/// Guarding = walking around in a specific area of a room or staying still and watching a specific area.
/// Investigating = going to a place where it has been alerted that the player has walked by X amount of times.
/// 
/// Wandering is the starting state and the state that is the default if the player is not close or the Investigating requierments have been met.
/// Hunting is when the player is close or when the Investigating state has been fullfilled and the room in which the AI should investigate is the same room as the room he is in. Should have a time limit on how long the AI can "hunt"
/// Guaring is like hunting but a smaller than a room area. Should also have a time limit.
/// Investigating can only be activated via the CorridorTracker script.
///  
/// </summary>

public class MacroAI : MonoBehaviour
{

    public enum States
    {
        Wandering,
        Hunting,
        Guarding,
        Investigating,
    }

    public States currentState;
    

    // Start is called before the first frame update
    void Start()
    {
        currentState = States.Wandering;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == States.Wandering)
        {
            //Wander between different rooms.
        }
        else if (currentState == States.Hunting)
        {
            //Pick random points in the room to walk to.
        }
        else if (currentState == States.Guarding)
        {
            //Pick random points within an area of the guarding point.
        }
        else if (currentState == States.Investigating)
        {
            //Go to the specified room and hunt in there.
        }
    }


    
}
