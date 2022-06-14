using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool isFloor;
    float speed;
    public static bool dirRight;

    Vector3 playerScale;
    Rigidbody2D rigid;

    public GameObject arrow;
    public Transform bowTRN;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        playerScale = transform.lossyScale;
        isFloor = true;
        rigid = GetComponent<Rigidbody2D>();
        dirRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dirRight = true;
            transform.Translate(speed * Time.deltaTime, 0, 0);
            if (playerScale.x > 0)
            {
                transform.localScale = new Vector3(-playerScale.x, playerScale.y, playerScale.z);
                playerScale.x = -playerScale.x;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            dirRight = false;
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            if (playerScale.x < 0)
            {
                transform.localScale = new Vector3(-playerScale.x, playerScale.y, playerScale.z);
                playerScale.x = -playerScale.x;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && isFloor)
        {
            rigid.AddForce(new Vector2(0, 350));
            isFloor = false;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (dirRight)
            {
                Instantiate(arrow, new Vector3(bowTRN.position.x + 0.3f, bowTRN.position.y + 0.3f, bowTRN.position.z), arrow.transform.rotation);
                
            }else
            {
                Instantiate(arrow, new Vector3(bowTRN.position.x - 0.3f, bowTRN.position.y + 0.3f, bowTRN.position.z), arrow.transform.rotation);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isFloor = true;
        }
    }
}