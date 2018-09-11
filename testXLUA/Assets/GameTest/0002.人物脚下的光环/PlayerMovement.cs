using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {



    public float turnSmoothing = 15f; // A smoothing value for turning the player.
    public float speedDampTime = 0.1f;// The damping for the speed parameter


    private Animator anim;                          // Reference to the animator component.
    //private DoneHashIDs hash;              // Reference to the HashIDs.
    private Rigidbody rigidBody;

    public GameObject playerObj;

    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        rigidBody = this.GetComponent<Rigidbody>();
        //hash = GameObject.FindGameObjectWithTag(DoneTags.gameController).GetComponent<DoneHashIDs>();

        // Set the weight of the shouting layer to 1.
        //            anim.SetLayerWeight(1, 1f);

        
    }


    void FixedUpdate()
    {
        // Cache the inputs.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        MovementManagement(h, v);


        //playerObj.GetComponent<Rigidbody>().velocity = Vector3.zero;

    }


    void Update()
    {

    }


    void MovementManagement(float horizontal, float vertical)
    {
        // Set the sneaking parameter to the sneak input.
        //anim.SetBool(hash.sneakingBool, sneaking);

        rigidBody.velocity = new Vector3(horizontal, 0, vertical);

        // If there is some axis input...
        if (horizontal != 0f || vertical != 0f)
        {
            // ... set the players rotation and set the speed parameter to 5.5f.
            Rotating(horizontal, vertical);
        }
    }


    void Rotating(float horizontal, float vertical)
    {
        // Create a new vector of the horizontal and vertical inputs.
        Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);

        // Create a rotation based on this new vector assuming that up is the global y axis.
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

        // Create a rotation that is an increment closer to the target rotation from the player's rotation.
        Quaternion newRotation = Quaternion.Lerp(playerObj.transform.rotation, targetRotation, turnSmoothing * Time.deltaTime);

        // Change the players rotation to this new rotation.
        //playerObj.GetComponent<Rigidbody>().MoveRotation(newRotation);
        //playerObj.transform.rotation = newRotation;

        //Quaternion rotation = playerObj.transform.rotation;
        //rotation.w += newRotation.w;
        //rotation.x += newRotation.x;
        //rotation.y += newRotation.y;
        //rotation.z += newRotation.z;

        playerObj.transform.rotation = newRotation;
    }
}
