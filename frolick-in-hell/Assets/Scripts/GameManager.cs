using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject flowerPrefab;
    private GameObject instFlower;

    public float[] spawnBoundX = { 0,0};
    public float[] spawnBoundY = { 0,0};

    private float flowerX = 0;
    private float flowerY = 0;

    private float midX = 0;

    void spawnFlower()
    {
        instFlower = Instantiate(flowerPrefab);

        flowerX = Random.Range(spawnBoundX[0], spawnBoundY[1]);

        

        if (flowerX > midX) {
            flowerY = Random.Range(spawnBoundY[0] + ((flowerX - midX) / 2), spawnBoundY[1] - ((flowerX - midX) / 2));
        } else
        {
            flowerY = Random.Range(-((flowerX-spawnBoundX[0]) / 2), ((flowerX - spawnBoundX[0]) / 2));
        }


        instFlower.transform.position = new Vector3(flowerX, flowerY);
    }


    // Start is called before the first frame update
    void Start()
    {
        midX = (spawnBoundX[0] + spawnBoundX[1]) / 2;
        spawnFlower();
        spawnFlower();
        spawnFlower();
        spawnFlower();
        spawnFlower();
        spawnFlower();
        spawnFlower();
        spawnFlower();
        spawnFlower();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
