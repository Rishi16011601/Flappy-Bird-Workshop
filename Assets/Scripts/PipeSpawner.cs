using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float maxTime = 1;       //Spwan Pipe after
    private float timer = 0;        
    public GameObject pipe;         //Pipe Gameobject
    public float height = 1;        //Variation in the pipe spwaned

    // Update is called once per frame
    void Update()
    {
        if(timer > maxTime)        //If (RealTime > Time to Spwan Pipe)
        {
            GameObject newPipe = Instantiate(pipe);  //Instantiate means initialising the gameobject in the game
            newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newPipe, 15);
            timer = 0;
        }

        timer += Time.deltaTime;     //Realtime Tracking
    }
}
