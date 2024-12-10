using UnityEngine;

public class Spaceship : MonoBehaviour
{
    private static Spaceship instance;

    public static Spaceship Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<Spaceship>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<Spaceship>();
                    singletonObject.name = typeof(Spaceship).ToString() + " (Singleton)";
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}