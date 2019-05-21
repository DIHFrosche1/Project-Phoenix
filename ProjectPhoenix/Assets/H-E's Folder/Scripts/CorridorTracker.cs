using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// This script will keep track of how many times the player has walked past a certain point within the last couple of minutes. 
/// If the player walks past a certain point more than X amount of times within the time frame it will alert the AI to Hunt there or Guard there.
/// Place this script on every key point of the map, set a time limit (so that it doesn't keep track of a place you haven't been in in a very long time) and set an "alert" cap (how many times you have to pass by before it alerts the AI)
/// The Alert cap can be 2 different variables so that it adds a random element to if the AI is alerted or not. The min value is the amount of times the player has to pass by the point before there is a chance to alert the AI and the max value is the amount of times the player has to pass by the point for there to be a 100% chance to alert the AI. 
/// There should RARELY be a time where the player raches the max value.
/// 
/// </summary>

public class CorridorTracker : MonoBehaviour
{

    public int timesPassed;
    public int timesPassedMinCap;
    public int timesPassedMaxCap;
    public float timeCap;
    public int chanceOfAlertingOnMin; // Out of 100, so 20 is 20%, 50 if 50% and so on.
    public int chanceModPerPass; // The modification used to increase the likelyhood of the AI being alerted for each additional time you pass a certain point.
    //public int chanceOfAlertingOnMax;

    private float timer;
    private int rand;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeCap)
        {
            timesPassed = 0;
            timer = 0;
        }

        if (timesPassed >= timesPassedMinCap)
        {
            if (timesPassed >= timesPassedMaxCap)
            {
                //Alert the AI
            }
            else
            {
                int newChance = ((timesPassed - timesPassedMinCap) * chanceModPerPass) + chanceOfAlertingOnMin;
                if (rand <= newChance)
                {
                    //Alerting the AI
                }
                else
                {
                    //Don't alert the AI
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        timesPassed++;
        timer = 0;
        rand = Random.Range(0, 100);
    }
}
