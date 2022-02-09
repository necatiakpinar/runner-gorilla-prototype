using UnityEngine;
public class CPlayerInput : MonoBehaviour
{
    private Vector2 Touch_StartLocation;
    private Vector2 Touch_CurrentLocation;
    private Vector2 Touch_EndLocation;
    private bool IsTouchStopped = false;

    // private Vector2 Mouse_StartLocation;
    // private Vector2 Mouse_CurrentLocation;
    // private Vector2 Mouse_EndLocation;
    // private bool IsMouseDragging = false;

    public float SwipeRange = 50;
    public float TapRange = 10;

    private CController_Player Controller;

    private void Awake()
    {
        Controller = GetComponent<CController_Player>();
    }
    private void Update()
    {
        TouchSwipe();
    }
    // public void MouseSwipe()
    // {
    //     if(Input.GetMouseButtonDown(0)) IsMouseDragging = true;
    //     {
    //         Mouse_CurrentLocation = Input.mousePosition;
    //     }
    //     if(Input.GetMouseButtonUp(0))
    //     {
    //         Mouse_CurrentLocation = Vector2.zero;
    //     }
    // }
    public void TouchSwipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch_StartLocation = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Touch_CurrentLocation = Input.GetTouch(0).position;
            Vector2 Distance = Touch_CurrentLocation - Touch_StartLocation;

            if (!IsTouchStopped)
            {

                if (Distance.x < -SwipeRange)
                {
                    Debug.Log("Left");
                    IsTouchStopped = true;
                    Controller.ToLeft();

                }
                else if (Distance.x > SwipeRange)
                {
                    Debug.Log("Right");
                    IsTouchStopped = true;
                    Controller.ToRight();
                }
            }

        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            IsTouchStopped = false;

            Touch_EndLocation = Input.GetTouch(0).position;

            Vector2 Distance = Touch_EndLocation - Touch_StartLocation;

            if (Mathf.Abs(Distance.x) < TapRange && Mathf.Abs(Distance.y) < TapRange)
            {
                Debug.Log("Tap");
            }

        }


    }
}