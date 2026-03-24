using System.Runtime.CompilerServices;
using UnityEngine;

public class PosCamara : MonoBehaviour
{
    [SerializeField] private Transform enemigo;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < 2; i++)
            {
                float x = Random.Range(-4, 4);
                float z = Random.Range(-4, 4);
                Instantiate(enemigo, new Vector3(transform.position.x + x, 5, transform.position.z + z), Quaternion.identity);
            }

        }
    }
}
