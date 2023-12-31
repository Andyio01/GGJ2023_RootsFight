using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    private void Awake() {
        Screen.SetResolution(1920,1080,FullScreenMode.FullScreenWindow);
    }
}
