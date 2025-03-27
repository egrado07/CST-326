using UnityEngine;
using TMPro; // Add TextMeshPro namespace
using System.Collections;

public class MoneyUI : MonoBehaviour {

    public TextMeshProUGUI moneyText; // Change from Text to TextMeshProUGUI

    // Update is called once per frame
    void Update () {
        moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}