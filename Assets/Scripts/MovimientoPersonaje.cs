using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovimientoPersonaje : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    CircleCollider2D colider;
    SpriteRenderer sprite;
    public float speed = 10;
    public float rotationspeed = 10;
    public GameObject ParticulasMuerte;
    public GameObject[] myCannons;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        colider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento de la nave en vertical

        float vertical = Input.GetAxis("Vertical");
        
        if (vertical > 0)
        {

            rb.AddForce(transform.up * vertical * speed * Time.deltaTime);
            anim.SetBool("Impulsing", true);
        }
        else
        {
            anim.SetBool("Impulsing", false);
        }

            float horizontal = Input.GetAxis("Horizontal");

            transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, horizontal) * rotationspeed * Time.deltaTime;

    }

    public void Muerte()
    {
        GameObject temp = Instantiate(ParticulasMuerte, transform.position, transform.rotation);
        Destroy(temp, 2);

        StartCoroutine(Respawn_Courtine());

    }

    IEnumerator Respawn_Courtine()
    {
        colider.enabled = false;
        sprite.enabled = false;
        yield return new WaitForSeconds(2);
        colider.enabled = true;
        sprite.enabled = true;

        GameManager.instance.vidas -= 1;
        transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector2(0, 0);

        if (GameManager.instance.vidas <= 0)
        {
            Destroy(gameObject);
        }   
    }

    public void ChangeCannon(int theCannon)
    {
        //Desactivar todos los cañones
        foreach(GameObject currentCannon in myCannons)
        {
            currentCannon.SetActive(false);
        }

        //Activar el cañon que queremos

        myCannons[theCannon].SetActive(true);
        StartCoroutine(RutinaTemporizadorPowerUp());
    }

    IEnumerator RutinaTemporizadorPowerUp()
    {

        if (myCannons[3] == true)
        {
            yield return new WaitForSeconds(4);
            myCannons[3].SetActive(false);
            myCannons[0].SetActive(true);
        }

        if (myCannons[1] == true)
        {
            yield return new WaitForSeconds(10);
            myCannons[1].SetActive(false);
        }
    }



}
