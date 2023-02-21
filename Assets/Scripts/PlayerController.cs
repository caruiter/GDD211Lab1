using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public Animator ani;
    public Animator eniani;

    public bool hiding;
    public bool gameover;
    public float speed;

    public GameObject theCamera;
    public GameObject enemyMover;

    public GameObject wintext;
    public GameObject losetext;

    private float ct;
    public int time;
    public int interval;
    public int totalsec;
    // Start is called before the first frame update


    void Start()
    {
        gameover = false;
        rb = GetComponent<Rigidbody>();
        ani.SetBool("hiding", false);
        ani.SetFloat("walkspeed", 0);
        interval = 100;

        wintext.SetActive(false);
        losetext.SetActive(false);

        time = 0;
        ct = 0;
    }

    // Update is called once per frame
    void Update()
    {

        ct += Time.deltaTime;
        if (ct >= 1)
        {
            ct = 0;
            totalsec++;
            time++;
        }


        if (time > interval)
        {
            ct = 0;
            interval = Random.Range(3, 9);
            time = 0;
            eniani.SetBool("active", true);
        }


        if (Input.GetKey(KeyCode.D) & gameover == false)
        {
            if(interval == 100)
            {
                interval = 3;
                time = 0;
            }
            //rb.velocity = new Vector3(speed, 0, 0);
            transform.position = new Vector2(transform.position.x + speed, 0);
            theCamera.transform.position = new Vector3(theCamera.transform.position.x + speed, theCamera.transform.position.y, theCamera.transform.position.z);
            enemyMover.transform.position = new Vector3(enemyMover.transform.position.x + speed, enemyMover.transform.position.y, enemyMover.transform.position.z);
            /**
            Vector3 newAngle = new Vector3 (0, 180, 0);
            Vector3 holdPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            transform.eulerAngles = newAngle;
            transform.position = holdPos;
            //transform.position.x += 3;
            **/
            ani.SetFloat("walkspeed", 1f);
        } /**else if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - speed, 0);
            Vector3 newAngle = new Vector3(0, 0, 0);
            Vector3 holdPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            transform.eulerAngles = newAngle;
            transform.position = holdPos;
            ani.SetFloat("walkspeed", 1f);
        }**/
        else
        {
            //rb.velocity = new Vector3(0, 0, 0);
            ani.SetFloat("walkspeed", 0f);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("HIDE");
            ani.SetBool("hiding", true);
        }
        
    }

    public void Emerge()
    {
        ani.SetBool("hiding", false);
    }

    public void OnTriggerEnter(Collider other)
    {
        aHit(other.gameObject);
    }


    public void OnCollisionEnter(Collision collision)
    {
        aHit(collision.gameObject);
    }

    public void aHit(GameObject other)
    {
        Debug.Log("hit");
        if (hiding == false && totalsec >=1)
        {
            if (other.gameObject.tag == "enemy")
            {
                losetext.SetActive(true);
                Time.timeScale = 0;
                gameover = true;
            }
            else if (other.gameObject.tag == "finish")
            {
                wintext.SetActive(true);
                Time.timeScale = 0;
                gameover = true;
            }
            Debug.Log("dead");
        }
    }


}
