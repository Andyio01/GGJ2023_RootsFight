using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    
    public TMP_Text txtTimer;    //存放组件的变量
    public int second = 30;    //倒计时时间30秒
    private float nextTime = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer1();
    }

    private void Timer1()
    {
        // Debug.Log("Timer1 被调用");    // 打印调试
        if (second >0)    // second < 0 停止倒计时
        {
            if (Time.time >= nextTime)    // 当开计时的时间大于定义的1秒
            {
                second--;    //减一秒钟
                txtTimer.text = string.Format("{1:d2}", second / 60, second % 60);    //格式化输出
                
                nextTime = Time.time + 1;   //变成当前时间的后一秒（为当前时间加1秒，判断当前时间后一秒再执行）
            }
        }
        
    }
}

