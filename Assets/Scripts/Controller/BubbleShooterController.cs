using UnityEngine;
using System.Collections;
namespace com.javierquevedo
{
    public class BubbleShooterController : MonoBehaviour
    {

        public bool isAiming;
        
        private float maxLeftAngle = 85.0f;
        private float maxRightAngle = 275.0f;

        private Ray mouseRay;
        private RaycastHit hit;

        private LineRenderer lineRenderer;
        public Color lineRendererColor;

        void Start()
        {
            isAiming = true;
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.useWorldSpace = true;
        }

        void Update()
        {
            if (TouchController.Instance.isTouching)
            {
                Vector3 touchPos = TouchController.Instance.touchPosition;
                //calculate rotation for shooter which is then read by the "bubble object";

                Vector2 lookDir = touchPos - transform.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = rotation;

                if (!TouchController.Instance.isTouchingUI)
                    launchPreview(touchPos);

                if (transform.eulerAngles.z > this.maxLeftAngle && transform.eulerAngles.z < 180.0)
                {
                    lineRenderer.enabled = false;
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, maxLeftAngle);
                }
                if (transform.eulerAngles.z < this.maxRightAngle && transform.eulerAngles.z > 180.0)
                {
                    lineRenderer.enabled = false;
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, maxRightAngle);
                }
            }
            else
            {
                lineRenderer.enabled = false;
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

}