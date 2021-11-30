using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReScan : MonoBehaviour
{
    public doorRef door_1;
    public doorRef door_2;
    public doorRef door_3;
    public doorRef door_4;
    public doorRef door_5;
    public doorRef door_6;
    public doorRef door_7;
    public doorRef door_8;
    public doorRef door_9;
    public doorRef door_10;
    public AstarPath pathFinder;

    //bool isScan = false;
    float time = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1)
        {
            if (door_1.stateChange == true)
            {
                pathFinder.Scan();
                door_1.stateChange = false;
            }
            if (door_2.stateChange == true)
            {
                pathFinder.Scan();
                door_2.stateChange = false;
            }
            if (door_3.stateChange == true)
            {
                pathFinder.Scan();
                door_3.stateChange = false;
            }
            if (door_4.stateChange == true)
            {
                pathFinder.Scan();
                door_4.stateChange = false;
            }
            if (door_5.stateChange == true)
            {
                pathFinder.Scan();
                door_5.stateChange = false;
            }
            if (door_6.stateChange == true)
            {
                pathFinder.Scan();
                door_6.stateChange = false;
            }
            if (door_7.stateChange == true)
            {
                pathFinder.Scan();
                door_7.stateChange = false;
            }
            if (door_8.stateChange == true)
            {
                pathFinder.Scan();
                door_8.stateChange = false;
            }
            if (door_9.stateChange == true)
            {
                pathFinder.Scan();
                door_9.stateChange = false;
            }
            if (door_10.stateChange == true)
            {
                pathFinder.Scan();
                door_10.stateChange = false;
            }
            time = 0;
        }
    }
}
