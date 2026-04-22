using UnityEngine;

public class puñetazo : MonoBehaviour
{

    void Update()
    {
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        enemigo1 enemigo = other.GetComponent<enemigo1>();
        if (other.CompareTag("Enemy"))
        {
            //enemigo.QuitarVida(AtqMele.instance.danno);
            enemigo.QuitarVida();
        }
    }
}

