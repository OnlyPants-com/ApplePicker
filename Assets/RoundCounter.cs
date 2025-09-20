using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public ApplePicker applePicker;
    public int roundNum = 1;
    private TextMeshProUGUI displayRound;
    // Start is called before the first frame update
    void Start()
    {
        displayRound = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        displayRound.text = "Round: " + roundNum.ToString();
        // int round = 5 - applePicker.numBaskets;

        // if (round != lastRound)
        // {
        //     roundNum.text = "Round: " + round;
        //     lastRound = round;
        // }
    }
}
