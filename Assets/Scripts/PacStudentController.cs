using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    private float duration = 0.4f;
    private Tween activeTween;
    public AudioClip LickyGuyMove;
    int[,] levelMap = { { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 7, 7, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
                        { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 2 },
                        { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 4, 3, 5, 3, 4, 4, 3, 5, 2 },
                        { 2, 6, 4, 0, 0, 4, 5, 4, 0, 0, 0, 4, 5, 4, 4, 5, 4, 0, 0, 0, 4, 5, 4, 0, 0, 4, 6, 2 },
                        { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 4, 3, 5, 3, 4, 4, 3, 5, 2 },
                        { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 2 },
                        { 2, 5, 3, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 4, 4, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 3, 5, 2 },
                        { 2, 5, 3, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 3, 3, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 3, 5, 2 },
                        { 2, 5, 5, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 5, 5, 2 },
                        { 1, 2, 2, 2, 2, 1, 5, 4, 3, 4, 4, 3, 0, 4, 4, 0, 3, 4, 4, 3, 4, 5, 1, 2, 2, 2, 2, 1 },
                        { 0, 0, 0, 0, 0, 2, 5, 4, 3, 4, 4, 3, 0, 3, 3, 0, 4, 4, 4, 3, 4, 5, 2, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 5, 2, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 3, 4, 4, 0, 0, 4, 4, 3, 0, 4, 4, 5, 2, 0, 0, 0, 0, 0 },
                        { 2, 2, 2, 2, 2, 1, 5, 3, 3, 0, 4, 0, 0, 0, 0, 0, 0, 4, 0, 3, 3, 5, 1, 2, 2, 2, 2, 2 },
                        { 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0 },
                        { 2, 2, 2, 2, 2, 1, 5, 3, 3, 0, 4, 0, 0, 0, 0, 0, 0, 4, 0, 3, 3, 5, 1, 2, 2, 2, 2, 2 },
                        { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 3, 4, 4, 0, 0, 4, 4, 3, 0, 4, 4, 5, 2, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 5, 2, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 2, 5, 4, 3, 4, 4, 3, 0, 3, 3, 0, 4, 4, 4, 3, 4, 5, 2, 0, 0, 0, 0, 0 },
                        { 1, 2, 2, 2, 2, 1, 5, 4, 3, 4, 4, 3, 0, 4, 4, 0, 3, 4, 4, 3, 4, 5, 1, 2, 2, 2, 2, 1 },
                        { 2, 5, 5, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 5, 5, 2 },
                        { 2, 5, 3, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 3, 3, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 3, 5, 2 },
                        { 2, 5, 3, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 4, 4, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 3, 5, 2 },
                        { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 2 },
                        { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 4, 3, 5, 3, 4, 4, 3, 5, 2 },
                        { 2, 6, 4, 0, 0, 4, 5, 4, 0, 0, 0, 4, 5, 4, 4, 5, 4, 0, 0, 0, 4, 5, 4, 0, 0, 4, 6, 2 },
                        { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 4, 3, 5, 3, 4, 4, 3, 5, 2 },
                        { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 2 },
                        { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 7, 7, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1 }, };

    private bool movable = false;
    private KeyCode lastInput;
    private KeyCode currentInput;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            lastInput = KeyCode.A;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            lastInput = KeyCode.D;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            lastInput = KeyCode.S;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            lastInput = KeyCode.W;
        }

        if (activeTween != null)
        {
            gameObject.GetComponent<AudioSource>().clip = LickyGuyMove;
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<AudioSource>().volume = 0.7f;
        }
        
        if (lastInput == KeyCode.A)
        {
            if(levelMap[Mathf.Abs((int)gameObject.transform.position.y), (int)gameObject.transform.position.x - 1] == 5 ||
               levelMap[Mathf.Abs((int)gameObject.transform.position.y), (int)gameObject.transform.position.x - 1] == 6 ||
               levelMap[Mathf.Abs((int)gameObject.transform.position.y), (int)gameObject.transform.position.x - 1] == 0)
            {
                if (activeTween == null)
                {
                    activeTween = new Tween(gameObject.transform, gameObject.transform.position, new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y, 0.0f), Time.time, duration);
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 270);
                    currentInput = KeyCode.A;
                }
            }
            else
            {
                lastInput = currentInput;
            }
        }

        if (lastInput == KeyCode.D)
        {
            if (levelMap[Mathf.Abs((int)gameObject.transform.position.y), (int)gameObject.transform.position.x + 1] == 5 ||
                levelMap[Mathf.Abs((int)gameObject.transform.position.y), (int)gameObject.transform.position.x + 1] == 6 ||
                levelMap[Mathf.Abs((int)gameObject.transform.position.y), (int)gameObject.transform.position.x + 1] == 0)
            {
                
                if (activeTween == null)
                {
                    activeTween = new Tween(gameObject.transform, gameObject.transform.position, new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, 0.0f), Time.time, duration);
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                    currentInput = KeyCode.D;
                }
            }
            else
            {
                lastInput = currentInput;
            }
        }

        if (lastInput == KeyCode.S)
        {
            if (levelMap[Mathf.Abs((int)gameObject.transform.position.y - 1), (int)gameObject.transform.position.x] == 5 ||
                levelMap[Mathf.Abs((int)gameObject.transform.position.y - 1), (int)gameObject.transform.position.x] == 6 ||
                levelMap[Mathf.Abs((int)gameObject.transform.position.y - 1), (int)gameObject.transform.position.x] == 0)
            {

                if (activeTween == null)
                {
                    activeTween = new Tween(gameObject.transform, gameObject.transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1, 0.0f), Time.time, duration);
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    currentInput = KeyCode.S;
                }
            }
            else
            {
                lastInput = currentInput;
            }
        }

        if (lastInput == KeyCode.W)
        {
            if (levelMap[Mathf.Abs((int)gameObject.transform.position.y + 1), (int)gameObject.transform.position.x] == 5 ||
                levelMap[Mathf.Abs((int)gameObject.transform.position.y + 1), (int)gameObject.transform.position.x] == 6 ||
                levelMap[Mathf.Abs((int)gameObject.transform.position.y + 1), (int)gameObject.transform.position.x] == 0)
            {

                if (activeTween == null)
                {
                    activeTween = new Tween(gameObject.transform, gameObject.transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, 0.0f), Time.time, duration);
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                    currentInput = KeyCode.W;
                }
            }
            else
            {
                lastInput = currentInput;
            }
        }
        /*if(gameObject.transform.position.x == 1 && gameObject.transform.position.y == -1)
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
        }*/
        if (activeTween != null)
        {
            
            if (Vector3.Distance(activeTween.Target.position, activeTween.EndPos) > 0.1f)
            {
                float timeFraction = (Time.time - activeTween.StartTime) / activeTween.Duration;
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
        
        
    }

    
}
