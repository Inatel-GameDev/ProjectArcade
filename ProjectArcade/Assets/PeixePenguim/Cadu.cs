using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Cadu : MonoBehaviour
{
    [SerializeField] private GameObject isca;
    [SerializeField] Camera camera;
    
    void Start()
    {
        
    }

    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        float y = camera.ScreenToWorldPoint(Input.mousePosition).y;
        Debug.Log(y);
        if (y > 13f)
        {
            y = 13f;
        }else if (y < 5.5f)
        {
            y = 5.5f;
        }

        isca.transform.position = new Vector3(13.6f, y, 0);
        
    }
}
