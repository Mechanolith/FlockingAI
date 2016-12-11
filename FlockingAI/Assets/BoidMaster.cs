using UnityEngine;
using System.Collections;

public class BoidMaster : MonoBehaviour {
    public static BoidMaster inst;

    [Header ("Boid Setup")]
    public int boidCount;
    public GameObject boid;
    [Range(0f, 20f)]
    public float maxX;
    [Range(0f, 20f)]
    public float maxY;

    [Header("Flocking Values")]
    [Range(0f, 200f)]
    public float cohesionForce;
    [Range(0f, 20f)]
    public float separationDistance;
    [Range(0f, 200f)]
    public float separationForce;
    [Range(0f, 200f)]
    public float alignmentForce;
    [Range(0.01f, 20f)]
    public float checkRadius;
    [Range(0.01f, 200f)]
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

            Instantiate(boid, startPos, Quaternion.identity);
        }
	}
	
	void Update () {
	
	}
}
