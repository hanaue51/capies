using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickBall : MonoBehaviour
{
    private CharacterJoint myJoint;
    public float force;
    public float torque;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            if (myJoint == null)
            {
                myJoint = gameObject.AddComponent<CharacterJoint>() as CharacterJoint;
                myJoint.connectedBody = collision.rigidbody;

                myJoint.breakForce = force;
                myJoint.breakTorque = force;
                
            }
        }
    }
}
