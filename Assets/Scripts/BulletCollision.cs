using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Contains("Gun"))
        {
            return;
        }
        Destroy(gameObject);
        if (collision.collider.tag == "Enemy")
        {
            collision.collider.gameObject.GetComponent<EnemyController>().ReduceHealth();
        }
    }
}
