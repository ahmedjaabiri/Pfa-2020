using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class settxt : MonoBehaviour
{
    TextMeshPro textmeshPro;
    void Start()
    {
         textmeshPro = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public TextMeshPro gettextmesh()
    {
        return textmeshPro;
    }
}
