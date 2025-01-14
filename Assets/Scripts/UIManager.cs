using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI tiempo;
    public TextMeshProUGUI puntuacion;
    public TextMeshProUGUI vida;
    public GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puntuacion.text = GameManager.instance.puntuacion.ToString();  
        vida.text = GameManager.instance.vidas.ToString();

        if (GameManager.instance.vidas > 0)
        {
            tiempo.text = Time.time.ToString("00.00");
        }
       
        if (GameManager.instance.vidas <= 0)
        {
            GameOver.SetActive(true);
        }
    }
}
