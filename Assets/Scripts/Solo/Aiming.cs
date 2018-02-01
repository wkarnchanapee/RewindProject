using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Aiming : MonoBehaviour {

    public enum RotAxis
    {
        X = 0,
        Y = 1
    }

    public RotAxis RotAxisXY;

    [SerializeField] float x, y, sensitivity = 0f;
    public float RotX, RotY;
    float minX = -360f;
    float maxX = 360f;
    float minY = -45f;
    float maxY = 45f;

    Quaternion xQuat;
    Quaternion yQuat;

    Quaternion OrigRotation;

	void Start()
	{	Cursor.lockState = CursorLockMode.Locked;
	}
    // Update is called once per frame
    void Update()
    {   
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");

        if (RotAxisXY == RotAxis.X)
        {
            RotX += x * sensitivity * Time.deltaTime;
            RotX = ClampAngle(RotX, minX, maxX);
            OrigRotation = xQuat = Quaternion.AngleAxis(RotX, Vector3.up);
            transform.localRotation = OrigRotation * xQuat;
        }

        if (RotAxisXY == RotAxis.Y)
        {
            RotY -= y * sensitivity * Time.deltaTime;
            RotY = ClampAngle(RotY, minY, maxY);
            OrigRotation = yQuat = Quaternion.AngleAxis(RotY, Vector3.right);
            transform.localRotation = OrigRotation * yQuat;
        }
    }

    public static float ClampAngle(float Angle, float Min, float Max)
    {
        if (Angle < -360f)
            Angle += 360f;
        if (Angle > 360f)
            Angle -= 360f;
        return Mathf.Clamp(Angle, Min, Max);
    }

}
