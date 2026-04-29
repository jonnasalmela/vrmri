using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class QuestionManager2 : MonoBehaviour
{
    // T‰h‰n linkitet‰‰n inspectorissa kysymysteksti, paluuteksti, yes button, no button ja valo
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI returnText;
    [SerializeField] private GameObject yesButton;
    [SerializeField] private GameObject noButton;
    [SerializeField] private Light feedbackLight;

    // T‰h‰n linkitet‰‰n inspectorissa audio source ja kolme ‰‰niefekti‰
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip correctClip;
    [SerializeField] private AudioClip wrongClip;
    [SerializeField] private AudioClip fireworksClip;

    [Header("QuizData")]
    [TextArea]
    // kysymykset listana
    private string[] questions = {"Onnistuuko kuvaus, jos liikkuu?",
        "Pit‰‰kˆ silm‰lasit j‰tt‰‰ pois ennen kuvauksia?",
        "J‰‰d‰‰nkˆ huoneeseen yksin?",
        "Saako kuvauksen aikana liikuttaa p‰‰t‰?",
        "Pit‰‰kˆ avaimet j‰tt‰‰ pois ennen kuvauksia?",
        "Pit‰‰kˆ silmien olla kiinni?",
        "Saako puhelimen ottaa kuvauksiin mukaan?",
        "Saako hengitt‰‰ normaalisti?",
        "Saako hoitohenkilˆkuntaan yhteyden kuvauksen aikana?",
        "Tuleeko pime‰‰?" };
    // vastausten todenmukaisuus samassa j‰rjestyksess‰ kuin kysymykset
    private bool[] correctAnswers = { false, true, true, false, true, false, false, true, true, false };

    // t‰h‰n annetaan inspectorissa vastauksen viive, paluuaika ja scenen nimi, johon quizista siirryt‰‰n
    [Header("Settings")]
    [SerializeField] private float answerDelay = 1f;
    [SerializeField] private int countdownSeconds = 10;
    [SerializeField] private string returnSceneName = "Lobby";

    private int currentQuestionIndex = 0;
    private int score = 0;

    private void Start()
    {
        // piilotetaan paluuteksti alussa
        returnText.enabled = false;

        // sammutetaan valo alussa
        feedbackLight.enabled = false;

        // jos kysymysten m‰‰r‰ on eri kuin vastausten m‰‰r‰, annetaan virheilmoitus
        if (questions.Length != correctAnswers.Length)
        {
            Debug.LogError("Questions and CorrectAnswers arrays must be same length!");
            return;
        }

        // kutsutaan DisplayQuestion()-metodia
        DisplayQuestion();
    }

    // t‰h‰n linkitet‰‰n inspectorissa fireworksManager-scriptit
    public FireworksManager fireworksManager1;
    public FireworksManager fireworksManager2;
    public FireworksManager fireworksManager3;

    private void DisplayQuestion()
    {
        // jos kysymyksi‰ on j‰ljell‰, kysymys valitaan listasta ja yes/no-buttonit aktivoidaan
        if (currentQuestionIndex < questions.Length)
        {
            questionText.text = questions[currentQuestionIndex];
            yesButton.SetActive(true);
            noButton.SetActive(true);
        }
        // jos kysymyksi‰ ei ole j‰ljell‰, kustutaan EndQuiz()-metodia
        else
        {
            EndQuiz();
        }
    }

    // AnswerYes() ja AnswerNo()-metodeihin viitataan buttonien inspectoreissa
    public void AnswerYes()
    {
        HandleAnswer(true);
    }

    public void AnswerNo()
    {
        HandleAnswer(false);
    }

    private void HandleAnswer(bool playerAnswer)
    {
        // jos kysymyksen indeksi on suurempi kuin oikeiden vastausten indeksien m‰‰r‰, poistutaan metodista
        if (currentQuestionIndex >= correctAnswers.Length)
        {
            return;
        }

        // isCorrect toteutuu, jos pelaajan vastaus on true samaan aikaan kun kysymys on true. (sama myˆs false tapauksessa)
        bool isCorrect = correctAnswers[currentQuestionIndex] == playerAnswer;

        // jos vastaus on oikein, score kasvaa yhdell‰, soitetaan ‰‰niefekti, piilotetaan buttonit ja sytytet‰‰n vihre‰ valo
        if (isCorrect)
        {
            Debug.Log("isCorrect");
            score++;
            audioSource.PlayOneShot(correctClip);
            yesButton.SetActive(false);
            noButton.SetActive(false);
            StartCoroutine(LightOffWithDelayGreen(1f));
        }
        // jos vastaus on v‰‰rin, soitetaan ‰‰niefekti, piilotetaan buttonit ja sytytet‰‰n punainen valo
        else
        {
            Debug.Log("isWrong");
            audioSource.PlayOneShot(wrongClip);
            yesButton.SetActive(false);
            noButton.SetActive(false);
            StartCoroutine(LightOffWithDelayRed(1f));
        }

        // kutsutaan NextQuestionAfterDelay()-korutiinia
        StartCoroutine(NextQuestionAfterDelay());
    }

    private IEnumerator NextQuestionAfterDelay()
    {
        // viive kysymysten vaihtumiselle
        yield return new WaitForSeconds(answerDelay);
        // siirryt‰‰n seuraavaan kysymykseen kasvattamalla indeksi‰
        currentQuestionIndex++;
        // kutsutaan DisplayQuestion()-metodia
        DisplayQuestion();
    }

    private void EndQuiz()
    {
        // piilotetaan yes- ja no-buttonit
        yesButton.SetActive(false);
        noButton.SetActive(false);

        /* jos saatu score (pistem‰‰r‰) on 6 tai enemm‰n (voi myˆs vaihtaa jos haluaa lis‰‰ haastetta), 
        kutsutaan PlayFireworksWithDelay()-korutiinia*/
        if (score > 5)
        {
            StartCoroutine(PlayFireworksWithDelay());
        }

        // tulostetaan pistem‰‰r‰ pelaajalle ja aktivoidaan paluuteksti
        questionText.text = $"Vastasit {score}/{questions.Length} oikein!";
        returnText.enabled = true;

        // kutsutaan ReturnCountdown()-korutiinia
        StartCoroutine(ReturnCountdown());
    }

    private IEnumerator PlayFireworksWithDelay()
    {
        // soitetaan yksitt‰inen ilotulitus ‰‰niefekti
        audioSource.PlayOneShot(fireworksClip);

        // ensimm‰inen ilotulitusefekti ja viive, jota voi muuttaa
        fireworksManager1.PlayFireworks();
        yield return new WaitForSeconds(0.5f);

        // toinen efekti ja viive, jota voi muuttaa
        fireworksManager2.PlayFireworks();
        yield return new WaitForSeconds(0.5f);

        // kolmas efekti
        fireworksManager3.PlayFireworks();
    }

    private IEnumerator ReturnCountdown()
    {
        int timer = countdownSeconds;

        // kun inspectorissa annettu paluuaika on enemm‰n kuin 0, annetaan paluutekstiksi seuraava lause ja viive
        while (timer > 0)
        {
            returnText.text = $"Palataan huoneeseen {timer} sekunnin kuluttua...";
            yield return new WaitForSeconds(1f);
            timer--;
        }

        GameObject.FindGameObjectWithTag("passReference").GetComponent<ReferencePass>().GetPass().SetActive(true);
        //SceneManager.LoadScene(returnSceneName);
    }

    IEnumerator LightOffWithDelayGreen(float delay)
    {
        // sytytet‰‰n valo
        feedbackLight.enabled = true;

        // valon v‰ri on nyt vihre‰
        feedbackLight.color = Color.green;

        // annetun viiveen mittainen viive (viivett‰ voi muuttaa)
        yield return new WaitForSeconds(delay);

        // sammutetaan valo
        feedbackLight.enabled = false;
    }

    IEnumerator LightOffWithDelayRed(float delay)
    {
        feedbackLight.enabled = true;

        // ainoastaan t‰m‰ kohta on eri (vihre‰n sijasta punainen v‰riksi)
        feedbackLight.color = Color.red;

        yield return new WaitForSeconds(delay);

        feedbackLight.enabled = false;
    }
}