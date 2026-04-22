using UnityEngine;

public class enemigo1 : MonoBehaviour
{
    public enemigo1 instance;
    private Transform player;
    public float speed = 10f;
    [SerializeField] float vida = 4f;

    private bool IsFacingRight = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position , player.position, speed * Time.deltaTime);

        bool isPlayerOnRight = player.transform.position.x > transform.position.x;
        Flip(isPlayerOnRight);
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Flip(bool isPlayerOnRight)
    {
        if ((IsFacingRight && !isPlayerOnRight) || (!IsFacingRight && isPlayerOnRight))
        {
            IsFacingRight = !IsFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
    public void QuitarVida(float danno)
    {
        vida=vida-danno;
    }
    public void QuitarVida()
    {
        vida--;
    }
}
