using UnityEngine;

public class PcScript : MonoBehaviour
{
    private Rigidbody rbd;
    public float vel;
    // Start is called before the first frame update
    void Start()
    {
        vel = 10;
        rbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float front = Input.GetAxis("Vertical");
        float side = Input.GetAxis("Horizontal");

        rbd.velocity = new Vector3(side * vel,
            rbd.velocity.y,
            front * vel);
    }
}
