using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifebar : MonoBehaviour
{

    public Controller player;
    public Slider bar;

    // Start is called before the first frame update
    void Start()
    {
        bar.value = player._hp;
    }

    public void UpdateLifebar(int value)
    {
        bar.value = value;
    }
}
