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
    public AudioClip collideWall;
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
    public Animator Ghost1Anim;
    public ParticleSystem dustEffect;
    public ParticleSystem wallCollision;
    private ParticleSystem wallEffect;
    private int score;
    private CherryController cherryControl;
    private Transform rightTeleport;
    private Transform leftTeleport;
    public GameObject pacStudent;
    

    void Start()
    {
        cherryControl = GameObject.Find("MapLoader").GetComponent<CherryController>();
        rightTeleport = GameObject.Find("RightTeleport").GetComponent<Transform>();
        leftTeleport = GameObject.Find("LeftTeleport").GetComponent<Transform>();
    }
    void Update()
    {

        if (gameObject.transform.position.x >= 27 && gameObject.transform.position.y == -14)
        {
            gameObject.transform.position = leftTeleport.position;
        }

        if (gameObject.transform.position.x <= 1 && gameObject.transform.position.y == -14)
        {
            gameObject.transform.position = rightTeleport.position;
        }




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
        //RaycastCheck();
        
    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].otherCollider.tag == "NormalLolly")
        {
            Destroy(collision.contacts[0].otherCollider.gameObject);
            score += 10;
            UIManager.score = "Score: " + score;
        }
        if (collision.contacts[0].otherCollider.tag == "Wall")
        {
            wallEffect = Instantiate(wallCollision, collision.contacts[0].otherCollider.transform);
            wallEffect.Play();
            gameObject.GetComponent<AudioSource>().clip = collideWall;
            StartCoroutine(playWallCollision());
            
        }
        if (collision.contacts[0].otherCollider.tag == "Bonus")
        {
            Destroy(collision.contacts[0].otherCollider.gameObject);
            StartCoroutine(cherryControl.CherryRespawn());
            score += 100;
            UIManager.score = "Score: " + score;
        }
        if (collision.contacts[0].otherCollider.tag == "Power")
        {
            Destroy(collision.contacts[0].otherCollider.gameObject);
            PowerPelletEaten();
        }
    }

    IEnumerator playWallCollision()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(wallEffect);
    }

    void PowerPelletEaten()
    {
        //Ghost1Anim.SetTrigger("Scared");
    }
    /*void RaycastCheck()
    {
        RaycastHit hitInfo;
        Debug.DrawRay(gameObject.transform.position + new Vector3(0.0f, 0.0f, 0.0f), gameObject.transform.TransformDirection(Vector3.forward), Color.green);
        if (Physics.Raycast(gameObject.transform.position + new Vector3(0.0f, 0.0f, 0f), gameObject.transform.TransformDirection(Vector3.down), out hitInfo, 1f))
        {
            Debug.Log("Raycast Hit: " + hitInfo.collider.gameObject.name);
            if (hitInfo.collider.gameObject == GameObject.FindGameObjectWithTag("Wall"))
            {
                OnCollisionEnter(hitInfo.);
            }
        }



    }*/



}
