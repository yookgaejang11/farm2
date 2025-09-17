using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public GameObject tvObj;
    public GameObject tvUI;

    public Text insideTxt;
    public bool isInHouse;
    public Text hometxt;
    public Text homeouttxt;
    public Transform OutHouse;
    public Transform inHouse;
    public Transform house;
    public float garrageDis = 5;
    public float homeDis = 10;
    public Transform garrage;
    public float speed;
    public float haveMoney = 3000;
    public GetWater water;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(this.transform.position, tvObj.transform.position) < 2)
        {
            insideTxt.text = "뉴스 확인[T]";
            if(Input.GetKeyDown(KeyCode.T))
            {
                tvUI.SetActive(true);
            }
        }

        if(Vector2.Distance(transform.position, OutHouse.position) < homeDis)
        {
            GameManager.Instance.garrageTxt.SetActive(true);
            hometxt.text = "집 입장[H]";

            if(Input.GetKeyDown(KeyCode.H) && !isInHouse)
            {
                isInHouse = true;
                transform.position = inHouse.position;
                hometxt.text= string.Empty;
                
            }
        }
        else
        {
            hometxt.text = string.Empty;
        }


        if(Vector2.Distance(this.transform.position, garrage.position) < garrageDis)
        {
            GameManager.Instance.garrageTxt.GetComponent<Text>().text = "창고 열기[Z]";
            GameManager.Instance.garrageTxt.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Z))
            {
                if(GameManager.Instance.garrageActive)
                {
                    GameManager.Instance.GarrageUI.gameObject.SetActive(false);
                }
                else
                {
                    GameManager.Instance.GarrageUI.gameObject.SetActive(true);
                }
                
            }
        }
        else
        {
            GameManager.Instance.garrageTxt.GetComponent<Text>().text = string.Empty;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Well"))
        {
            water.CanGetWater = true;
        }

        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("a");
        if (collision.gameObject.CompareTag("outSide"))
        {
            homeouttxt.text = "밖으로 나가기[X]";
            if (Input.GetKeyDown(KeyCode.X) && isInHouse)
            {
                isInHouse = false;
                Debug.Log(OutHouse.transform.position);
                transform.position = OutHouse.transform.position;
            }
        }
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Well"))
        {
            water.CanGetWater = false;
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("outSide"))
        {
            homeouttxt.text = string.Empty;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Debug.Log(Time.deltaTime);
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(moveX, moveY);

        transform.Translate(dir * speed * Time.deltaTime);
    }
}
