using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
     public SpriteRenderer maze;

    
    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = maze.bounds.size.x / maze.bounds.size.y;

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = maze.bounds.size.y / 2;
        } else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = maze.bounds.size.y / 2 * differenceInSize;
        }
    }

}
