using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BorderAnimator : MonoBehaviour
{
    private Sprite sourceImage;
    public Sprite border0;
    public Sprite border1;
    private bool isRunning = false;
    void Start()
    {
        //sourceImage = gameObject.GetComponent<Image>().sprite;
        
    }

    
    void Update()
    {
        if (isRunning == false)
        {
            StartCoroutine(AnimateBorder());
            isRunning = true;
        }

    }

    IEnumerator AnimateBorder()
    {
        
        yield return new WaitForSecondsRealtime(0.4f);
        if (gameObject.GetComponent<Image>().sprite == border0)
        {
            gameObject.GetComponent<Image>().sprite = border1;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = border0;
        }
        isRunning = false;

    }
}
