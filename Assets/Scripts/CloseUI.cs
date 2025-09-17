using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUI : MonoBehaviour
{
   public GameObject GameObject;

    public void CloseUi(GameObject obj)
    {
        obj.SetActive(false);
    }
}
