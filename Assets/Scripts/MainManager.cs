using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    private void Awake()
    {
        GameObject gb = GlobalManager.LoadGlobalPrefabObject(); 
        if (gb != null)
        {
            Instantiate(gb);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GameObject.Find("Start").GetComponent<Button>();
        btn.onClick.AddListener(delegate
        {
            SceneManager.LoadScene("002_Home");
            GameObject gb = GameObject.FindGameObjectWithTag("GlobalObject");
            GameObject.DontDestroyOnLoad(gb);
            GlobalManager.SetN(GlobalManager.GetN() + 1);
            Debug.Log("GlobalManager n = " + GlobalManager.GetN());
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
