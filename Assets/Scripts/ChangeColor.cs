using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{  
    
    // Start is called before the first frame update
    void Start()
    {
        var Featurecolor = GetComponent<SpriteRenderer>();
        Featurecolor.color = new Color(100/255f,100/255f,100/255f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
