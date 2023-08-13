using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float maxtime;
    private float timer;

    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject obstacle4;

    private int chooseObstacle;

    void Start()
    {
        maxtime = 1f;
    }

    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= maxtime)
        {
            timer = 0;
            GenerateObs();
        }
    }

    void GenerateObs()
    {
        chooseObstacle = Random.Range(1, 4);

        if (chooseObstacle == 1)
        {
            GameObject newObs = Instantiate(obstacle1);
        }
        if (chooseObstacle == 2)
        {
            GameObject newObs = Instantiate(obstacle2);
        }
        if (chooseObstacle == 3)
        {
            GameObject newObs = Instantiate(obstacle3);
        }
        if (chooseObstacle == 4)
        {
            GameObject newObs = Instantiate(obstacle4);
        }
    }


}
