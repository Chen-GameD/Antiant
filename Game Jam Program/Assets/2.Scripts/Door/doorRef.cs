using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorRef : MonoBehaviour
{
    public Animator anim;
    public bool isOpen = false;
    public bool stateChange = false;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void OpenDoor()
    {
        Debug.Log("11");
        anim.SetBool("IsOpen", true);
        isOpen = true;
        stateChange = true;
    }

    public void CloseDoor()
    {
        Debug.Log("22");
        anim.SetBool("IsOpen", false);
        isOpen = false;
        stateChange = true;
    }
}
