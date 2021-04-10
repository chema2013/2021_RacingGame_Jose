using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer5 : MonoBehaviour
{
    public Camera cam;

    float playerHeight; //from the origin of the game object to the ground = height
    public float speed;
    Vector3 currentVelocity; //necessary for unity

    void Start()
    {
        playerHeight = transform.position.y; //getting height; game object must be resting on ground, ground at y level 0
    }

    void Update()
    {
        Movement();

    }

    void Movement()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition); //creating a ray, ray cast onto screen from position of mouse
        RaycastHit hit; //info on object hit by ray

        if (Physics.Raycast(ray, out hit)) //checking if ray hit anything, returning info
        {
            Vector3 destination = new Vector3(hit.point.x, playerHeight + hit.point.y, hit.point.z); //storing position of raycast + compensating with player height
            
            transform.LookAt(destination); //making player look at raycast destination
            //transform.position = Vector3.SmoothDamp(transform.position, destination, ref currentVelocity, .1f, speed); //player moving to destination
        }

    }
}
