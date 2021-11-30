using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorCtrl : MonoBehaviour
{
    public doorRef door_Ref;
    public List<doorRef> door_connect;
    public bool inZoom = false;
    //public AstarPath pathFinder;
    //private float time = 0;

    //private void Start()
    //{
    //    door_Ref = GameObject.Find("Door").GetComponent<doorRef>();
    //}

    private void Start()
    {
        //pathFinder = GameObject.Find("A*").GetComponent<AstarPath>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inZoom = true;
            //Debug.Log(inZoom);
        }
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inZoom = false;
            //Debug.Log(inZoom);
        }
    }

    private void Update()
    {
        //time += Time.deltaTime;
        //if (time >= 2)
        //{
        //    //pathFinder.Scan();
        //    time = 0;
        //}
        if (Input.GetKeyDown(KeyCode.F) && inZoom)
        {
            if (!door_Ref.isOpen)
            {
                door_Ref.OpenDoor(); 
                //pathFinder.Scan();
            }
                 
            else
            {
                door_Ref.CloseDoor();
                if (door_connect != null)
                {
                    foreach(doorRef d in door_connect)
                    {
                        if (!d.isOpen)
                        {
                            d.OpenDoor();
                            //pathFinder.Scan();

                        }
                            //d.OpenDoor();
                    }
                }
            }
        }
    }
}
