using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Delivery : MonoBehaviour
{
    public Transform pos;
    public PeopleTrace pT;

    private void Start()
    {
        pos = GetComponent<Transform>();
    }

    private void OnDestroy()
    {
        Debug.Log("删除");
        pT.deliveryArr = new Delivery[1];
    }
}
