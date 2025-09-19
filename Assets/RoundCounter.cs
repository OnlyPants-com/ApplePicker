using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundCounter : MonoBehaviour
{
    public ApplePicker applePicker;
    public TextMeshProUGUI roundNum;
    private int lastRound = -1;
    // Start is called before the first frame update
   
    void Update()
    {
        int round = 5 - applePicker.numBaskets;

        if (round != lastRound)
        {
            roundNum.text = "Round: " + round;
            lastRound = round;
        }
    }
}
