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
    [SerializeField] public TMP_Text textoPonto;
    [SerializeField] public TMP_Text textoVida;

    [SerializeField] public Button comecar;    

    public void Recomecar()
    {
        SceneManager.LoadScene("PeixePenguim");
    }

    public void Comecar()
    {
        Time.timeScale = 1;
        tempoUltimoPeixe = Time.time;
        tempoUltimoCone = Time.time;
        tempoUltimoLixo = Time.time;
    }

    void Start()
    {
        Time.timeScale = 0;        
    }

    void Update()
    {
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
    }

    public void Pesca()
    {
        pontos++;
        textoPonto.text = "Pontos: " + pontos.ToString();
    }

    public void PerdeVida(int vida)
    {
        textoVida.text = "Monsters: " + vida.ToString();
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
