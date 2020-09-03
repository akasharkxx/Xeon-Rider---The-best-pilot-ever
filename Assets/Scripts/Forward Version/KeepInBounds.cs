using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInBounds : MonoBehaviour
{
    //Screen bounds variables
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject player;

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    private void Start()
    {
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        objectWidth = player.GetComponentInChildren<SpriteRenderer>().bounds.extents.x;
        objectHeight = player.GetComponentInChildren<SpriteRenderer>().bounds.extents.y;
    }

    private void LateUpdate()
    {
        Vector3 viewPosition = player.transform.position;
        viewPosition.x = Mathf.Clamp(viewPosition.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPosition.y = Mathf.Clamp(viewPosition.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        player.transform.position = viewPosition;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }
}
