using OVR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SummonStickerPass : MonoBehaviour
{

    public InputActionReference buttonPressed;
    private GameObject mainCamera;
    public SoundFX sound;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        buttonPressed.action.Enable();
        buttonPressed.action.performed += SummonPass;
    }

    //transports the sticker pass to in front of you
    public void SummonPass(InputAction.CallbackContext context)
    {
        //todo: make the pass visible, as it turns invisible after switching scenes.
        gameObject.transform.position = mainCamera.transform.position;
    }

    public void PlaySound()
    {
        //do later: add sound to summoning the pass
    }
}
