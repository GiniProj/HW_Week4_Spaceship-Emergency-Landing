using UnityEngine;

public class StartLandingPoint : MonoBehaviour
{
    void OnEnable()
    {
        gameObject.SetActive(true);  // OnEnable is called when the object becomes enabled and active, for play again option
    }

}
