using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private float duration = 1.0f;
    private Tween activeTween;
    public AudioClip LickyGuyMove;
    void Start()
    {
        LickyGuyMove = Resources.Load<AudioClip>("Audio/LickyGuyMove");
        //StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {
        if(activeTween != null)
        {
            gameObject.GetComponent<AudioSource>().clip = LickyGuyMove;
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<AudioSource>().volume = 0.7f;
        }
        if(gameObject.transform.position.x == 1 && gameObject.transform.position.y == -1)
        {
            activeTween = new Tween(gameObject.transform, gameObject.transform.position, new Vector3(6.0f, -1.0f, 0.0f), Time.time, duration);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (gameObject.transform.position.x == 6 && gameObject.transform.position.y == -1)
        {
            activeTween = new Tween(gameObject.transform, gameObject.transform.position, new Vector3(6.0f, -5.0f, 0.0f), Time.time, duration);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (gameObject.transform.position.x == 6 && gameObject.transform.position.y == -5)
        {
            activeTween = new Tween(gameObject.transform, gameObject.transform.position, new Vector3(1.0f, -5.0f, 0.0f), Time.time, duration);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        if (gameObject.transform.position.x == 1 && gameObject.transform.position.y == -5)
        {
            activeTween = new Tween(gameObject.transform, gameObject.transform.position, new Vector3(1.0f, -1.0f, 0.0f), Time.time, duration);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        if (Vector3.Distance(activeTween.Target.position, activeTween.EndPos) > 0.1f)
        {
            float timeFraction = (Time.time + 0.0000001f - activeTween.StartTime) / activeTween.Duration;
            activeTween.Target.position = Vector3.Lerp(activeTween.StartPos,
                                                      activeTween.EndPos,
                                                       timeFraction);
        }
        else
        {
            activeTween.Target.position = activeTween.EndPos;
            activeTween = null;
        }
    }

    /*private IEnumerator Delay()
    {
        Time.timeScale = 0;
        while (Time.realtimeSinceStartup < 6.0f)
        {
            yield return 0;
        }
        Time.timeScale = 1;
    }*/
}
