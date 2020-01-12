using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour
{

    public bool isTouching { get; private set; }
    public bool isTouchingUI { get; private set; }
    public Vector3 touchPosition { get; private set; }

    private static TouchController instance;

    public static TouchController Instance
    {
        get
        {
            if (!instance)
            {
                instance = GameObject.FindObjectOfType(typeof(TouchController)) as TouchController;
                if (!instance)
                    Debug.LogError("No active TouchController script on camera.");
            }
            return instance;
        }
    }

    void Awake()
    {
    }

    void Update()
    {

        if (Input.touchCount > 0)
        {
            //set booleans
            isTouching = true;

            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[0].position);

            if (touch.phase == TouchPhase.Began)
            {
                checkIfTouchingUI(touch);
            }

            if (touch.phase == TouchPhase.Moved)
            {
                checkIfTouchingUI(touch);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("EndedTouch!");
                isTouching = false;
            }
        }
    }


    void checkIfTouchingUI(Touch touch)
    {
        if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            isTouchingUI = true;
        else
            isTouchingUI = false;
    }
}

