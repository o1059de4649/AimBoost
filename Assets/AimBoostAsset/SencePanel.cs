using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class SencePanel : MonoBehaviour,IPointerDownHandler
    {
        public InputField inputField;
        int _sence;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnPointerDown(PointerEventData eventData){
            DesideSence();
        }

        public void DesideSence()
        {
            Int32.TryParse(inputField.text, out _sence);
            PlayerPrefs.SetFloat("Sensitivity", _sence);
            SceneManager.LoadScene("Main");
        }
    }
}