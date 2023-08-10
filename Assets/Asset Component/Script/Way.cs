using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Way : MonoBehaviour
{
    public float speedWay;
    public float go;
    public float to;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.left * speedWay * Time.deltaTime);
        transform.position = new Vector2(transform.position.x - speedWay * Time.deltaTime, transform.position.y);

        if (transform.position.x <= to)
        {
            if (gameObject.tag == "obstacle")
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = new Vector2(go, transform.position.y);
            }
        }
        
    }
}
