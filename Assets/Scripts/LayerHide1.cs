using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayerHide1 : MonoBehaviour
{
    public GameObject HideLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HideLayer.GetComponent<PredictManager>().countP1 > 0)
        {
            HideLayer.GetComponent<Image>().enabled = true;
        }
    }
}
