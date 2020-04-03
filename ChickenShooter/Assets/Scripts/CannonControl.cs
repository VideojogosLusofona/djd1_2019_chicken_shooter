using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour
{
    public float minRotation = -30.0f;
    public float maxRotation = 45.0f;

    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector2 mpPixelCoords = Input.mousePosition;

        Vector3 mpWorldCoords = mainCamera.ScreenToWorldPoint(mpPixelCoords);

        Vector2 toCursor = mpWorldCoords - transform.position;

        toCursor.Normalize();

        /* // CLAMP USING INPUT
        float angle = Mathf.Atan2(toCursor.y, toCursor.x) * Mathf.Rad2Deg;

        float currentRotation = transform.parent.rotation.eulerAngles.z;
        if (currentRotation > 180.0f) currentRotation = currentRotation - 360;

        angle = angle - currentRotation;

        if ((angle > maxRotation) && (angle < (180 - maxRotation))) return;

        if ((angle < minRotation) && (angle > -(180 + minRotation))) return;*/


        /*      // VERSÃO SIMPLES COM PROBLEMAS
         *      transform.right = toCursor;

                if (transform.up.y < 0)
                {
                    transform.up = -transform.up;
                }*/

        // VERSÃO MAIS COMPLICADA, MAS QUE NÃO TEM CLAMPING
        //RotateTo(toCursor);

        // VERSÃO AINDA MAIS COMPLICADA, QUE TEM CLAMPING
        RotateToUsingClamping(toCursor);
    }

    void RotateTo(Vector3 direction)
    {
        Vector3 forward = Vector3.forward;
        Vector3 upwards = Vector3.up;

        if (direction.x < 0) forward = -forward;

        upwards = Vector3.Cross(forward, direction);

        transform.rotation = Quaternion.LookRotation(forward, upwards);
    }

    void RotateToUsingClamping(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        float currentRotation = transform.parent.rotation.eulerAngles.z;
        if (currentRotation > 180.0f) currentRotation = currentRotation - 360;

        Vector3 eulerAngles = Vector3.zero;

        if (direction.x < 0)
        {
            eulerAngles.y = 180;

            angle = (angle < 0) ? (360 + angle) : (angle);

            eulerAngles.z = 180 - Mathf.Clamp(angle, 180 - maxRotation + currentRotation, 180 - minRotation + currentRotation);
        }
        else
        {
            eulerAngles.z = Mathf.Clamp(angle, minRotation + currentRotation, maxRotation + currentRotation);
        }

        Quaternion rotation = Quaternion.Euler(eulerAngles);

        transform.rotation = rotation;

/*        Vector3 forward = Vector3.forward;
        Vector3 upwards = Vector3.up;

        if (direction.x < 0) forward = -forward;

        upwards = Vector3.Cross(forward, direction);

        transform.rotation = Quaternion.LookRotation(forward, upwards);*/
    }
}
