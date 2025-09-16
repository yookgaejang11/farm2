using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bfCropPricetxt : MonoBehaviour
{
    Text text;
    public string type;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GameManager.Instance.bfCropPrice[type].ToString();
    }
}
