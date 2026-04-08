using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerController : MonoBehaviour
{

    public Animator stickerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        PlayAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayAnimation()
    {
        stickerAnimator.Play("stickerGot");
    }
}
