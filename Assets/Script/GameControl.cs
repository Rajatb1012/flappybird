using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour 
{
    public static GameControl instance;                        //A reference to the UI text component that displays the player's score.
    public GameObject gameOvertext;                //A reference to the object that displays the text which appears when the player dies.
    public Text scoreText;
                            //The player's score.
    public bool gameOver = false;                //Is the game over?
   public float scrollSpeed = -1.5f;
   private int score = 0;

    void Awake()
    {
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if(instance != this)
            //...destroy this one because it is a duplicate.
            Destroy (gameObject);
    }

    void Update()
    {
        //If the game is over and the player has pressed some input...
        if (gameOver == true && Input.GetMouseButtonDown(0)) 
        {
            //...reload the current scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void BirdScored()
{
     if(gameOver)
     {
       return;
      }
score++;
scoreText.text = "Score: " + score.ToString ();
}

    public void BirdDied()
    {
        //Activate the game over text.
        gameOvertext.SetActive (true);
        //Set the game to be over.
        gameOver = true;
    }
}