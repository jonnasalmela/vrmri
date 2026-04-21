using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerGiver : MonoBehaviour
{
    //list of stickers
    [SerializeField] GameObject hallwaySticker;
    [SerializeField] GameObject cannulationSticker;
    [SerializeField] GameObject beforeMRISticker;
    [SerializeField] GameObject afterMRISticker;
    [SerializeField] GameObject sortingGameSticker;
    [SerializeField] GameObject QNASticker;
    [SerializeField] GameObject quizSticker;
    void Start()
    {
        
    }

    //sets the stickers active, can be called from foreign objects. May add more stickers.
    public void GiveSticker(string sticker)
    {
        switch (sticker)
        {
            case "HallwaySticker":
                hallwaySticker.SetActive(true); break;

            case "CannulationSticker":
                cannulationSticker.SetActive(true); break;

            case "BeforeMRISticker":
                beforeMRISticker.SetActive(true); break;

            case "AfterMRISticker":
                afterMRISticker.SetActive(true); break;

            case "SortingGameSticker":
                sortingGameSticker.SetActive(true); break;

            case "QNASticker":
                QNASticker.SetActive(true); break;

            case "QuizSticker":
                quizSticker.SetActive(true); break;


            default:
                Debug.Log("Incorrect string in GiveSticker");
                break;
        }
    }
}
