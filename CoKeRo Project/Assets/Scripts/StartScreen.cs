using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class StartScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Screen;
    public TextMeshProUGUI starttext;

    private float counter;
    void Start()
    {
        counter = 5;
        PlayerController.instance.enabled = false;
        starttext.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;
        if (counter <= 0)
        {
            starttext.enabled = true;
            PlayerController.instance.enabled = true;
            if (Input.anyKey)
            {
                Destroy(Screen);
            }
        }
    }
}
