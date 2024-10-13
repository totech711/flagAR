using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManagerb : MonoBehaviour
{
    public Button mainButton;
    public GameObject menuPanel;

    void Start()
    {
        // Ensure the menu panel is hidden at the start
        menuPanel.SetActive(false);

        // Add listener for button click
        mainButton.onClick.AddListener(OnMainButtonClick);
    }

    // This method is called when the main button is clicked
    void OnMainButtonClick()
    {
        mainButton.gameObject.SetActive(false);
        menuPanel.SetActive(true);
    }

    // Cleanup method to avoid memory leaks
    void OnDestroy()
    {
        mainButton.onClick.RemoveListener(OnMainButtonClick);
    }
}
