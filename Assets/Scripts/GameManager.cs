using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;           //Displays message when game gets over
    public GameObject scoreCanvas;              //Displays the score
    //public GameObject gameStartCanvas;        //Displays Start Screen

    public Text txt;                            //Score Text
    public AudioSource s1;                      //Game Music
    public AudioSource s2;                      //Game Over Sound
    public int chk = 0;                         //To check if bird is in motion or not
    private GameObject pipS;                    //Reference to the pipe spawner
    private GameObject bird;                    //Reference to the bird 


    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 0;                   //Time is stopped  
        bird = GameObject.Find("Bird");       //Linking Bird to the reference
        pipS = GameObject.Find("PipeSpawner");//Linking PipeSpawner to the reference
    }

    // Update is called once per frame
    private void Update()
    {
        StartGame();                          //Start Game Method call
    }

    private void StartGame()                  // Starts the game on first input
    {
        if ((Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) && chk == 0)
        {
            Time.timeScale = 1;
            chk = 1;
            scoreCanvas.SetActive(true);        //Setting Score Canvas to true
            //gameStartCanvas.SetActive(false);
        }
    }

    public void GameOver()                  //When game overs
    {
        s1.enabled = false;                 //Setting Music to false
        s2.enabled = true;                  //Setting GameOver Sound to true

        gameOverCanvas.SetActive(true);     //Setting GameOver Canvas to true
        Time.timeScale = 0;
        txt.transform.position = txt.transform.position; //- new Vector3(0, 350, 0);

    }

    public void Replay()                    // To reset the game settings
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("pipe");
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
        Time.timeScale = 1;

        Score.score = 0;

        gameOverCanvas.SetActive(false);  //Setting GameOver Canvas to false
        s1.enabled = true;                 //Game Music to true
        s2.enabled = false;                 //GameOver Sound to false
        pipS.SetActive(false);              //PipeSpawner to false
        bird.transform.position = new Vector3(-0.184f, 0.08153994f, 0);  //Moving bird to original position

        pipS.SetActive(true);       //PipeSpawner to true
    }
}
