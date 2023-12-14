using UnityEngine;

[ExecuteInEditMode]
public class RevealObject : MonoBehaviour
{
    [SerializeField] Material Mat;
    [SerializeField] Light SpotLight;

    void Start()
    {
        Mat = GetComponent<Renderer>().sharedMaterial;
    }

    void Update()
    {
            Mat.SetVector("MyLightPosition", SpotLight.transform.position);
            Mat.SetVector("MyLightDirection", -SpotLight.transform.forward);
            //Mat.SetFloat ("MyLightAngle", SpotLight.spotAngle         );
    }
}