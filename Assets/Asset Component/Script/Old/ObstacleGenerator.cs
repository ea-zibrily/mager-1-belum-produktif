using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject obstacle4;

    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;
    public float multiSpeed;

    public int chooseObs;

    // Start is called before the first frame update
    void Awake()
    {
        currentSpeed = minSpeed;
        generateObstacle();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void generateObstacle()
    {
        chooseObs = Random.Range(1, 8);

        if (chooseObs == 1)
        {
            GameObject newObs = Instantiate(obstacle1);
        }
        if (chooseObs == 2)
        {
            GameObject newObs = Instantiate(obstacle2);
        }
        if (chooseObs == 3)
        {
            GameObject newObs = Instantiate(obstacle3);
        }
        if (chooseObs == 4)
        {
            GameObject newObs = Instantiate(obstacle4);
        }
    }
}
