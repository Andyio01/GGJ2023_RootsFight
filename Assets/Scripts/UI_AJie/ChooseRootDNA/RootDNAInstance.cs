using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootDNAInstance : MonoBehaviour
{
    public static RootDNAInstance instance;

    public List<char> _1P_rootDNA = new List<char>();
    public List<char> _2P_rootDNA = new List<char>();
    public List<char> rootDNA = new List<char>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
