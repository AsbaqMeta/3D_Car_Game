using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _FPSCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public float frequency;

    private int m_FrameCount = 0;
    private float m_Timeleft;
    private Text m_Text;

    void Start()
    {
        m_Timeleft = frequency;
        m_Text = GetComponent<Text>();
    }

    void Update()
    {
        m_FrameCount++;
        m_Timeleft -= Time.deltaTime;
        if (m_Timeleft <= 0.0)
        {
            // Display the FPS
            m_Text.text = (m_FrameCount / frequency)+" FPS";
            m_Timeleft = frequency;
            m_FrameCount = 0;
        }
    }
}
