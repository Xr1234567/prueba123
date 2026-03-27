using UnityEngine;

public class Puerta : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Suelo" && !(collision.gameObject.tag == "Pared"))
        {
            gameObject.SetActive(false);
        }

    }
}
