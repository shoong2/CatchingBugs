using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class GameManager : MonoBehaviour
{
    
    public Text wave;
    public Text a;
    public Text HighRecode;
    public Text Recode;
    public Text coin_all;
    public int mokiCount = 0;
    public int bakiCount =0;
    public float playtime ; //총플레이시간
    float timer;  //시간지연시키기
    float waitingtime; //시간지연
    string realtime; //시간담아두기
    float remainTime; //다음웨이브까지 남은시간
    public GameObject spawner;
    public GameObject startImage;
    public GameObject inGame;
    public GameObject endGame;
    public GameObject New;
    public GameObject bakiSpawner;
    public GameObject tutorial;
    // public GameObject controlPanel;

    AudioSource newWave;
    joy gm;
    // Moki moki;
    
    public int score;
    int ClickCount = 0;
    
    bool re;
    
    public bool gamestart =false;
    

    public static GameManager instance;
    private void Awake() {
        instance = this;
        
    }
    

    public Data data = new Data();  //저장할 데이터 함수
    void Start()
    {
        string loadJson = File.ReadAllText(Application.persistentDataPath + "/Data.json"); //시작할때 데이터 로드
        data = JsonUtility.FromJson<Data>(loadJson); //로드한 데이터 data에 입력
        Debug.Log(Application.persistentDataPath);


        bool value = System.Convert.ToBoolean(PlayerPrefs.GetInt("Keyword"));
        if(value == false)
        { startImage.SetActive(true);
            Time.timeScale = 0;
        }
        else if(value == true)
        {
            startImage.SetActive(false);
            inGame.SetActive(true);
            Time.timeScale = 1;
            gamestart = true;
            re = false;
            PlayerPrefs.SetInt("Keyword", System.Convert.ToInt16(re));
        
        }


        timer = 0.0f;
        waitingtime =2f;

        score = 1;
        
        // Time.timeScale = 0;
        gm = GameObject.Find("ControlPanel").GetComponent<joy>();
        // moki = GameObject.Find("MobMoki@Idle").GetComponent<Moki>();

        remainTime = 20f;

        newWave = GetComponent<AudioSource>();
        StartCoroutine(timeSet(score));

        

    }

    IEnumerator timeSet(int Coscore)
    {
        if(playtime > 20 && playtime < 200)
        {
            spawner.transform.GetChild(Coscore).gameObject.SetActive(true);
        }

        if(Coscore ==3)
        {
            bakiSpawner.transform.GetChild(0).gameObject.SetActive(true);
        }
        if(Coscore ==4)
        {
            bakiSpawner.transform.GetChild(1).gameObject.SetActive(true);
        }
        wave.text ="Wave "+Coscore;
        
        
        yield return new WaitForSeconds(20f);
        score +=1;
        StartCoroutine(timeSet(score));
        
    }
    // Update is called once per frame
    void Update()
    {
        playtime += Time.deltaTime;
        remainTime -= Time.deltaTime;
        realtime = remainTime.ToString("00.00");
        realtime = realtime.Replace(".", ":");
        a.text ="NEXT WAVE : " + realtime;//Mathf.Round(time);

        if(remainTime < 0f)
        {
            remainTime = 20f;
            newWave.Play();
        }


        if(gm.over == true)
        {
            string jsonData = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/Data.json", jsonData); //데이터 저장 (함수로 만들기 필요)
            waitingtime = 0.5f;
        }

        if(gm.fallOver || gm.over == true)
        {
            string jsonData = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/Data.json", jsonData);
            print(Application.persistentDataPath);
            //print(data.coin);
            timer += Time.deltaTime;
            
            if(timer > waitingtime)
            {
                endGame.SetActive(true);
                
                float bestScore = PlayerPrefs.GetFloat("BestScore");

                if(score > bestScore)
                {
                    bestScore = score;
                    PlayerPrefs.SetFloat("BestScore", bestScore);
                    New.SetActive(true);
                }

                HighRecode.text = "BEST : WAVE " + (int)bestScore; 
                Recode.text = "NOW : WAVE " +(int)score;
                //coin_all.text = data.coin.ToString();
                //data.coin+= mokiCount + bakiCount*2;
                coin_all.text = "moki =" + mokiCount +"X1"+"\nbaki =" + bakiCount+"X2"+"\nCoin = "+data.coin.ToString();

                timer = 0;
                Time.timeScale = 0;
                
                

            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClickCount++;
            if (!IsInvoking("DoubleClick"))
                Invoke("DoubleClick", 1.0f);
       
        }
        else if (ClickCount == 2)
        {
            CancelInvoke("DoubleClick");
            Application.Quit();
        }
    }

    public void gStart()
    {
        
        Time.timeScale = 1;
        startImage.SetActive(false);
        inGame.SetActive(true);
        tutorial.SetActive(false);
        gamestart = true;
    
        return;
    }


    public void changeScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void restart()
    {
        re = true;
        PlayerPrefs.SetInt("Keyword", System.Convert.ToInt16(re));
        SceneManager.LoadScene("SampleScene");
        
        
    }

     void DoubleClick()
    {
        ClickCount = 0;
    }
    
    

}

[System.Serializable]
    public class Data
    {
        public int coin = 0;
    }
