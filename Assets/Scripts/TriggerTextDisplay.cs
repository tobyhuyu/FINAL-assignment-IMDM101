using UnityEngine;
using TMPro;

public class TriggerTextDisplay : MonoBehaviour
{
    public TextMeshProUGUI textToShow; // Drag and drop the TextMeshPro element in the Inspector
    [SerializeField] private AudioClip victory;
    private AudioSource audioSource;

    void Start()
    {
        if (textToShow != null)
        {
            audioSource = GetComponent<AudioSource>();
            textToShow.gameObject.SetActive(false); // Ensure the text is hidden at the start
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the "Player" tag
        {
            if (textToShow != null)
            {
                textToShow.gameObject.SetActive(true); // Show the text
                audioSource.clip = victory;
                audioSource.Play();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Hide the text when the player leaves the trigger
        {
            if (textToShow != null)
            {
                textToShow.gameObject.SetActive(false); // Hide the text
            }
        }
    }
}
