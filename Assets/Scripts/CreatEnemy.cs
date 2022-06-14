using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatEnemy : MonoBehaviour
{
    public GameObject enemy;
    float xPosition;
    int num;
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        while(num<5)
        {
            xPosition = Random.Range(-25, 65);
            Instantiate(enemy, new Vector3(xPosition, 4, 0), enemy.transform.rotation);
            num++;
        }
        /*for (int i = 0; i < 4; i++)
        {
            xPosition = Random.Range(-25, 65);
            Instantiate(enemy, new Vector3(xPosition, 2, 0), enemy.transform.rotation);
        }*/
        Instantiate(enemy, new Vector3(-48, -1, 0), enemy.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
