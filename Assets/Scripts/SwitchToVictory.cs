using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.SceneManagement;


public class SwitchToVictory : MonoBehaviour

{
    int count;

    void Start()
    {
        count = 0;
    }


    private void OnTriggerEnter(Collider other)

    {

        if (other.tag == "PickUp")

        {
            count++;
            // Print out the current scene's name

            Debug.Log(SceneManager.GetActiveScene().name);

            // Change scene
            if (count >= 5){
                SceneManager.LoadScene(2);
            }

        }
    }

}