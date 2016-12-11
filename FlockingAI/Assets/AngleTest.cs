using UnityEngine;
using System.Collections;

public class AngleTest : MonoBehaviour {
    public GameObject target;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        CheckAngle();
    }

    void CheckAngle()
    {
        Vector2 posDif = target.transform.position - transform.position;
        float angle = Vector2.Angle(posDif, Vector2.up);

        //Determine if the angle is positive or negative.
        int angleDirection = 1;
        Vector3 crossVec = Vector3.Cross(posDif, Vector2.up);
        if (crossVec.z > 0)
        {
            angleDirection = -1;
        }

        print(transform.name + " Angle: " + (angle * angleDirection));
    }
}
