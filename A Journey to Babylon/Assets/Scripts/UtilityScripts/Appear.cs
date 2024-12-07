using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour
{
    public void SwitchActive()
    {
        this.gameObject.SetActive(!gameObject.active);
    }
}
