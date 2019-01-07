using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace UnityStandardAssets.Characters.FirstPerson
{
    public class Timer : MonoBehaviour
    {
        public float _time, _maxTime;
        public float _timeInt,_accuracyInt,_deltaTime,_kpm;

        public Text text,score;


        public GameObject player;
        FirstPersonController firstPersonController;
        public FPSCalc fPSCalc;
        public GameObject panel;

        public bool isFinish = false,isLog = false;
        bool isShowPanel = false;
        // Use this for initialization
        void Start()
        {
            _time = 60;
            _maxTime = 60;

            firstPersonController = player.GetComponent<FirstPersonController>();
            Application.targetFrameRate = -1;
        }

        // Update is called once per frame
        void Update()
        {
            _time -= Time.deltaTime;
            _timeInt = Mathf.Floor(_time);

            _deltaTime = _maxTime - _time;

            //Editor
            if(Input.GetKeyDown(KeyCode.E)){
                if(!isShowPanel){
                    panel.SetActive(true);
                    isShowPanel = true;
                }else{
                    panel.SetActive(false);
                    isShowPanel = false;
                }
            }

           

            if(Input.GetKey(KeyCode.R)){
                SceneManager.LoadScene("Main");
            }
            //end


           

           
            if(!isFinish){
                _accuracyInt = firstPersonController._score / firstPersonController._shot;
                _kpm = firstPersonController._score / _deltaTime;



                text.text = (_timeInt.ToString());
                score.text = ("Score:" + firstPersonController._score.ToString() + "\n" +
                              "Accuracy:" + _accuracyInt.ToString() + "\n" +
                              "KillPerSecond:" + _kpm.ToString() + "\n" +
                              "FPS" + fPSCalc._fps.ToString()
                             );
            }
         

            if (_time < 0)
            {
                _time = 0;

                isFinish = true;

                Finished();
            }
           
        }

        void Finished(){
            if(isLog){
                return;
            }

            if (isFinish)
            {

                if (!PlayerPrefs.HasKey("HighScore"))
                {
                    PlayerPrefs.SetFloat("HighScore", firstPersonController._score);
                }

                if (!PlayerPrefs.HasKey("HighKpm"))
                {
                    PlayerPrefs.SetFloat("HighKpm", _kpm);
                }

                if (PlayerPrefs.GetFloat("HighScore") < firstPersonController._score)
                {
                    PlayerPrefs.SetFloat("HighScore", firstPersonController._score);
                }

                if (PlayerPrefs.GetFloat("HighKpm") < _kpm)
                {
                    PlayerPrefs.SetFloat("HighKpm", _kpm);
                }
                isLog = true;
            }
        }


    }
}
