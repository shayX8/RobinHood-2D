using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehavior : MonoBehaviour
{
    int life, rangeWake;
    public GameObject fire;
    public static bool dirRight;
    Vector3 enemyScale;
    float speed = 5;


    // Start is called before the first frame update
    void Start()
    {
        life = 2;
        StartCoroutine (ShootFire());
        enemyScale = transform.lossyScale;
        if (enemyScale.x > 0)
            dirRight = true;
        else
            dirRight = false;
        StartCoroutine(ChangDirection());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Arrow")
        {
            life--;
        }
        else if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(0);
        }
        if (life <= 0)
            Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            collision.attachedRigidbody.AddForce(new Vector2(0, 400));
        }
    }
    IEnumerator ShootFire()
    {
        yield return new WaitForSeconds(1.4f);

        if (enemyScale.x > 0)
            Instantiate(fire, new Vector3(transform.position.x + 0.8f, transform.position.y - 0.5f, transform.position.z), fire.transform.rotation);
        else
            Instantiate(fire, new Vector3(transform.position.x - 0.8f, transform.position.y - 0.5f, transform.position.z), fire.transform.rotation);

        StartCoroutine(ShootFire());
    }
    IEnumerator ChangDirection()
    {
        yield return new WaitForSeconds(3f);

        speed = -speed;
        enemyScale.x = -enemyScale.x;
        transform.localScale = enemyScale;
        if (dirRight)
            dirRight = false;
        else
            dirRight = true;

        StartCoroutine(ChangDirection());
    }
    
}
