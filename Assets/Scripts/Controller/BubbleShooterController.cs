using UnityEngine;
using System.Collections;

public class BubbleShooterController : MonoBehaviour
{

    public bool isAiming;
    public bool isTouching;

    private float rotationSpeed = 250.0f;
    private float maxLeftAngle = 85.0f;
    private float maxRightAngle = 275.0f;

    private Ray mouseRay;
    private RaycastHit hit;

    private LineRenderer lineRenderer;

    void Start()
    {
        isAiming = true;
        isTouching = false;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = true;
    }

    void Update()
    {



        if (isAiming)
        {
            if (Input.touchCount > 0)
            {
                isTouching = true;
                Touch touch = Input.GetTouch(0);
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                Vector2 lookDir = touchPos - transform.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = rotation;
                if (transform.eulerAngles.z > this.maxLeftAngle && transform.eulerAngles.z < 180.0)
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, maxLeftAngle);
                }
                if (transform.eulerAngles.z < this.maxRightAngle && transform.eulerAngles.z > 180.0)
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, maxRightAngle);
                }
                launchPreview(touchPos);
            }
            else
            {
                lineRenderer.enabled = false;
            }

            Debug.Log(transform.rotation.eulerAngles);
        }

    }

    void launchPreview(Vector2 pos)
    {
        lineRenderer.enabled = true;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, pos);
    }

}

