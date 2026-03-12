using System.Runtime.CompilerServices;
using UnityEngine;

public class PosCamara : MonoBehaviour
{
    public GameObject camara;
    private float x, z;
    private void Start()
    {
        x= transform.position.x;
        z= transform.position.z;
    }
    private void OnCollisionEnter(Collision collision)
    {
        


        if (collision.gameObject.CompareTag("Player"))
        {
            camara.transform.position = new Vector3(x, 10, z);
        }
    }
}
