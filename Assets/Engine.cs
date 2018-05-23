using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour {

    // Update is called once per frame
    Rigidbody RB;

    public float EnginePower = 200f;
    public float TurnPower = 3000f;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Debug.Log(transform.up * SteeringWheel.Instance.SteeringWheelOffsetPercentage * 3000);
        RB.AddTorque(transform.up * SteeringWheel.Instance.SteeringWheelOffsetPercentage * TurnPower);
      
        RB.AddForce(transform.forward * EnginePower);

        //rb.AddForce(Tires.Instance.transformWheel1.up * Power);

        // var direction = transform.TransformDirection(Vector3.up);
        //        rb.AddForceAtPosition(direction * 5000f, ForcePosition);
        // rb.AddForceAtPosition(direction * 5000f, new Vector2(1000, 1000));
        // rb.fo
        // test1 = transform.TransformDirection(transform.right) * 5000;
        // test2 = transform.TransformDirection(ForcePosition);
        // rb.AddForceAtPosition(transform.TransformDirection(transform.right) * 5000, transform.TransformDirection(ForcePosition));

        // Push car with physics (forward and rotate)
        // test = Tires.Instance.transformWheel1.rotation * Tires.Instance.transformWheel1.up;
        //test = transform.up * Tires.Instance.transformWheel1.up;

        //Rigidbody2D.AddForceAtPosition(

        //  test * Power,
        //Helpers.DegreeToVector2(Tires.Instance.Rotation + 90),
        //ForcePosition);

        //test1 = Vector3.right;
        //test2 = Tires.Instance.transformWheel1.rotation.eulerAngles.normalized;
        //test3 = Helpers.DegreeToVector2(Tires.Instance.transformWheel1.eulerAngles.z + 90);

        //Rigidbody2D.AddForceAtPosition(test3, ForcePosition);        
        //Rigidbody2D.AddForceAtPosition(Tires.Instance.transformWheel1.rotation * transform.up, ForcePosition);

        //var rotation = Mathf.Lerp(-90, 90, (SteeringWheelOffsetPercentage + 1) / 2);
        //transform.rotation = Quaternion.AngleAxis(-rotation, Vector3.forward);
    }
}
