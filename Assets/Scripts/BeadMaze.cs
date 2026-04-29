using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeadMaze : MonoBehaviour
{
    // t‰h‰n linkitet‰‰n inspectorissa helmipujotteluradan valo
    public Light feedbackLight;

    // alussa valo on pois p‰‰lt‰
    void Start()
    {
        feedbackLight.enabled = false;
    }

    // jos radan joku box collidereista tˆrm‰‰ yhteen helmen box collidereista, kutsutaan t‰t‰ metodia
    void OnTriggerEnter(Collider other)
    {
        // jos valo on valmiiksi p‰‰ll‰, poistutaan metodista (t‰ll‰ estet‰‰n valon v‰lkkyminen)
        if (feedbackLight.enabled == true)
        {
            return;
        }

        // valo on nyt p‰‰ll‰
        feedbackLight.enabled = true;
        
        // helmen box collidereilla on tag "bead"
        if (other.gameObject.tag == "bead")
        {
            // kutsutaan LightOffWithDelay-korutiinia
            StartCoroutine(LightOffWithDelay(1f));

            // jotta valo ei v‰lkkyisi, lis‰t‰‰n viive loppuun (voi muuttaa)
            StartCoroutine(DelayBetweenLights(10f));
        }
    }

    IEnumerator LightOffWithDelay(float delay)
    {
        // valon v‰ri on nyt punainen
        feedbackLight.color = Color.red;
        Debug.Log("Collision");

        // annetun viiveen (1f, voi muuttaa) mittainen viive
        yield return new WaitForSeconds(delay);

        // valo on nyt pois p‰‰lt‰
        feedbackLight.enabled = false;
    }

    IEnumerator DelayBetweenLights(float delay)
    {
        // viive valojen v‰lill‰
        yield return new WaitForSeconds(delay);
    }
}
