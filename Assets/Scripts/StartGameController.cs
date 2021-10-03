using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HideText();
    }

    void ShowText()
    {
        GetComponent<Text>().enabled = true;
        Invoke("HideText", 0.7f);
    }

    void HideText()
    {
        GetComponent<Text>().enabled = false;
        Invoke("ShowText", 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump") || Input.GetButton("Submit"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
