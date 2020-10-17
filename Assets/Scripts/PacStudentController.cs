using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    private float duration = 0.4f;
    private Tween activeTween;
    public AudioClip LickyGuyMove;
    public AudioClip LollyEaten;
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

    private KeyCode lastInput;
    private KeyCode currentInput;
    public Animator pacStudentAnim;
    public ParticleSystem dustEffect;
    private int score;
    

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
        var emission = dustEffect.emission;
        if (activeTween != null)
        {
            gameObject.GetComponent<AudioSource>().clip = LickyGuyMove;
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<AudioSource>().volume = 0.7f;
            pacStudentAnim.enabled = true;
            
            emission.enabled = true;
        }
        else if(activeTween == null)
        {
            pacStudentAnim.enabled = false;
            emission.enabled = false;
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
        RaycastCheck();
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.contacts[0].otherCollider.name);
        if (collision.contacts[0].otherCollider.tag == "NormalLolly")
        {
            Destroy(collision.contacts[0].otherCollider.gameObject);
            score += 10;
            UIManager.score = "Score: " + score;
        }
    }

    /*void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }*/

    void RaycastCheck()
    {
        RaycastHit hitInfo;
        Debug.DrawRay(gameObject.transform.position + new Vector3(0.0f, 0.0f, 0.0f), gameObject.transform.TransformDirection(Vector3.forward), Color.green);
        if (Physics.Raycast(gameObject.transform.position + new Vector3(0.0f, 0.0f, 0f), gameObject.transform.TransformDirection(Vector3.forward), out hitInfo, 3f))
        {
            Debug.Log("Raycast Hit: " + hitInfo.collider.gameObject.name);
            if (hitInfo.collider.gameObject == GameObject.FindGameObjectWithTag("Wall"))
            {
            }
        }



    }
    void Raycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward), 1.0f);
    }


}
