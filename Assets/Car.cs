using UnityEngine;

public class Car : MonoBehaviour {

    public static Car Instance;

    public Rigidbody RB;

    private void Awake()
    {
        Instance = this;
    }

    void Start () {     

    }

    public Vector2 GetVelocity()
    {
        return RB.velocity;
    }

    public Vector3 GetPosition()
    {
        return RB.position;
    }
}
