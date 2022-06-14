using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    float speed, fall;
    bool playerDirRight, arrowDirRight;
    Vector3 arrowScale;

    // Start is called before the first frame update
    void Start()
    {
        speed = 18;
        fall = 0.005f;
        playerDirRight = PlayerMovement.dirRight;
        arrowScale = transform.lossyScale;
        arrowDirRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDirRight)
        {
            if(!arrowDirRight)
            {
                arrowScale.x = -arrowScale.x;
                transform.localScale = arrowScale;
            }
            transform.Translate(speed * Time.deltaTime, -fall * Time.deltaTime, 0);
            arrowDirRight = true;
        }
        else
        {
            if (arrowDirRight)
            {
                arrowScale.x = -arrowScale.x;
                transform.localScale = arrowScale;
            }
            transform.Translate(-speed * Time.deltaTime, -fall * Time.deltaTime, 0);
            arrowDirRight = false;
        }

        fall = fall + 0.005f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
