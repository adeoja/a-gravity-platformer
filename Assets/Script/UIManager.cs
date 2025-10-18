using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text hintTextPopup;
    //[SerializeField] private Button PlayButton;
    
    private GameObject[] hintsArray = new GameObject[10];
    [SerializeField] private string[] hintsString = new string[10];
    public int index;

    public static UIManager Instance;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        hintTextPopup.enabled = false;
    }

    public void DisplayHint(GameObject hintTrigger)
    {
        if (!hintsArray.Contains(hintTrigger) && hintsArray.Length >= index+1 && hintsString.Length >= index+1)
        {
            CancelInvoke("HideHint");
            
            hintTextPopup.enabled = true;
            hintsArray[index] = hintTrigger;
            hintTextPopup.text = hintsString[index];
            index++;
            Invoke("HideHint", 5.0f);
        }
    }

    public void HideHint()
    {
        hintTextPopup.enabled = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
