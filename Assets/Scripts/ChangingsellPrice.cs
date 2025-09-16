using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingsellPrice : MonoBehaviour
{
    Text text;
    public string cropname;
    public string txt;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text =txt + GameManager.Instance.curCropPrice[cropname].ToString();
    }
}
