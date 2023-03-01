using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class World : MonoBehaviour
{
    public TextMeshProUGUI world;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        world.text = "World \n 1-1s".ToString();

    }
}
