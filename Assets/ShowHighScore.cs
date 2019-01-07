using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHighScore : MonoBehaviour {

    public Text _highScore;
    bool isShow = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.H))
        {

            if(isShow){
                _highScore.gameObject.SetActive(false);
                isShow = false;  
            }else{
                _highScore.gameObject.SetActive(true);
                ShowScore();
            }
           
        }

       

      
	}

    public void ShowScore(){
        _highScore.text = ("HighScore:" + PlayerPrefs.GetFloat("HighScore").ToString() + "\n" +
                           "BestKpm:" + PlayerPrefs.GetFloat("HighKpm").ToString()
                          );

        isShow = true;

    }
}
