using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.SceneManagement;


public class CollideTrigger : MonoBehaviour

{
    int count;
    public GameObject youDied;
    public GameObject black;

    void Start()
    {
        count = 0;
        youDied.SetActive(false);
        black.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)

    {

        if (other.tag == "LevelExit")

        {

            // Print out the current scene's name

            Debug.Log(SceneManager.GetActiveScene().name);

            // Change scene

            SceneManager.LoadScene(1);

        }

        if (other.tag == "enemy")

        {
            count++;
            if (count>=3){
                youDied.SetActive(true);
                black.SetActive(true);
            }

        }
    }

}