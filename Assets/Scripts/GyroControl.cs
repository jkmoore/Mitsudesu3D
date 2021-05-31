using UnityEngine;

public class GyroControl : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;

    private GameObject cameraContainer;
    private Quaternion rot;

    private void Start()
    {
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);

        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            //if x is 0, when device lies flat camera faces forward, so set to 90
            //if y is 0, camera faces same direction as screen, so change to 180
            cameraContainer.transform.rotation = Quaternion.Euler(90f, 180f, 0f);
            rot = new Quaternion(0, 0, 1, 0);

            return true;
        }

        return false;
    }

    private void Update()
    {
        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rot;
        }
    }
}
