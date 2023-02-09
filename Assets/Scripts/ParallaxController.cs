using UnityEngine;
using Cinemachine;

public class ParallaxController : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    Vector3 camStartPos;
    Vector2 distance; // distance between the camera start position and its current position

    GameObject[] backgrounds;
    Material[] mat;
    float[] backSpeed;

    float farthestBack;

    [Range(0f, 0.05f)]
    public float parallaxSpeed;

    void Start()
    {
        cam = Camera.main.GetComponent<CinemachineVirtualCamera>();
        camStartPos = cam.transform.position;

        int backCount = transform.childCount;
        mat = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];

        for (int i = 0; i < backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;

        }
        BackSpeedCalculate(backCount);
    }

    void BackSpeedCalculate(int backCount)
    {
        for (int i = 0; i < backCount; i++) // find the farhthest background
        {
            if ((backgrounds[i].transform.position.z - cam.transform.position.z) > farthestBack)
            {
                farthestBack = backgrounds[i].transform.position.z - cam.transform.position.z;
            }

        }

        for (int i = 0; i < backCount; i++) // set the speed of backgrounds
        {
            backSpeed[i] = 1 - (backgrounds[i].transform.position.z - cam.transform.position.z) / farthestBack;
        }
    }



    private void LateUpdate()
    {
        distance = cam.transform.position - camStartPos;
        transform.position = new Vector3(cam.transform.position.x, transform.position.y, 0);


        for (int i = 0; i < backgrounds.Length; i++)
        {
            float speedX = backSpeed[i] * parallaxSpeed;
            float speedY = speedX / 2;  // if you close Y movement , set to 0
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance.x * speedX, distance.y * speedY));
        }
    }

}