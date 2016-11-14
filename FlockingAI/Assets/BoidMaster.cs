using UnityEngine;
using System.Collections;

public class BoidMaster : MonoBehaviour {
    public static BoidMaster inst;

    [Header ("Boid Setup")]
    public int boidCount;
    public GameObject boid;
    public float maxX;
    public float maxY;

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
            float x = Random.RandomRange(-maxX, maxX);
            float y = Random.RandomRange(-maxY, maxY);
            Vector3 startPos = new Vector3(x, y, 0);

            Instantiate(boid, startPos, Quaternion.identity);
        }
	}
	
	void Update () {
	
	}
}
