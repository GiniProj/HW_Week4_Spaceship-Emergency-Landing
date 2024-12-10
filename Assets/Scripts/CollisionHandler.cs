using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [Header("Collision Settings")]
    [SerializeField] private float maxLandingVelocity = 5f;
    [Header("Scene Management")]
    [SerializeField] private GoToNextScene goToNextScene;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LandingZone"))
        {
            float collisionVelocity = collision.relativeVelocity.magnitude;

            if (collisionVelocity > maxLandingVelocity)
            {
                goToNextScene.ActivateGameOverScene();
            }
            else
            {
                goToNextScene.ActivateNextScene();
            }
        }
        else if (collision.gameObject.CompareTag("NotLandingZone"))
        {
            goToNextScene.ActivateGameOverScene();
        }
        else if (collision.gameObject.CompareTag("StartingZone"))
        {
            Debug.Log("Game Started: Collision with StartingZone");
        }
        else
        {
            Debug.LogWarning("Collision with unknown object: " + collision.gameObject.name);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("StartingZone"))
        {
            other.gameObject.SetActive(false);
        }
    }
}