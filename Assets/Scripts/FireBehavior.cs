using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireBehavior : MonoBehaviour
{
    float speed;

    bool  fireDirRight;
    Vector3 fireScale, enemyScale;
    // Start is called before the first frame update
    void Start()
    {
        speed = 8;
        enemyScale = transform.lossyScale;
        if (enemyScale.x > 0)
            fireDirRight = true;
        else
            fireDirRight = false;
        fireScale = transform.lossyScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyBehavior.dirRight)
        {
            if (!fireDirRight)
            {
                fireScale.x = -fireScale.x;
                transform.localScale = fireScale;
            }
            transform.Translate(speed * Time.deltaTime, 0, 0);
            fireDirRight = true;
        }
        else
        {
            if (fireDirRight)
            {
                fireScale.x = -fireScale.x;
                transform.localScale = fireScale;
            }
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            fireDirRight = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            SceneManager.LoadScene(0);
        }
    }
}
