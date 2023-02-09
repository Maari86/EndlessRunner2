using UnityEngine;
using Cinemachine;

public class ParallaxBackground_0 : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public GameObject[] backgrounds;
    private int currentBackground;

    private void Start()
    {
        currentBackground = 0;
        virtualCamera.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;
        virtualCamera.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Time = 0.5f;
     //   virtualCamera.GetComponent<CinemachineBrain>().m_CameraCutEvent.AddListener(ChangeBackground);
    }

    private void ChangeBackground()
    {
        backgrounds[currentBackground].SetActive(false);
        currentBackground = (currentBackground + 1) % backgrounds.Length;
        backgrounds[currentBackground].SetActive(true);
    }
}
