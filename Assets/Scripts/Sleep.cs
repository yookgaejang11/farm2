using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sleep : MonoBehaviour
{
    public int sleepTime;
    public Text timetxt;

    public int value;
    public Text valuetxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SleepTimeValue(bool plus)
    {
        if(plus)
        {
            if (sleepTime >= 12)
            {
                GameManager.Instance.Error("더 오래 잘 수 없습니다!!");
                sleepTime = 12;
                return;
            }
            sleepTime++;
        }
        else
        {
            if(sleepTime <=1)
            {
                sleepTime = 1;
                return;
            }
            sleepTime--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timetxt.text = sleepTime.ToString();
        if(GameManager.Instance.happyDay)
        {
            if(sleepTime >=10)
            {
                value = 10 * 10 + 30;

            }
            else
            {
                value = sleepTime * 10 + 30;
            }
        }
        else
        {
            if (sleepTime >= 10)
            {
                value = 10 * 10;

            }
            else
            {
                value = sleepTime * 10;
            }
        }
    }

    public void sleep()
    {
        if (GameManager.Instance.happyDay)
        {
            GameManager.Instance.curtired -= value;
        }
        else
        {
            if(GameManager.Instance.curtired - value < 0)
            {
                GameManager.Instance.curtired = 0;
            }
            else
            {
                GameManager.Instance.curtired -= value;
            }
        }
    }
}
