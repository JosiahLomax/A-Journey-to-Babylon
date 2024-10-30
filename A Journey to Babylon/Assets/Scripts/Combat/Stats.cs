using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{

    public int Health;
    public int Attack;
    public List<string> Status;
    public List<MagicMoves> Moves;
    [Header("Health Bar")]
    public Slider Bar;

    void Start()
    {
        UpdateHealth(Health);
    }

    public void UpdateHealth(int x)
    {
        if(Bar == null) return;
        Health = x;
        Bar.maxValue = Health;
        Bar.value = Health;
    }
    
    public void Damage(int x)
    {
        Health -= x;
        if(Health <= 0)
        {
            Bar.value = 0;
        }
        else
        {
            Bar.value -= Health;
        }
    }
    public void Heal(int x)
    {
        Health += x;
        Bar.value += Health;
    }
}
