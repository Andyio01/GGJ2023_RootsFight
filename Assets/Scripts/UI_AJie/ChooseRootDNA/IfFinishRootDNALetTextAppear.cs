using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class IfFinishRootDNALetTextAppear : MonoBehaviour
{
    void Start()
    {
        EventCenter.GetInstance().AddEventListener(EventTypes.FinishChooseRootDNA, () =>
        {
            //this.gameObject.SetActive(true);
            GetComponent<Text>().enabled = true;
        });
    }
}
