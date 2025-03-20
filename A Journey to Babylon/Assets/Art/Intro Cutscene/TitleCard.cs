using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleCard : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Final Main Scene", LoadSceneMode.Single); 
    }
}
