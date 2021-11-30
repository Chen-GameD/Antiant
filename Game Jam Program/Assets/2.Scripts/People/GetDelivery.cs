using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDelivery : MonoBehaviour
{
    //private void OnCollisionEnter2D(Collision2D coll)
    //{
    //    Debug.Log("撞到了");
    //    if (coll.gameObject.tag == "Delivery")
    //    {
    //        //处理快递
    //        Destroy(coll.gameObject, 5f);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("撞到了");
        if (coll.gameObject.tag == "Delivery")
        {
            //处理快递
            Destroy(coll.gameObject, 5f);
        }
        if (coll.gameObject.tag == "Ant")
        {
            //处理游戏结束
            Time.timeScale = 0;
        }
    }
}
