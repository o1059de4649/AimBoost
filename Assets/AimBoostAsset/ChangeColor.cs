using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.Characters.FirstPerson
{
    public class ChangeColor : MonoBehaviour
    {
        public Material clear_material;
        public Timer timer;
        // Use this for initialization
        void Start()
        {
            timer = GameObject.Find("GameMaster").GetComponent<Timer>();
            if (timer.isFinish)
            {
                this.gameObject.GetComponent<Renderer>().material = clear_material;
            }
        }

        // Update is called once per frame
        void Update()
        {
         
        }
    }
}