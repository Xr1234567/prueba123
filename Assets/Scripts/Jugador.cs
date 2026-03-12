using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private GameObject camara;
    private Rigidbody rb;
    private float xInput, zInput;

    // Update is called once per frame
    void Awake()
    {
        rb= GetComponent<Rigidbody>();
        camara.GetComponent<Camera>();
    }
    private void movimiento()
    {
        zInput = Input.GetAxis("Horizontal");
        xInput = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(-xInput, 0, zInput) * velocidad;
        rb.linearVelocity = movimiento;
    }
    private void FixedUpdate()
    {
        movimiento();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            camara.transform.position = new Vector3(collision.transform.position.x, 10, collision.transform.position.z);
        }
    }
}
