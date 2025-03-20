using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningTheRift : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("TitleCard", LoadSceneMode.Single);
    }
}
