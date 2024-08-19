using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Cadu : MonoBehaviour
{    
    [SerializeField] Camera camera;

    [SerializeField] Nadador peixe;

    [SerializeField] public bool comPeixe;

    [SerializeField] public int vidas;

    [SerializeField] GameManager gameManager;

    [SerializeField] public bool pausado;
    
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        if (!pausado)
        {
            float y = camera.ScreenToWorldPoint(Input.mousePosition).y;
            if (y >= 13f)
            {
                y = 13f;
                if (comPeixe)
                {
                    comPeixe = false;
                    Destroy(peixe.gameObject);
                    gameManager.Pesca();
                }
            }
            else if (y < 5.5f)
            {
                y = 5.5f;
            }

            transform.position = new Vector3(13.6f, y, 0);
        }
    }


    
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if(collision.tag == "peixe" && !comPeixe){            
            peixe = collision.gameObject.GetComponent<Nadador>();
            peixe.pescado = true;
            comPeixe = true;
        } else if (collision.tag == "lixo" || collision.tag == "cone"){
            vidas--;
            gameManager.PerdeVida(vidas);
            if (comPeixe)
            {
                comPeixe = false;
                Destroy(peixe.gameObject);
            }
            if (vidas == 0)
            {
                gameManager.Perdeu();
                Destroy(this.gameObject);
            }

        } else if(collision.tag == "final" &&comPeixe )
        {
            Destroy(peixe.gameObject);
            gameManager.GanhouShadow();
        }

    }

}
