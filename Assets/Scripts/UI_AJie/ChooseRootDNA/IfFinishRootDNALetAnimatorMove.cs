using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class IfFinishRootDNALetAnimatorMove : MonoBehaviour
{
    void Start()
    {
        EventCenter.GetInstance().AddEventListener(EventTypes.FinishChooseRootDNA, () =>
        {
            GetComponent<Animator>().enabled = true;
        });
    }
}
