using UnityEngine;

public class PcScript : MonoBehaviour
{
    private Rigidbody rbd;
    private Quaternion startRotation;
    private float xMouse = 0;
    private AudioSource somTiro;

    public GameObject cabeca;
    public float vel;
    public float speedRotate;
    public float dist = 100;
    public LayerMask mascara;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        vel = 10;
        speedRotate = 100;
        startRotation = transform.localRotation;
        rbd = GetComponent<Rigidbody>();
        somTiro = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Rotate();
        Shoot();
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

    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            //somTiro.Play;

            if (Physics.Raycast(
                cabeca.transform.position,
                cabeca.transform.forward,
                out hit,
                dist,
                mascara
                ))
            {
                Rigidbody rbdAtingivel;
                rbdAtingivel = hit.collider.GetComponent<Rigidbody>();
                rbdAtingivel.AddForce(cabeca.transform.forward * 500);
            }
        }
    }
}
