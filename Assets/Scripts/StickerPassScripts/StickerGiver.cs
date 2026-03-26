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
    void Start()
    {
        
    }

    //sets the stickers active, can be called from foreign objects. May add more stickers.
    public void GiveSticker(string sticker)
    {
        switch (sticker)
        {
            case "hallwaySticker":
                hallwaySticker.SetActive(true); break;

            case "cannulationSticker":
                cannulationSticker.SetActive(true); break;

            case "beforeMRISticker":
                beforeMRISticker.SetActive(true); break;

            case "afterMRISticker":
                afterMRISticker.SetActive(true); break;

            case "sortingGameSticker":
                sortingGameSticker.SetActive(true); break;

            case "QNASticker":
                QNASticker.SetActive(true); break;

            default:
                Debug.Log("Incorrect string in GiveSticker");
                break;
        }
    }
}
