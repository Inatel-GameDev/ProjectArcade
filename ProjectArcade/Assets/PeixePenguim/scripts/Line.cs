using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Line : MonoBehaviour
{

    [SerializeField] Transform iscaPos;
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] Image img;


    void Update()
    {
        float p =  (iscaPos.position.y - 5.5f) / 6.6f;
        float fill = 1 - p;

        img.fillAmount = fill;


        Debug.Log(fill);
        
    }
}
