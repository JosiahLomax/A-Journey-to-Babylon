using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarAssigner : MonoBehaviour
{
    //Yes I KNOW this script odesn't need to exist if I program
    //the stats thing better ;-;
    //hey at least I csan like reuse it for bosses or somethin

    [SerializeField] Slider HealthBar;
    [SerializeField] Stats Assigned;
    void Start()
    {
        //I know I know it's a fucking find function ;-;
        GameObject BarObject = GameObject.Find("ActionsUI/Slider");
        if(BarObject != null)
        {
            HealthBar = BarObject.gameObject.GetComponent<Slider>();

            Assigned.Bar = HealthBar;
            Assigned.UpdateHealth(Assigned.Health); 
        }

    }
}