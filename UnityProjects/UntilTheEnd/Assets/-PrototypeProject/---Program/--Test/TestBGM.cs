using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UntilTheEnd
{
    public class TestBGM : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            AudioManager.instance.PlayBGM(AudioManager.BGMAudioType.LoginBGM);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
