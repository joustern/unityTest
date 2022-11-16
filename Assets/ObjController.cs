using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]//必須要有Rigidbody2D
public class ObjController : MonoBehaviour
{
    public static bool gStart = false;

    public GameObject canvasPrefab;
    public float speed = 0;
    public int life = 5;
    public TMP_Text lifeText;
    public TMP_Text scoreText;
    
    int score = 0;

    public Rigidbody2D r2d;

    //public GameObject bullet;
    GameObject bullet;
    float interval = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (!gStart)
        {
            Time.timeScale = 0;
        }
        
        r2d = this.GetComponent<Rigidbody2D>();
        /*Canvas[] CanvasPlayerGUIs = FindObjectsOfType<Canvas>();
        Canvas cv;
        foreach (Canvas CanvasPlayerGUI in CanvasPlayerGUIs)
        {
            if (CanvasPlayerGUI.name == "UI")
            {
                cv = CanvasPlayerGUI;
                print(cv.gameObject.GetComponentsInChildren<TMP_Text>()[0].text);
                break;
            }
        }*/
        TMP_Text[] tmArray = FindObjectsOfType<TMP_Text>();
        foreach (TMP_Text temp in tmArray)
        {
            if (temp.name == "Life")
            {
                lifeText = temp;
                lifeText.text = life.ToString();
            }
            if (temp.name == "Score")
            {
                scoreText = temp;
                this.GetScore(0);
            }
        }
        bullet=(GameObject)Resources.Load("shell");
        canvasPrefab= (GameObject)Resources.Load("EndCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (gStart)
        {
            //r2d.velocity = new Vector2(0, 0);
            if (Input.GetKey(KeyCode.D))
            {
                if (Time.timeScale == 1)
                {
                    if (gameObject.transform.position.x < 2.75)
                    {
                        gameObject.transform.position += new Vector3(speed, 0, 0);
                    }
                    print(gameObject.transform.position.x);
                    //r2d.AddForce(new Vector2(0.05f, 0), ForceMode2D.Impulse);
                    //r2d.velocity = new Vector2(speed,0);
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                if (Time.timeScale == 1)
                {
                    if (gameObject.transform.position.x > -2.75)
                    {
                        gameObject.transform.position -= new Vector3(speed, 0, 0);
                    }
                    print(gameObject.transform.position.x);
                    //r2d.AddForce(new Vector2(-0.05f, 0), ForceMode2D.Force);
                    //r2d.velocity = new Vector2(speed*(-1), 0);
                }
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if (Time.timeScale == 1)
                {
                    if (interval == 0)
                    {
                        Instantiate(bullet, this.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                        interval += Time.deltaTime;
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (Time.timeScale == 1)
                {
                    Time.timeScale = 0;
                }
                else Time.timeScale = 1;
            }
            if (interval > 0)
            {
                interval += Time.deltaTime;
                if (interval > 0.1)
                {
                    interval = 0;
                }

            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "target")
        {
            print("damage");
            life--;
            lifeText.text = life.ToString();
            if (life <= 0)
            {
                Time.timeScale = 0;
                Instantiate(canvasPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                TMP_Text[] tmArray = FindObjectsOfType<TMP_Text>();
                foreach (TMP_Text temp in tmArray)
                {
                    if (temp.name == "finalScore")
                    {
                        temp.text = "score : "+score;
                        break;
                    }
                }
                gStart = false;
                Destroy(this);
            }
        }
        else if (collision.gameObject.tag == "friend")
        {
            this.GetLife();
            Destroy(collision.gameObject);
        }
    }
    public void GetScore(int _score)
    {
        score += _score;
        scoreText.text = "Score:\n" + score;
        //print(_score);
    }
    public void GetLife()
    {
        life += 1;
        lifeText.text = life.ToString();
    }
}
