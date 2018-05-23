using UnityEngine;

public class SteeringWheel : MonoBehaviour {

    public static SteeringWheel Instance;

    float HandsOffSnappingSpeed = 1.0f;
    float HandsOnSnappingSpeed = 0.5f;
    float SteerInputTouchAreaWidth = 1.5f; // less is more

    public float SteeringWheelOffsetPercentage;

    float halfScreenWidth, touchPositionX;
    float startTimeHandsOffWheel, startTimeHandsOnWheel;
    bool isHandsOffWheel;

    private void Awake()
    {
        Instance = this;
    }

    void Start ()
    {
        halfScreenWidth = Screen.width / 2f;
        isHandsOffWheel = true;
    }

    private void Update()
    {
        GetInput();

        if (!isHandsOffWheel)
            SnapWheelToInput();
        else
            RecenterWheel();

        DoGraphics();
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (isHandsOffWheel) startTimeHandsOnWheel = Time.time;
            isHandsOffWheel = false;
            touchPositionX = Input.mousePosition.x;            
        }
        else
        {
            if (!isHandsOffWheel) startTimeHandsOffWheel = Time.time;
            isHandsOffWheel = true;            
        }
    }

    private void SnapWheelToInput()
    {
        float t = (Time.time - startTimeHandsOnWheel) / HandsOnSnappingSpeed;
        float targetWheelOffsetPercentage = Mathf.Clamp((touchPositionX - halfScreenWidth) / halfScreenWidth * SteerInputTouchAreaWidth, -1f, 1f);        
        SteeringWheelOffsetPercentage = Mathf.SmoothStep(SteeringWheelOffsetPercentage, targetWheelOffsetPercentage, t);
    }

    private void RecenterWheel()
    {
        float t = (Time.time - startTimeHandsOffWheel) / HandsOffSnappingSpeed;
        SteeringWheelOffsetPercentage = Mathf.SmoothStep(SteeringWheelOffsetPercentage, 0, t);
    }

    private void DoGraphics()
    {
        var rotation = Mathf.Lerp(90, -90, (SteeringWheelOffsetPercentage + 1) / 2);
        transform.localRotation = Quaternion.AngleAxis(rotation, Vector3.forward);
    }
}
