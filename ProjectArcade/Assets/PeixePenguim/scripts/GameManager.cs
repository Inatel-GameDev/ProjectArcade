using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject peixe;
    [SerializeField] GameObject lixo;
    [SerializeField] GameObject cone;

    [SerializeField] private float cdPeixe;
    [SerializeField] private float cdCone;
    [SerializeField] private float cdLixo;
    [SerializeField] private float maxY;
    [SerializeField] private float minY;
    [SerializeField] private float dirX;
    [SerializeField] private float esqX;


    [SerializeField] private float tempoUltimoPeixe;
    [SerializeField] private float tempoUltimoLixo;
    [SerializeField] private float tempoUltimoCone;

    [SerializeField] private int pontos;
    [SerializeField] private int pontosMax;
    [SerializeField] public TMP_Text textoPonto;
    [SerializeField] public TMP_Text textoVida;

    [SerializeField] public Button comecar;
    [SerializeField] public GameObject startMenu;
    [SerializeField] public GameObject endMenu;
    [SerializeField] public GameObject endMenuGood;
    [SerializeField] public GameObject endMenuMtGood;
    [SerializeField] public GameObject peixeFinal;
    [SerializeField] public GameObject shadow;
    [SerializeField] public Rigidbody2D shadowRB;

    [SerializeField] public Cadu cadu;
    [SerializeField] public bool acabou = false;

    public void Recomecar()
    {
        SceneManager.LoadScene("PeixePenguim");
    }

    public void Perdeu()
    {
        endMenu.SetActive(true);
        Time.timeScale = 0;
        cadu.pausado = true;
    }

    public void PeixeFinal(){
        peixeFinal.SetActive(true);
    }

    public void ParaSpwan()
    {
        acabou = true;
        cdCone = 200;
        cdPeixe = 200;
        cdLixo = 200;
        Invoke("PeixeFinal", 5f);
    }

    /*public void Shadow()
    {
        shadow.SetActive(true);
        shadowRB.transform.position += new Vector3(-2,+2,0);
        shadowRB.transform.rotation *= Quaternion.Euler(0, 0, 90f);
    }*/
    
    public void Ganhou()
    {
        endMenuGood.SetActive(true);
        Time.timeScale = 0;
        cadu.pausado = true;
    }

    public void GanhouShadow()
    {
        endMenuMtGood.SetActive(true);
        Time.timeScale = 0;
        cadu.pausado = true;
    }

    public void Comecar()
    {
        startMenu.SetActive(false);
        Time.timeScale = 1;
        tempoUltimoPeixe = Time.time;
        tempoUltimoCone = Time.time;
        tempoUltimoLixo = Time.time;
        cadu.pausado = false;
    }

    void Start()
    {
        Time.timeScale = 0;
        cadu.pausado = true;
    }

    void Update(){
        if (Time.time - tempoUltimoPeixe > cdPeixe)
        {
            tempoUltimoPeixe = Time.time;
            Spwan(peixe);
        }
        if (Time.time - tempoUltimoCone > cdCone)
        {
            tempoUltimoCone = Time.time;
            Spwan(cone);
        }
        if (Time.time - tempoUltimoLixo > cdLixo)
        {
            tempoUltimoLixo = Time.time;
            Spwan(lixo);
        }
        if(pontos == pontosMax)
        {
            if (!acabou)
            {
                ParaSpwan();
            }
        }
    }


    public void Pesca()
    {
        pontos++;
        textoPonto.text = pontos.ToString();
    }
    
    public void PerdeVida(int vida)
    {
        textoVida.text = vida.ToString();
    }

    public void Spwan(GameObject obj)
    {        
        float y = Random.Range(minY, maxY);
        float n = Random.Range(0, 2);      
        if (n >0.5)
        {            
            Instantiate(obj, new Vector3(dirX, y,0), Quaternion.identity);
            //obj.speedH = obj.speedH * -1;            
        }
        else
        {             
            Instantiate(obj, new Vector3(esqX, y, 0), Quaternion.identity);
        }
    }
}
