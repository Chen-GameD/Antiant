using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public Animator anim;

    //获取到的快递数量
    public int delGetNum = 0;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        float xPosition = Input.GetAxis("Horizontal") * speed;
        float yPosition = Input.GetAxis("Vertical") * speed;

        if (Input.GetKey("a")||Input.GetKey("d")||Input.GetKey("w")||Input.GetKey("s"))
        {
            transform.Translate(xPosition, yPosition, 0);
            //animator.SetBool("isWalking", true);
        }

        anim.SetFloat("speed", Mathf.Abs(xPosition)+Mathf.Abs(yPosition));

        //else animator.SetBool("isWalking", false);
    }
}
