using UnityEngine;
using System.Collections;

public class MovPj : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    public float VelLinear = 20f;
    public float VelDiagonal = 14.14f;

    // cooldown duration (seconds)
    public float tiempo = 3f;
    public float temporizador;

    private float MoveH, MoveV;

    public bool _dashing;

    [SerializeField] private float dashMultiplier = 5f;
    [SerializeField] private float dashDuration = 0.10f;

    private Vector2 input;
    private float cooldownTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cooldownTimer = temporizador;
    }

    void Update()
    {
        // Read inputs every frame
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        MoveH = input.x;
        MoveV = input.y;

        // Trigger dash once when key pressed and cooldown finished
        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer <= 0f)
        {
            StartCoroutine(DashCoroutine());
        }

        // Update cooldown timer and sync inspector value
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
            temporizador = Mathf.Max(cooldownTimer, 0f);
        }
        else
        {
            temporizador = 0f;
        }
    }

    void FixedUpdate()
    {
        Vector3 movimiento = new Vector3(-MoveV, 0f, MoveH);
        if (movimiento.sqrMagnitude > 1f) movimiento.Normalize();

        float currentSpeed = speed * (_dashing ? dashMultiplier : 1f);
        rb.linearVelocity = movimiento * currentSpeed;
    }

    private IEnumerator DashCoroutine()
    {
        _dashing = true;
        cooldownTimer = tiempo;
        temporizador = cooldownTimer;
        yield return new WaitForSeconds(dashDuration);
        _dashing = false;
    }
}