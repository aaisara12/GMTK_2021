using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    [Header ("Enemies")]
    public GameObject square;
    public GameObject circle;
    public GameObject triangle;

    [Header ("Spawning Details")]
    public bool paused;
    public float rate;
    private float spawnTimer;
    
    public float maxHeight;
    public float minHeight;


    // Start is called before the first frame update
    void Start()
    {

        Random.InitState(7019542);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
            spawnWave();
    }

    void spawnWave(){
        //pick 1-4 locations 
        int numEnemies = Random.Range(0,5)+1;
        Debug.Log(numEnemies);
        float stagger = Mathf.Abs(maxHeight-minHeight)/numEnemies;

        for (int x=1;x<=numEnemies;x++){
            Vector3 spawnPosition = new Vector3(transform.position.x,transform.position.y+maxHeight-stagger*x,transform.position.z);
            Instantiate(randomEnemy(),spawnPosition,Quaternion.identity,this.gameObject.transform);
        }
    }

    GameObject randomEnemy(){
        int number = Random.Range(0,3);
        switch(number){
            case 0:
                return triangle;
            case 1:
                return square;
            case 2:
                return circle;
        }
        return null;
    }
}
