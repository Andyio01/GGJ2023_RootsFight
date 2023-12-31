using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoundXManager : MonoBehaviour
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
        Button btn = GameObject.Find("returnHome").GetComponent<Button>();
        btn.onClick.AddListener(delegate { ReturnHome(); });

    }
    
    public void ReturnHome()
    {
        SceneManager.LoadScene("002_Home");
        GlobalManager.SetN(GlobalManager.GetN() + 1);
        Debug.Log("GlobalManager n = " + GlobalManager.GetN());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
