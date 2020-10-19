using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public GameObject cherryPrefab;
    private bool instantiated = false;
    private Tween cherryTween;
    private float duration = 25f;
    GameObject cherry;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (instantiated == false)
        {
            cherry = Instantiate(cherryPrefab, new Vector3(-20.0f, -14.0f, 0.0f), Quaternion.Euler(0, 0, 0));
            
            instantiated = true;
        }
        if (instantiated == true)
        {
            if (cherry != null)
            {
                if (cherry.transform.position.x == -20 && cherry.transform.position.y == -14)
                {
                    cherryTween = new Tween(cherry.transform, cherry.transform.position, new Vector3(38f, -14f, 0f), Time.time, duration);
                }

                if (Vector3.Distance(cherryTween.Target.position, cherryTween.EndPos) > 0.1f)
                {
                    float timeFraction = (Time.time + 0.1f - cherryTween.StartTime) / cherryTween.Duration;
                    cherryTween.Target.position = Vector3.Lerp(cherryTween.StartPos, cherryTween.EndPos, timeFraction);
                }
                else
                {
                    cherryTween.Target.position = cherryTween.EndPos;
                    //cherryTween = null;
                    Destroy(cherry);
                    StartCoroutine(CherryRespawn());
                }
            }
        }
    }

    public IEnumerator CherryRespawn()
    {
        yield return new WaitForSecondsRealtime(30.0f);
        instantiated = false;
    }
}
