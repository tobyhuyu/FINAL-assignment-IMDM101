using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;
    public float jumpForce;
    Animator anim;
    [SerializeField] private AudioClip collect;
    [SerializeField] private AudioClip hurt;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object the player collided with has the "PickUp" tag.
       /* if (other.tag == "levelExit")
        {
            //insert next scene
            SceneManager.LoadScene("ForestEnemyScene");
        } */
        if (other.gameObject.CompareTag("PickUp"))
        {

            // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);

            audioSource.clip = collect;
            audioSource.Play();
        }

        if (other.gameObject.CompareTag("enemy"))
        {
            audioSource.clip = hurt;
            audioSource.Play();
        }
    }

            // Update is called once per frame
    void Update()
    {
        //rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        //float moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        //float moveVertical = CrossPlatformInputManager.GetAxis("Vertical");


        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.rotation = Quaternion.LookRotation(movement);


        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);



        anim.SetTrigger("bounce");

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            //transform.rotation = Quaternion.LookRotation(rb.velocity);



        }
    }
}
