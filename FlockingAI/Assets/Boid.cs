using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boid : MonoBehaviour {

    Vector2 heading;
    Rigidbody2D boid;
    List<Transform> closeBoids = new List<Transform>();

	void Start () {
        //Set a random start direction
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);

        heading = new Vector2(x, y).normalized;

        boid = gameObject.GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        //Find other boids
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, BoidMaster.inst.checkRadius, heading, 0.01f);
        closeBoids.Clear();

        //Change heading based on boids found
        for (int i = 0; i < hits.Length; i++) 
        {
            if (hits[i].transform.tag == "Boid" && hits[i].transform != transform) 
            {
                //Put it on the list
                closeBoids.Add(hits[i].transform);

                //Separation
                Vector2 posDif = hits[i].transform.position - transform.position;
                if (posDif.magnitude < BoidMaster.inst.separationDistance) 
                {
                    //This will need to be changed as it doesn't account for the boid's current direction
                    //Or for the clockwise/counter-clockwise perpendicular.
                    //print(transform.name + " Angle: " + Vector2.Angle(posDif, heading));

                    //Determine if the angle is positive or negative.
                    Vector3 crossVec = Vector3.Cross(posDif, heading);
                    Vector2 modVec = Vector2.zero;
                    if (crossVec.z > 0)
                    {
                        modVec = new Vector2(-posDif.y, posDif.x);
                    }
                    else
                    {
                        modVec = new Vector2(posDif.y, -posDif.x);
                    }
                     
                    modVec.Normalize();
                    modVec *= (1 / posDif.magnitude) * BoidMaster.inst.separationForce;
                    heading += modVec;
                }
            }
        }

        //Calculat Cohesion and Alignment
        Vector2 avgPos = Vector2.zero;
        Vector2 avgDir = Vector2.zero;

        for (int k = 0; k < closeBoids.Count; k++) 
        {
            avgPos += new Vector2(closeBoids[k].position.x, closeBoids[k].position.y);
            avgDir += closeBoids[k].GetComponent<Boid>().heading;
        }

        avgPos /= closeBoids.Count;

        heading += avgDir.normalized * BoidMaster.inst.alignmentForce;
        heading += avgPos.normalized * BoidMaster.inst.cohesionForce;

        //Apply the force
        heading.Normalize();
        boid.AddForce(heading, ForceMode2D.Force);

        if(boid.velocity.magnitude > BoidMaster.inst.maxVelocity)
        {
            boid.velocity = heading * BoidMaster.inst.maxVelocity;
        }

        //Looping
        if (transform.position.x > BoidMaster.inst.mapX)
        {
            transform.position = new Vector3(-BoidMaster.inst.mapX + 0.1f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -BoidMaster.inst.mapX)
        {
            transform.position = new Vector3(BoidMaster.inst.mapX - 0.1f, transform.position.y, transform.position.z);
        }

        if (transform.position.y > BoidMaster.inst.mapY)
        {
            transform.position = new Vector3(transform.position.x, -BoidMaster.inst.mapY + 0.1f, transform.position.z);
        }
        else if (transform.position.y < -BoidMaster.inst.mapY)
        {
            transform.position = new Vector3(transform.position.x, BoidMaster.inst.mapY - 0.1f, transform.position.z);
        }
    }
}
