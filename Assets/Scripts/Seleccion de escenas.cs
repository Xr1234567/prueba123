using UnityEngine;

public class Selecciondeescenas : MonoBehaviour
{
    [SerializeField] private string[] escenas; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void SeleccionarMapa()
    {
        int mapa = Random.Range(0, escenas.Length); 
        Debug.Log(mapa);
        UnityEngine.SceneManagement.SceneManager.LoadScene(escenas[mapa]);
    }
}
