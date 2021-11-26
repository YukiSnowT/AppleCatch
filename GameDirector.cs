using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    GameObject restartButton;
    GameObject generator;
    float time = 30.0f;
    int point = 0;

    public void GetApple(){
        this.point += 100;
    }
    public void GetBomb(){
        this.point /= 2;
    }

    public void GameRestart(){
        SceneManager.LoadScene("GameScene");
    }
    

    // Start is called before the first frame update
    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
        this.restartButton = GameObject.Find("RestartButton");
        this.generator = GameObject.Find("ItemGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        this.time -= Time.deltaTime;

        if(this.time < 0){
            this.time = 0;
            this.generator.GetComponent<ItemGenerator>().SetParameter(10000.0f,0,0);
            Vector3 temp = this.restartButton.transform.position;
            temp.x = 300;
            this.restartButton.transform.position = temp;
        }else if(0 <= this.time && this.time < 5){
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.5f,-0.09f,3);
        }else if(5 <= this.time && this.time < 12){
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.5f,-0.08f,6);
        }else if(12 <= this.time && this.time < 19){
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.7f,-0.06f,4);
        }else if(19 <= this.time && this.time < 25){
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.7f,-0.05f,3);
        }else if(25 <= this.time && this.time < 30){
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.8f,-0.04f,2);
        }
        this.timerText.GetComponent<Text>().text = this.time.ToString("F1");
        this.pointText.GetComponent<Text>().text = this.point.ToString() + " point";
    }
}
