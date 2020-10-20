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
    public Animator Ghost2Anim;
    public Animator Ghost3Anim;
    public Animator Ghost4Anim;

    public ParticleSystem dustEffect;
    public ParticleSystem wallCollision;
    public ParticleSystem deathEffect;
    private ParticleSystem wallEffect;
    private ParticleSystem deathPlay;

    private int score;
    private CherryController cherryControl;

    private Transform rightTeleport;
    private Transform leftTeleport;
    public Transform startPos;

    public GameObject pacStudent;
    public UIManager gameUI;

    private bool ghost1Dead = false;
    private bool ghost2Dead = false;
    private bool ghost3Dead = false;
    private bool ghost4Dead = false;

    void Start()
    {
        cherryControl = GameObject.Find("MapLoader").GetComponent<CherryController>();
        rightTeleport = GameObject.Find("RightTeleport").GetComponent<Transform>();
        leftTeleport = GameObject.Find("LeftTeleport").GetComponent<Transform>();
        startPos = GameObject.Find("StartPos").GetComponent<Transform>();
        //gameUI = GameObject.Find("UIManager").GetComponent<UIManager>();
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
        AnimateGhosts();
        
    }

    void AnimateGhosts()
    {

        if (Mathf.Round(gameUI.ghostTimer) <= 3)
        {
            if (!Ghost1Anim.GetCurrentAnimatorStateInfo(0).IsName("GhostDead") && ghost1Dead == false)
            {
                Ghost1Anim.SetTrigger("Recovering");
                Ghost1Anim.ResetTrigger("Scared");
            }

            if (!Ghost2Anim.GetCurrentAnimatorStateInfo(0).IsName("GhostDead") && ghost2Dead == false)
            {
                Ghost2Anim.SetTrigger("Recovering");
                Ghost2Anim.ResetTrigger("Scared");
            }

            if (!Ghost3Anim.GetCurrentAnimatorStateInfo(0).IsName("GhostDead") && ghost3Dead == false)
            {
                Ghost3Anim.SetTrigger("Recovering");
                Ghost3Anim.ResetTrigger("Scared");
            }

            if (!Ghost4Anim.GetCurrentAnimatorStateInfo(0).IsName("GhostDead") && ghost4Dead == false)
            {
                Ghost4Anim.SetTrigger("Recovering");
                Ghost4Anim.ResetTrigger("Scared");
            }
        }
    
        if (Mathf.Round(gameUI.ghostTimer) == 0)
        {
            if (Ghost1Anim.GetCurrentAnimatorStateInfo(0).IsName("GhostDead") == false)
            {
                Ghost1Anim.SetTrigger("Normal");
                Ghost1Anim.ResetTrigger("Recovering");
            }
            if (!Ghost2Anim.GetCurrentAnimatorStateInfo(0).IsName("GhostDead"))
            {
                Ghost2Anim.SetTrigger("Normal");
                Ghost2Anim.ResetTrigger("Recovering");
            }
            if (!Ghost3Anim.GetCurrentAnimatorStateInfo(0).IsName("GhostDead"))
            {
                Ghost3Anim.SetTrigger("Normal");
                Ghost3Anim.ResetTrigger("Recovering");
            }
            if (!Ghost4Anim.GetCurrentAnimatorStateInfo(0).IsName("GhostDead"))
            {
                Ghost4Anim.SetTrigger("Normal");
                Ghost4Anim.ResetTrigger("Recovering");
            }
            gameUI.ghostTimer = 10f;
            if (ghost1Dead == false && ghost2Dead == false && ghost3Dead == false && ghost4Dead == false)
            {
                GameObject.FindGameObjectWithTag("MainAudio").GetComponent<AudioSource>().clip = GameObject.FindGameObjectWithTag("MainAudio").GetComponent<AudioController>().GhostNormal;
                GameObject.FindGameObjectWithTag("MainAudio").GetComponent<AudioSource>().Play();
            }
        }
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
        if (collision.contacts[0].otherCollider.tag == "Ghost")
        {
            
            StartCoroutine(GhostCollision(collision.contacts[0].otherCollider.gameObject));
        }
    }

    IEnumerator GhostCollision(GameObject ghost)
    {
        if (ghost.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("GhostAnimator"))
        {
            UIManager.lifeNumber--;
            lastInput = KeyCode.Space;
            activeTween = null;
            deathPlay = Instantiate(deathEffect, gameObject.transform);
            deathPlay.Play();
            yield return new WaitForSeconds(2.0f);
            gameObject.transform.position = startPos.position;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            Destroy(deathPlay);
        }
        if (ghost.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("GhostScared") ||
            ghost.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("GhostRecover"))
        {
            ghost.GetComponent<Animator>().SetTrigger("Dead");
            ghost.GetComponent<Animator>().ResetTrigger("Scared");
            ghost.GetComponent<Animator>().ResetTrigger("Recovering");
            if (ghost.name == "Ghost1")
            {
                ghost1Dead = true;
                Debug.Log(ghost1Dead);
            }
            if (ghost.name == "Ghost2")
            {
                ghost2Dead = true;
                Debug.Log(ghost2Dead);
            }
            if (ghost.name == "Ghost3")
            {
                ghost3Dead = true;
                Debug.Log(ghost3Dead);
            }
            if (ghost.name == "Ghost4")
            {
                ghost4Dead = true;
                Debug.Log(ghost4Dead);
            }
            score += 300;
            UIManager.score = "Score: " + score;
            GameObject.FindGameObjectWithTag("MainAudio").GetComponent<AudioSource>().clip = GameObject.FindGameObjectWithTag("MainAudio").GetComponent<AudioController>().GhostDead;
            GameObject.FindGameObjectWithTag("MainAudio").GetComponent<AudioSource>().Play();
            //set to the remainder of the ghost timer as otherwise when finished it goes back to scared/recovering state as timer hasnt finished
            yield return new WaitForSeconds(5.0f);
            if (ghost.name == "Ghost1")
            {
                ghost1Dead = false;
            }
            if (ghost.name == "Ghost2")
            {
                ghost2Dead = false;
            }
            if (ghost.name == "Ghost3")
            {
                ghost3Dead = false;
            }
            if (ghost.name == "Ghost4")
            {
                ghost4Dead = false;
            }
            if (ghost1Dead == false && ghost2Dead == false && ghost3Dead == false && ghost4Dead == false)
            {
                GameObject.FindGameObjectWithTag("MainAudio").GetComponent<AudioSource>().clip = GameObject.FindGameObjectWithTag("MainAudio").GetComponent<AudioController>().GhostNormal;
                GameObject.FindGameObjectWithTag("MainAudio").GetComponent<AudioSource>().Play();
            }
            ghost.GetComponent<Animator>().SetTrigger("Normal");

        }
    }

    IEnumerator playWallCollision()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(wallEffect);
    }

    void PowerPelletEaten()
    {
        Ghost1Anim.SetTrigger("Scared");
        Ghost2Anim.SetTrigger("Scared");
        Ghost3Anim.SetTrigger("Scared");
        Ghost4Anim.SetTrigger("Scared");
        Ghost1Anim.ResetTrigger("Normal");
        Ghost2Anim.ResetTrigger("Normal");
        Ghost3Anim.ResetTrigger("Normal");
        Ghost4Anim.ResetTrigger("Normal");
        GameObject.FindGameObjectWithTag("MainAudio").GetComponent<AudioSource>().clip = GameObject.FindGameObjectWithTag("MainAudio").GetComponent<AudioController>().GhostScared;
        GameObject.FindGameObjectWithTag("MainAudio").GetComponent<AudioSource>().Play();
        GameObject.Find("GhostTimerTxt").GetComponent<TextMeshProUGUI>().enabled = true;
        
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
