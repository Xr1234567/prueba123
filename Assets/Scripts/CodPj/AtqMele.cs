using UnityEngine;

public class AtqMele : MonoBehaviour
{
    // El prefab que hace de atq
    public GameObject GolpeD;
    public GameObject GolpeI;
    // Selecciono puntos de spawn para los atqs. 1 para los de la derecha (primeros), y 2 para los de la izq. El atq del pj es golpe de derecha -> golpe de izquierda -> repetir
    public Transform Arriba1;
    public Transform Arriba2;
    public Transform Abajo1;
    public Transform Abajo2;

    //Temporizador dicta cada cuántos segundos va a poder atacar, mientras que tiempo sirve para hacer la función de temporizador (ir bajandole el tiempo hasta que sea 0)
    public float Temporizador = 1f;
    public float tiempo;

    //Si es true, no ha hecho atqs, así que ataca con la derecha (1). Si es false, ya ha atacado 1 vez, así que ataca con la izq.
    public bool atq = true;
    // Timer para el ataque, lo mismo que temporizador y tiempo, pero este para reiniciar lo de atacar con derecha e izq.
    public float TempAtq = 4f;
    public float TAtq;
    void Start()
    {
        tiempo = Temporizador;
        TAtq = TempAtq;
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempo <= 0)
        {
            if (Input.GetKey("right"))
            {

                //spawnea una copia del atq hecho en el prefab. Hay que decirle obj q copiar, posición, y rotación
                GameObject GolpeDTemp = Instantiate(GolpeD, new Vector3(transform.position.x, 0, transform.position.z + 1), Quaternion.Euler(0, 90, 0));
                tiempo = Temporizador;
                TAtq = TempAtq;
            }
            else if (Input.GetKey("left"))
            {

                GameObject GolpeDTemp = Instantiate(GolpeD, new Vector3(transform.position.x, 0, transform.position.z - 1), Quaternion.Euler(0, 90, 0));


                tiempo = Temporizador;
                TAtq = TempAtq;
            }
            else if (Input.GetKey("up"))
            {

                GameObject GolpeDTemp = Instantiate(GolpeD, new Vector3(transform.position.x - 1, 0, transform.position.z), Quaternion.identity);


                tiempo = Temporizador;
                TAtq = TempAtq;
            }
            else if (Input.GetKey("down"))
            {

                GameObject GolpeDTemp = Instantiate(GolpeD, new Vector3(transform.position.x + 1, 0, transform.position.z), Quaternion.identity);

                tiempo = Temporizador;
                TAtq = TempAtq;
            }
        }
        if (tiempo >= 0) tiempo -= Time.deltaTime;
        if (TAtq >= 0) TAtq -= Time.deltaTime;
        if (TAtq < 0) atq = true;
    }
}
