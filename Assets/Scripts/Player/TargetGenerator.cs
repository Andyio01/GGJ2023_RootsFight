using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class TargetGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        GetComponent<GeneDiff>().GeneSelect(GlobalManager.rootDNA_str);
        transform.GetChild(0).GetComponent<Animator>().Play("idle");
    }
}
