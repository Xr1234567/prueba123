using UnityEngine;

public class enemigo1 : MonoBehaviour
{
    private Transform player;
    public float speed = 10f;

    private bool IsFacingRight = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position , player.position-new Vector3(1,0,1), speed * Time.deltaTime);

        bool isPlayerOnRight = player.transform.position.x > transform.position.x;
        Flip(isPlayerOnRight);
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
}
