using UnityEngine;
using TMPro; // Add TextMeshPro namespace

public class LivesUI : MonoBehaviour {

    public TextMeshProUGUI livesText; // Change from Text to TextMeshProUGUI
  
    // Update is called once per frame
    void Update () {
        livesText.text = PlayerStats.Lives.ToString() + " LIVES";
    }
}