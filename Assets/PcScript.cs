using UnityEngine;

public class PcScript : MonoBehaviour
{
    private Rigidbody rbd;
    private Quaternion startRotation;
    private float xMouse = 0;

    public float vel;
    public float speedRotate;
    // Start is called before the first frame update
    void Start()
    {
        vel = 10;
        speedRotate = 100;
        startRotation = transform.localRotation;
        rbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Rotate();
    }

    private void Walk()
    {
        float front = Input.GetAxis("Vertical");
        float side = Input.GetAxis("Horizontal");

        rbd.velocity = transform.TransformDirection(new Vector3(side * vel,
            rbd.velocity.y,
            front * vel));
    }

    private void Rotate()
    {
        xMouse += Input.GetAxisRaw("Mouse X") * Time.deltaTime * speedRotate;
        Quaternion rotMouse = Quaternion.AngleAxis(xMouse, Vector3.up);
        transform.localRotation = startRotation * rotMouse;
        Debug.Log(rotMouse.ToString());
    }
}
