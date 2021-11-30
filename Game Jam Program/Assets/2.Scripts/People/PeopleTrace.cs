using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PeopleTrace : MonoBehaviour
{
    //public List<Delivery> del;
    public Delivery curDel;
    //public float count;
    //public float curCount;

    public Delivery[] deliveryArr;

    public List<float> delList;

    public Dictionary<float, Delivery> delDic;

    public AIDestinationSetter aiDesSet;

    //public CircleCollider2D coll;

    private void Start()
    {
        delList = new List<float>();
        delDic = new Dictionary<float, Delivery>();
        aiDesSet = GetComponent<AIDestinationSetter>();
        //coll = GetComponentInChildren<CircleCollider2D>();

        //curDel = del[0];
        //count = Vector3.Distance(del[0].transform.position, transform.position);
        //curCount = Vector3.Distance(del[0].transform.position, transform.position);
    }

    private void FixedUpdate()
    {
        delList.Clear();
        delDic.Clear();
        curDel = CountDistacne();
        //Debug.Log(curDel.name);
        aiDesSet.ChangeTarget(curDel.pos);


        //foreach(Delivery d in del)
        //{
        //    curCount = Vector3.Distance(d.transform.position, transform.position);
        //    if ((int)curCount < (int)count)
        //    {
        //        count = curCount;
        //        curDel = d;
        //    }
        //}
        //Debug.Log(curDel.transform.position);
    }

    //private void OnCollisionEnter2D(Collision2D coll)
    //{
    //    Debug.Log("撞到了");
    //    if (coll.gameObject.tag == "Delivery")
    //    {
    //        //处理快递
    //        Destroy(coll.gameObject, 5f);
    //    }
    //}


    Delivery CountDistacne()
    {
        for (int i = 0; i < deliveryArr.Length; i++)
        {
            if (deliveryArr[i]!= null)
            {
                float dis = Vector3.Distance(deliveryArr[i].pos.localPosition, transform.localPosition);
                delDic.Add(dis, deliveryArr[i]);
                //Debug.Log(dis);
                if (!delList.Contains(dis))
                {
                    delList.Add(dis);
                }
            }
            
        }
        delList.Sort();//对距离进行排序
        //Debug.Log("***" + delList[0]);
        Delivery del;
        delDic.TryGetValue(delList[0], out del);//获取距离最近的对象
        //Debug.Log(del.name);
        return del;
    }

    public Delivery[] ReSortDelivery(Delivery d)
    {
        Delivery[] dA = new Delivery[deliveryArr.Length - 1];
        bool meet = false;
        for (int j = 0; j< dA.Length; j++)
        {
            if (deliveryArr[j].gameObject.name != d.gameObject.name && meet == false)
            {
                dA[j] = deliveryArr[j];
            }
            if (deliveryArr[j].gameObject.name == d.gameObject.name && meet == false)
            {
                meet = true;

            }
            if (meet == true)
            {
                dA[j] = deliveryArr[j + 1];
            }
        }
        return dA;

    }

    public void GetDelivery()
    {

    }
}
