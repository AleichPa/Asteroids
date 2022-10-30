using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PowerupManager : MonoBehaviour
{
    public GameObject[] SpawnObjects;
    public float limitX = 10;
    public float limitY = 6;
    public int powerups_min = 1;
    public int powerups_max = 1;
    public int powerUP;

    // Start is called before the first frame update
    void Start()
    {

        Instantiate(SpawnObjects[Random.Range(0, SpawnObjects.Length)], this.transform);

    }
    // Update is called once per frame
    void Update()
    {

    }


    void SpawnRandom()
    {
        int powerUP = Random.Range(powerups_min, powerups_max);

        for (int i = 0; i < powerUP; i++)
        {
            Vector3 posicion = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitY, limitY));

            while (Vector3.Distance(posicion, new Vector3(0, 0)) < 5)
            {
                posicion = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitY, limitY));
            }
        }
    }
}
