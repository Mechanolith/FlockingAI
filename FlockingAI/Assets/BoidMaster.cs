using UnityEngine;
using System.Collections;

public class BoidMaster : MonoBehaviour {
    public static BoidMaster inst;

    [Header ("Boid Setup")]
    public int boidCount;
    public GameObject boid;
    public float maxX;
    public float maxY;
    public float mapX;
    public float mapY;

    [Header("Flocking Values")]
    public float cohesionForce;
    public float separationDistance;
    public float separationForce;
    public float alignmentForce;
    public float checkRadius;
    public float maxVelocity;

    void Awake() {
        inst = this;
    }

	void Start () {
        for (int i = 0; i < boidCount; i++) 
        {
            float x = Random.Range(-maxX, maxX);
            float y = Random.Range(-maxY, maxY);
            Vector3 startPos = new Vector3(x, y, 0);

            GameObject newBoid = Instantiate(boid, startPos, Quaternion.identity) as GameObject;
            newBoid.name = "Boid " + i;
        }
	}
	
	void Update () {
	
	}
}
