using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy the new instance if it's not the first one
            Destroy(gameObject);
        }
    }

    public void LoadScene(int x)
    {
        SceneManager.LoadScene(x);
    }
}




