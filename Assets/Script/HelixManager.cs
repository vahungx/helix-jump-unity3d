using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject[] rings;

    public float ringDistance = 5f;
    public int noOfRings;
    float yPos;

    // Start is called before the first frame update
    private void Start()
    {
        noOfRings = GameManager.CurrentLevelIndex + 5;
        for (int i = 0; i< noOfRings; i++)
        {
            if (i == 0)
            {
                //Spawn the rings first
                SpawnRings(0);
            }
            else
            {
                //spawn mid rings except the 0, the last
                SpawnRings(Random.Range(1, rings.Length - 1));
            }
        }
        //Last rings spawn
        SpawnRings(rings.Length - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRings(int index)
    {
        GameObject newRing = Instantiate(rings[index], new Vector3 (transform.position.x, yPos, transform.position.z), Quaternion.identity);
        yPos -= ringDistance;
        newRing.transform.parent = transform;
    }
}
