using UnityEngine;

public class MovPj : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;

    public float VelLinear = 20f;
    public float VelDiagonal = 14.14f;

    public float tiempo = 3;
    public float temporizador;

    public bool _dashing;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float MoveH = Input.GetAxis("MovH");
        float MoveV = Input.GetAxis("MovV");

        if (Input.GetKey(KeyCode.Space) && temporizador <= 0)
        {
            Dasheo(MoveH, MoveV);
            temporizador = tiempo;
            _dashing = true;
        }
        if (temporizador >= 0) temporizador -= Time.deltaTime;

        if (!_dashing) transform.Translate(new Vector3(MoveH, 0, MoveV) * speed * Time.deltaTime);
    }
    bool Dasheo(float direccion1, float direccion2)
    {
        for (float i = 2; i <= 0; i -= Time.deltaTime)
        {
            if (direccion1 == 0 || direccion2 == 0)
            {
                transform.Translate(new Vector3(direccion1, 0, direccion2) * VelLinear * Time.deltaTime);
            }
            else
            {
                transform.Translate(new Vector3(direccion1, 0, direccion2) * VelDiagonal * Time.deltaTime);
            }
        }
        _dashing = false;
        return _dashing;
    }
}
