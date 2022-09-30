using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelVariables : MonoBehaviour
{
    private int hits = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHits()
    {
        hits++;
        Debug.Log("Hits taken: " + hits);
    }
}
