using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.Characters.FirstPerson
{
    public class FPSCalc : MonoBehaviour
    {

        int frameCount;
        float prevTime;
        public float _fps;
        void Start()
        {
            frameCount = 0;
            prevTime = 0.0f;
        }

        void Update()
        {
            ++frameCount;
            float time = Time.realtimeSinceStartup - prevTime;

            if (time >= 0.5f)
            {
                _fps = frameCount / time;
                _fps = Mathf.Ceil(_fps);

               

                frameCount = 0;
                prevTime = Time.realtimeSinceStartup;
            }
        }

    }
}