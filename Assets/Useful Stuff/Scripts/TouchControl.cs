﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    Vector3 FirstPoint;
    Vector3 SecondPoint;
    float xAngle;
    float yAngle;
    float xAngleTemp;
    float yAngleTemp;

    void Start()
    {
        xAngle = -90;
        yAngle = 0;
        this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0);
    }


    void Update()
    {

        if (Input.touchCount == 1 && !ButtonHandler.btClick && GetComponent<Camera>().enabled)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                FirstPoint = Input.GetTouch(0).position;
                xAngleTemp = xAngle;
                yAngleTemp = yAngle;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved){
                SecondPoint = Input.GetTouch(0).position;
                xAngle = xAngleTemp - (SecondPoint.x - FirstPoint.x) * 180 / Screen.width;
                yAngle = yAngleTemp + (SecondPoint.y - FirstPoint.y) * 90 / Screen.height;
                if (this.GetComponent<Camera>().enabled)
                    this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
            }
        }
    }
}
