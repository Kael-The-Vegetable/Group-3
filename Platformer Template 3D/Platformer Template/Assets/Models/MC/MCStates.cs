using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class MCStates : MonoBehaviour
{
    Animator mcanimate;
    private float GroundSpeed = 1;
    private float AirSpeed = 1;

    // Start is called before the first frame update
    void Start()
    { 
        // Will set the parameters to a default when the simulation starts
        mcanimate = GetComponent<Animator>();
        mcanimate.SetBool("Fall", false);
        mcanimate.SetBool("Jump", false);
        mcanimate.SetBool("Running", false);
        mcanimate.SetFloat("GroundSpeed", GroundSpeed);
        mcanimate.SetFloat("AirSpeed", AirSpeed);
    }

    // Update is called once per frame
    void Update()
    {

        // Check if the character is "in the air" and tell him to "Start falling" if so.

        if (!Physics.Raycast(transform.position, -transform.up, 1))
        {
            mcanimate.SetBool("Fall", true);
        }
        else
        {
            mcanimate.SetBool("Fall", false);
        }

        // Check if the Jump key is pressed, then tell the character to "Jump" if so.
        // Mid-Air Jump animations are repeatable even if character cant jump
        // Optionally have the jump play faster/slower if the character has modified air speed

        if (Input.GetKey(KeyCode.Space))
        {
            mcanimate.SetBool("Jump", true);
        }
        else
        {
            mcanimate.SetBool("Jump", false);
        }

        // Check if the character is moving at all and tell the character to "Run" if so.
        // Optionally have the run play faster/slower if the character has modified move speed

        if (Input.GetKey(KeyCode.W))
            mcanimate.SetBool("Running", true);
        else if (Input.GetKey(KeyCode.A))
            mcanimate.SetBool("Running", true);
        else if (Input.GetKey(KeyCode.S))
            mcanimate.SetBool("Running", true);
        else if (Input.GetKey(KeyCode.D))
            mcanimate.SetBool("Running", true);
        else
            mcanimate.SetBool("Running", false);

        // these control how fast certain animations of the character play.
        // currently they cannot change from "1"

        mcanimate.SetFloat("GroundSpeed", GroundSpeed);
        mcanimate.SetFloat("AirSpeed", AirSpeed);
    }
}
