using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private Rigidbody rb;
    private float xInput, zInput;

    // Update is called once per frame
    void Awake()
    {
        rb= GetComponent<Rigidbody>();
    }
    private void movimiento()
    {
        zInput = Input.GetAxis("Horizontal");
        xInput = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(xInput, 0, zInput) * velocidad;
        rb.linearVelocity = movimiento;
    }
    private void FixedUpdate()
    {
        movimiento();
    }
}
