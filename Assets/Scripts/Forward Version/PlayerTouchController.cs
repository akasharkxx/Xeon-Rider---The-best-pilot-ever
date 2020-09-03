using UnityEngine;

public class PlayerTouchController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float smoothness;
    [SerializeField] private float touchDistance;

    private Vector2 refVelocity;
    private bool touchStart, isInTouchDistance;
    private Vector2 pointA, pointB;
    private Rigidbody2D playerBody;

    private void Start()
    {
        touchStart = false;
        isInTouchDistance = false;
        playerBody = GetComponent<Rigidbody2D>();
        refVelocity = Vector2.zero;
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            if(Vector2.Distance(transform.position, pointA) <= touchDistance)
            {
                isInTouchDistance = true;
            }
            else
            {
                isInTouchDistance = false;
            }
        }
        if (Input.GetMouseButton(0) && isInTouchDistance)
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
            isInTouchDistance = false;
        }
    }

    private void FixedUpdate()
    {
        if (touchStart)
        {
            transform.position = Vector2.SmoothDamp(transform.position, pointB, ref refVelocity, smoothness);
        }
    }
}
