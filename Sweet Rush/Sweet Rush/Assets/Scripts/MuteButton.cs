using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    bool isMute;
    public Text text;

    public void Mute()
    {
        
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
        if(isMute == true)
        {
            text.enabled = false;
        }
        else
        {
            text.enabled = true;
        }
    }

}
