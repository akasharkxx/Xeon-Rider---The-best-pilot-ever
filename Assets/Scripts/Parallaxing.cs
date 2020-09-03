using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    public Transform[] backgrounds;
    private float[] parllaxScales;      //proportion of camera movement to move background
    public float smoothing = 1f;        //Smoothness of parallaxing. To be more than 0
    private Transform cam;              //reference to maincamera
    private Vector3 previousCamPos;     //the position of camera in previous frame    
    
    //Is called before start after gameobjects set up.Great for references
    void Awake()
    {
        Application.targetFrameRate = 60;
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        // The previous frame had the current frame's camera position
        previousCamPos = cam.position;

        // assiging corresponding parallaxScales
        parllaxScales = new float[backgrounds.Length];
        for(int i = 0; i < backgrounds.Length; i++){
            parllaxScales[i] = backgrounds[i].position.z*-1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < backgrounds.Length; i++){
            // the parallax is the opposite of the camera movement because the previous frame multiplied by the scale
            float parallaxX = (previousCamPos.x - cam.position.x) * parllaxScales[i];
            float parallaxY = (previousCamPos.y - cam.position.y) * parllaxScales[i] * 0.2f;

            // need to set target x position which is the current position plus the parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallaxX; 
            float backgroundTargetPosY = backgrounds[i].position.y + parallaxY; 
            
            // create a target position which is the background's current position with its target x position
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgroundTargetPosY, backgrounds[i].position.z);

            // fade between current position and the target position using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);    
        }
        // set previousCamPos to the camera's postion at the end of the frame
        previousCamPos = cam.position; 
    }
}
