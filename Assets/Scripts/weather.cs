using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weather : MonoBehaviour
{
    [SerializeField]
    Text text;
    public List<GameObject> weatherList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.Instance.whether)
        {
            case GameManager.whether_type.sunny:
                for(int i = 0; i < weatherList.Count; i++)
                {
                    weatherList[i].SetActive(false);
                }
                weatherList[0].SetActive(true);
                text.text = "¸¼À½";
                break;
            case GameManager.whether_type.rainy:
                for (int i = 0; i < weatherList.Count; i++)
                {
                    weatherList[i].SetActive(false);
                }
                weatherList[1].SetActive(true);
                text.text = "ºñ";
                break;
            case GameManager.whether_type.storm:
                for (int i = 0; i < weatherList.Count; i++)
                {
                    weatherList[i].SetActive(false);
                }
                weatherList[2].SetActive(true);
                text.text = "ÆøÇ³";
                break;
            case GameManager.whether_type.cloudy:
                for (int i = 0; i < weatherList.Count; i++)
                {
                    weatherList[i].SetActive(false);
                }
                weatherList[3].SetActive(true);
                text.text = "Èå¸²";
                break;
            case GameManager.whether_type.ice_ball:
                for (int i = 0; i < weatherList.Count; i++)
                {
                    weatherList[i].SetActive(false);
                }
                weatherList[4].SetActive(true);
                text.text = "¿ì¹Ú";
                break;
        }
    }
}
