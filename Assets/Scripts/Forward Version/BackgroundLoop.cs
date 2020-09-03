using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    
    private Camera mainCamera;
    private Vector2 screenBounds;

    private void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        for(int i = 0; i < levels.Length; i++)
        {
            LoadChildObjects(levels[i]);
        }
    }

    private void LoadChildObjects(GameObject childObject)
    {
        float objectHeight = childObject.GetComponent<SpriteRenderer>().bounds.size.y;
        int childsNeeded = (int)Mathf.Ceil(screenBounds.y * 2 / objectHeight);
        GameObject clone = Instantiate(childObject) as GameObject;
        for(int i = 0; i <= childsNeeded; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(childObject.transform);
            c.transform.position = new Vector3(childObject.transform.position.x, objectHeight * i, childObject.transform.position.z);
            c.name = childObject.name + i;
        }
        Destroy(clone);
    }
}
