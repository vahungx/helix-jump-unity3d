using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    public float bounceForce = 666f;

    public GameObject splitPrefab;

    AudioManager audioManager;

    // Start is called before the first frame update
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();   
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = new Vector3(rb.velocity.x,bounceForce * Time.deltaTime, rb.velocity.z);
        audioManager.Play("Land");

        GameObject newSplit = Instantiate(splitPrefab, new Vector3(transform.position.x, collision.transform.position.y + 0.28f , transform.position.z), transform.rotation);
        newSplit.transform.localScale = Vector3.one * Random.Range(0.8f,1.2f);
        newSplit.transform.parent = collision.transform;

        string materialName = collision.transform.GetComponent<MeshRenderer> ().material.name;
        Debug.Log(materialName);

        if (materialName == "Safe (Instance)")
        {
            Debug.Log("you are safe");
        }

        if (materialName == "UnSafe (Instance)")
        {
            GameManager.gameOver = true;
            audioManager.Play("GameOver");
        }

        if (materialName == "LastRing (Instance)" && !GameManager.levelWin)
        {
            GameManager.levelWin = true;
            audioManager.Play("LevelWin");
        }
    }
}
