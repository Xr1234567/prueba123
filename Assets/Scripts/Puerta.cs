using UnityEngine;

public class Puerta : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            gameObject.SetActive(false);
        }

    }
}
