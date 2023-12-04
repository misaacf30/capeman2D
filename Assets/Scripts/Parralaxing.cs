using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralaxing : MonoBehaviour
{
    public Transform[] backgrounds;
    private float[] parallaxScales;
    public float smoothingValue;
    private Vector3 prevCameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        smoothingValue = 100;                                    // smothing value can be changed
        prevCameraPosition = transform.position;
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < parallaxScales.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pfactor = Vector3.zero;

        for (int i = 0; i < backgrounds.Length; i++)
        {
            pfactor = (prevCameraPosition - transform.position) * (parallaxScales[i] / smoothingValue);
            backgrounds[i].position = new Vector3(backgrounds[i].position.x + pfactor.x, backgrounds[i].position.y + pfactor.y, backgrounds[i].position.z);
        }

        prevCameraPosition = transform.position;
    }
}
