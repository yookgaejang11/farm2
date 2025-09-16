using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class Shop : MonoBehaviour
{
    public GameObject ShopPage; 
    public GameObject parcasePage;
    public GameObject sellPage;
   
    public bool isParchase;
    public garrage garrage;
    public Player player;
 
    public void Parchase(string name)
   {
        if(GameManager.Instance.AllCount() >= 50)
        {
            GameManager.Instance.Error("창고가 가득 찼습니다!!");
        }
        if (GameManager.Instance.SeedPrice[name] <= player.haveMoney)
        {
            player.haveMoney -= GameManager.Instance.SeedPrice[name];
            switch(GameManager.Instance.SeedPrice[name])
            {
                case 3000:
                    GameManager.Instance.wheat_seed += 1;
                    break;
                case 10000:
                    GameManager.Instance.corn_seed += 1;
                    break;
                case 16000:
                    GameManager.Instance.carrot_seed += 1;
                    break;
                case 28000:
                    GameManager.Instance.blue_corn_seed += 1;
                    break;
                case 30000:
                    GameManager.Instance.red_wheat_seed += 1;
                    break;
            }
            garrage.SortGarrage();
        }
        else
        {
            GameManager.Instance.Error("돈이 부족합니다!");
        }
        
    }

    public void Sell(string name) 
    {
        switch(name)
        {
            case "wheat":
                if(GameManager.Instance.wheat_seed > 0)
                {
                    GameManager.Instance.wheat_seed -= 1;
                    player.haveMoney += GameManager.Instance.curCropPrice[name];
                }
                else
                {
                    GameManager.Instance.Error("팔 수 있는 작물이 읎습니다!");
                }
                break;
        }

    }


    public void OpenShop()
    {
        ShopPage.SetActive(true);
        
    }

    public void CloseShop()
    {
        ShopPage.SetActive(false);
        sellPage.SetActive(false);
        parcasePage.SetActive(false);
        isParchase = false;
    }

    public void OpenParcasePage()
    {
        parcasePage.SetActive(true);
        sellPage.SetActive(false);
        isParchase = false;


    }

    public void OpenSellPage()
    {
        isParchase = true;
        parcasePage.SetActive(false);
        sellPage.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
