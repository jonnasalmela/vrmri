using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CorrectBasket : MonoBehaviour
{

    public TextMeshProUGUI text;
    public GameObject basket;
    public Light feedbackLight;
    public AudioSource correctAudioSource;
    public AudioSource incorrectAudioSource;

    void Start()
    {
        feedbackLight.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        feedbackLight.enabled = true;

        if (other.gameObject.tag == "iPhone")
        {
            feedbackLight.color = Color.red;
            incorrectAudioSource.Play();
            text.text = "Väärin! Puhelinta ei saa ottaa mukaan magneettikuvaushuoneeseen. Elektroniikka ja metalli häiritsevät kuvauksen onnistumista, sekä puhelimen tärkeät komponentit voivat vaurioitua magneetin vuoksi.";
        }
        if (other.gameObject.tag == "Book")
        {
            feedbackLight.color = Color.green;
            correctAudioSource.Play();
            text.text = "Oikein! Kirjan voi ottaa mukaan. Siinä ei ole metallia, eikä mitään, mikä häiritsisi magneettikuvausta.";
        }
        if (other.gameObject.tag == "Bracelet")
        {
            feedbackLight.color = Color.red;
            incorrectAudioSource.Play();
            text.text = "Väärin! Rannekorua ei saa ottaa mukaan magneettikuvaushuoneeseen. Koru voi sisältää metallia, joka häiritsee kuvauksen onnistumista.";
        }
        if (other.gameObject.tag == "Key")
        {
            feedbackLight.color = Color.red;
            incorrectAudioSource.Play();
            text.text = "Väärin! Avain on metallia, joten sitä ei saa ottaa mukaan magneettikuvaushuoneeseen. Metalliesineet voivat häniritä kuvauksen onnistumista.";
        }
        if (other.gameObject.tag == "Plushy")
        {
            feedbackLight.color = Color.green;
            correctAudioSource.Play();
            text.text = "Oikein! Pehmolelun saat ottaa mukaan, jos se ei sisällä metallia. Pehmolelut ovat turvallisia ja voivat auttaa sinua tuntemaan olosi mukavaksi.";
        }
        if (other.gameObject.tag == "Glasses")
        {
            feedbackLight.color = Color.red;
            incorrectAudioSource.Play();
            text.text = "Väärin! Silmälaseja, joissa on metallia, ei saa ottaa mukaan magneettikuvaushuoneeseen. Metalliset osat voivat häiritä kuvauksen onnistumista.";
        }
        if (other.gameObject.tag == "Horse")
        {
            feedbackLight.color = Color.green;
            correctAudioSource.Play();
            text.text = "Oikein! Puiset tai muoviset lelut, kuten tämä leluhevonen, ovat turvallisia ottaa mukaan magneettikuvaushuoneeseen.";
        }
        if (other.gameObject.tag == "Watch")
        {
            feedbackLight.color = Color.red;
            incorrectAudioSource.Play();
            text.text = "Väärin! Rannekelloa ei saa ottaa mukaan magneettikuvaushuoneeseen. Kellon metalliosat ja elektroniset komponentit voivat häiritä kuvauksen onnistumista.";
        }
    }
}
