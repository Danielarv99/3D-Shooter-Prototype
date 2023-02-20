using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VidaJugador : MonoBehaviour
{
    PlayerController jugador;


    public int health = 5;
    public TextMeshProUGUI vidaJugador;
    public Image damageFlash;
    public Image healFlash;
    public AudioSource damageHit;
    public AudioSource healSound;

    void Start()
    {
        vidaJugador.text = "Hp: " + health + "/5";
    }

    void update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Bullet"))
        {
        health--;
        vidaJugador.text = "Hp: " + health + "/5";
        Destroy(other.gameObject);
        StartCoroutine("FlashDamage");
        damageHit.Play();

        } else if (other.gameObject.CompareTag("Life") && health < 5){
        health++;
        vidaJugador.text = "Hp: " + health + "/5";
        Destroy(other.gameObject);
        StartCoroutine("FlashHeal");
        healSound.Play();
        }
    }

    IEnumerator FlashDamage()
    {
        damageFlash.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        damageFlash.gameObject.SetActive(false);
    }

    IEnumerator FlashHeal()
    {
        healFlash.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        healFlash.gameObject.SetActive(false);
    }
}
