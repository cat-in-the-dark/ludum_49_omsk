using UnityEngine;
using UnityEngine.UI;

public class NewsFeed : MonoBehaviour
{
    string text = "";
    int showTextLength = 1;
    double timer = 0;
    const double timePerSymbol = 0.02;

    private Text textField;
    public GameObject newsScreenBackground;
    public GameObject newsScreenHolder;

    public void SetText(string text_)
    {
        text = text_;
        showTextLength = 1;
        timer = 0;
        newsScreenBackground.SetActive(true);
        newsScreenHolder.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        textField = newsScreenHolder.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timePerSymbol && showTextLength < text.Length)
        {
            timer = 0;
            textField.text = text.Substring(0, showTextLength);
            showTextLength += 1;
        }

        if (Input.GetButton("Jump") || Input.GetButton("Submit"))
        {
            HideNews();
        }
    }

    public void HideNews()
    {
        newsScreenBackground.SetActive(false);
        newsScreenHolder.SetActive(false);
    }
}
