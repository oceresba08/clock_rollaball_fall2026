
using UnityEngine;

public class RainbowImpact : MonoBehaviour
{
    public float impactForce = 3f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb =
                collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                Vector3 direction =
                    (collision.transform.position -
                     transform.position).normalized;

                playerRb.AddForce(
                    direction * impactForce,
                    ForceMode.Impulse
                );
            }
        }
    }
}
