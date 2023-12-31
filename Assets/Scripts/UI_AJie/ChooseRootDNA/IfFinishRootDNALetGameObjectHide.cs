using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class IfFinishRootDNALetGameObjectHide : MonoBehaviour
{
    void Start()
    {
        EventCenter.GetInstance().AddEventListener(EventTypes.FinishChooseRootDNA, () =>
        {
            this.gameObject.SetActive(false);
        });
    }
}
