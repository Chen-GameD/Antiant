using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSpinner : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Vector3 direction;
    bool moveV;
    bool moveH;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        if(direction.x == 0 && direction.y != 0){
            moveV = true;
            moveH = false;
        }
        else if(direction.y == 0 && direction.x != 0){
            moveH = true;
            moveV = false;
        }
        else{
            moveH = false;
            moveV = false;
        }

        if(moveV){
            int rotateY = direction.y > 0 ? 0 : 180;

            transform.localEulerAngles = new Vector3(0, 0, rotateY);
        }
        else if(moveH){
            int rotateX = direction.x > 0 ? -90 : 90;

            transform.localEulerAngles = new Vector3(0, 0, rotateX);
        }
        else{
                int signX = direction.x < 0 ? 1 : -1;
                float angle = signX * Vector3.Angle(new Vector3(0, 1, 0), direction);
        

                if(angle != 0) transform.localEulerAngles = new Vector3(0, 0, angle);
        }


    }
}
