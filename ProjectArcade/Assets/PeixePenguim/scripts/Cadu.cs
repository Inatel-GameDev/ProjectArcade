using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Cadu : MonoBehaviour
{    
    [SerializeField] Camera camera;
    [SerializeField] Nadador peixe;
    [SerializeField] GameManager gameManager;
    [SerializeField] private Animator playerAnimator;


    [SerializeField] public bool comPeixe;
    [SerializeField] public bool pausado;
    [SerializeField] public int vidas;

    [SerializeField] public GameObject line;
    [SerializeField] Image img;


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
            if (y >= 12.1f)
            {
                y = 12.1f;
                if (comPeixe)
                {
                    Pausar(0.75f);
                    playerAnimator.Play("hook");
                    comPeixe = false;
                    Destroy(peixe.gameObject);
                    gameManager.Pesca();
                }
            }
            else if (y < 5.5f)
            {
                y = 5.5f;
            }

            transform.position = new Vector3(13.859f, y, 0);
        }
    }

    public void Despausar()
    {
        pausado = false;
    }

    public void Pausar(float time)
    {
        transform.position = new Vector3(13.859f, 12.1f, 0);
        pausado = true;
        img.fillAmount = 0;
        Invoke("Despausar", time);        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if(collision.tag == "peixe" && !comPeixe){            
            
            peixe = collision.gameObject.GetComponent<Nadador>();
            peixe.Rodar();
            comPeixe = true;

        } else if (collision.tag == "lixo" || collision.tag == "cone"){
            Pausar(0.375f);
            playerAnimator.Play("hit");
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
                Destroy(line);
                Destroy(this.gameObject);
            }

        } else if(collision.tag == "final" &&comPeixe ){

            Destroy(peixe.gameObject);
            gameManager.GanhouShadow();
        }

    }

}
