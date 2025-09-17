using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum waterCanLevel
{
    basic,
    rare
}

public enum GarrageLevel
{
    Level1,
    Level2,
    Level3
}

public class GameManager : MonoBehaviour
{
    public enum playerHoe
    {
        basic,
        rare
    }

    public enum playerWaterCan
    {
        basic, rare
    }
    public enum seedType
    {
        None,
        wheat,
        corn,
        carrot,
        blue_corn,
        red_wheat
    }

    public enum whether_type
    {
        sunny,
        cloudy,
        rainy,
        storm,
        ice_ball
    }


    public int maxtired;
    public int curtired;

    public GameObject gageColor;

    public Slider TiredSlider;
    public GameObject happyImg;
    public bool happyDay = false;
    public int sunnyplus = 0;
    public playerHoe hoe;
    public playerWaterCan waterCan;
    public whether_type whether;
    public seedType seeds;
    public Text PlayerMoneyTxt;
    public Player player;
    private static GameManager instance;
    public Text time;
    public float inGameTime =10; //1초당 12분  5초는 1시간 1분에 12시간 2분에 하루

    public Dictionary<string, int> SeedPrice = new Dictionary<string, int>()
    {
        {"wheat", 3000 },
        {"corn", 10000 },
        {"carrot", 16000 },
        {"blue_corn", 28000 },
        {"red_wheat", 30000 }
    };

    public Dictionary<string, int> bfCropPrice = new Dictionary<string, int>()
    {
        {"wheat", 3000 },
        {"corn", 9000 },
        {"carrot", 18000 },
        {"blue_corn", 24000 },
        {"red_wheat", 30000 }
    };


    public Dictionary<string, int> curCropPrice = new Dictionary<string, int>()
    {
        {"wheat", 2000 },
        {"corn", 0 },
        {"carrot", 0 },
        {"blue_corn", 0 },
        {"red_wheat", 0 }
    };

    public Dictionary<string, int> ftCropPrice = new Dictionary<string, int>()
    {
        {"wheat", 2000 },
        {"corn", 0 },
        {"carrot", 0 },
        {"blue_corn", 0 },
        {"red_wheat", 0 }
    };

    public GameObject GarrageUI;
    public GameObject garrageTxt;
    public bool garrageActive = false;


    public Text ErrorTxt;
    public GameObject GetWaterUI;
    public int wheat_seed = 0;
    public int corn_seed = 0;
    public int carrot_seed = 0;
    public int blue_corn_seed = 0;
    public int red_wheat_seed = 0;
    public int allCount = 0;

    public int wheat = 0;
    public int corn = 0;
    public int carrot = 0;
    public int blue_corn = 0;
    public int red_wheat = 0;

   
    private void Awake()
    {
        if(instance == null)
        {

        instance = this; 
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(Timer());
        int whetherNum = Random.Range(1, 6);
        switch (whetherNum)
        {
            case 1:
                whether = whether_type.sunny;
                break;
            case 2:
                whether = whether_type.cloudy;
                break;
            case 3:
                whether = whether_type.rainy;
                break;
            case 4:
                whether = whether_type.storm;
                break;
            case 5:
                whether = whether_type.ice_ball;
                break;
        }
        if(whether == whether_type.sunny)
        {
            sunnyplus += 1;
        }

        curCropPrice["wheat"] = Random.Range(2000, 4001);
        curCropPrice["corn"] = Random.Range(6000, 12001);
        curCropPrice["carrot"] = Random.Range(12000, 24000);



        curCropPrice["blue_corn"] = Random.Range(16000, 32000);



        curCropPrice["red_wheat"] = Random.Range(20000, 40000);

        TiredSlider.maxValue = maxtired;
        TiredSlider.value = curtired;
    }

    public int AllCount()
    {
        return wheat + corn + carrot + blue_corn + red_wheat + wheat_seed + corn_seed + carrot_seed + blue_corn_seed + red_wheat_seed;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoneyTxt.text = player.haveMoney.ToString();
        if(inGameTime == 0)
        {
            int whetherNum = Random.Range(1, 6);
            switch(whetherNum)
            {
                case 1:
                    whether = whether_type.sunny;
                    break;
                case 2:
                    whether= whether_type.cloudy;
                    break;
                case 3:
                    whether = whether_type.rainy;
                    break;
                case 4:
                    whether = whether_type.storm;
                    break;
                case 5:
                    whether = whether_type.ice_ball;
                    break;
            }

            if (whether == whether_type.sunny)
            {
                sunnyplus += 1;
                if(sunnyplus == 2)
                {
                    happyDay = true;
                    happyImg.SetActive(true);
                    sunnyplus = 0;
                }

            }
            else
            {
                happyDay = false;
               happyImg.SetActive(false);
                sunnyplus = 0;
            }
            
        }

        TiredSlider.value = curtired;
        if(curtired == 100)
        {
            gageColor.GetComponent<Image>().color = Color.red;
        }
        else if (curtired >= 50)
        {
            gageColor.GetComponent<Image>().color = new Color(236,134,0);
        }
        else
        {
            gageColor.GetComponent<Image>().color = Color.red;
        }
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            inGameTime += 0.2f;
            if (inGameTime >= 24)
            {
                inGameTime -= 24;
                PriceChange();

            }
            time.text = Mathf.FloorToInt(inGameTime / 1).ToString("D2") + ":" +"00";
        }
    }


    public void PriceChange()
    {
        bfCropPrice["wheat"] = curCropPrice["wheat"];
        bfCropPrice["corn"] = curCropPrice["corn"];
        bfCropPrice["carrot"] = curCropPrice["carrot"];
        bfCropPrice["blue_corn"] = curCropPrice["blue_corn"];
        bfCropPrice["red_wheat"] = curCropPrice["red_wheat"];

        curCropPrice["wheat"] = ftCropPrice["wheat"];
        curCropPrice["corn"] = ftCropPrice["corn"];
        curCropPrice["carrot"] = ftCropPrice["carrot"];
        curCropPrice["blue_corn"] = ftCropPrice["blue_corn"];
        curCropPrice["red_wheat"] = ftCropPrice["red_wheat"];

        ftCropPrice["wheat"] = Random.Range(2000, 4001);
        ftCropPrice["corn"] = Random.Range(6000, 12001);
        ftCropPrice["carrot"] = Random.Range(12000, 24000);

       
       
        ftCropPrice["blue_corn"] = Random.Range(16000, 32000);

        
       
        ftCropPrice["red_wheat"] = Random.Range(20000, 40000);
    }


    public void Error(string errorTxt)
    {
        StartCoroutine(Errortxt(errorTxt));
    }

    IEnumerator Errortxt(string errorTxt)
    {
        ErrorTxt.text = errorTxt;
        yield return new WaitForSeconds(1);
        ErrorTxt.text = string.Empty;
    }

    public void GarrageDisable()
    {
        GameManager.instance.garrageActive = false;
    }
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
        
    }
}
