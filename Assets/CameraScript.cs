using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Quaternion startRotation;
    private float yMouse;
    private float speedRotation;
    // Start is called before the first frame update
    void Start()
    {
        speedRotation = 10;
        startRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        yMouse += Input.GetAxisRaw("Mouse Y") * Time.timeScale * speedRotation;
        yMouse = Mathf.Clamp(yMouse,-60, 90);
        Quaternion rotMouse = Quaternion.AngleAxis(yMouse, Vector3.left);
        transform.localRotation = startRotation * rotMouse;
    }
}
