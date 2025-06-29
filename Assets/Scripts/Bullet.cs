using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction = Vector3.right;
    private Vector3 velocity;
    [SerializeField] private float speed = 15.0f;
    RaycastHit2D hit;
    public Vector3 Direction
    {
        get { return direction; }
        set { direction = value; }
    }

    void Update()
    {
        velocity = direction * speed * Time.deltaTime;
        transform.position += velocity;

        if (hit.collider != null)
        {
            Destroy(hit.collider.gameObject);
            Destroy(gameObject);
        }
    }
}