using UnityEditor;
using UnityEngine;

public class Orbe : MonoBehaviour
{
    public float oscilationFrequency;
    public float oscilationAmplitude;
    public float oscilationOffset = 1;

    //si debe hacer el efecto de rotar
    public bool MustRotate;
    public float angularSpeed;

    public bool MustThrob;
    public float ThrobbingFrequency = 2;
    public float ThrobbingScale = 1.5f;
    public float floor=0;
    public bool nearObject = false;

   


    public RectTransform PanelObj;
    public RectTransform PanelCTA;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PanelObj.gameObject.SetActive(false);

        nearObject = false;
        PanelCTA.gameObject.SetActive(false);
        PanelObj.gameObject.SetActive(false);

     


    }

    // Update is called once per frame
    void Update()
    {
        //    y = c Sin(kx)
        float ypos = Mathf.Sin(Time.time * oscilationFrequency) * oscilationAmplitude;

        transform.localPosition =
            new Vector3(transform.localPosition.x, oscilationOffset + ypos, transform.localPosition.z);



        if (MustRotate)
        {
            //para rotar un objeto en angulos de Euler
            // VEctor3.up esta definido como (0,1,0)
            transform.Rotate(Vector3.up, angularSpeed * Time.deltaTime);
        }

        if (MustThrob)
        {
            float scale = 1 + Mathf.Sin(ThrobbingFrequency * Time.time) * (ThrobbingScale - 1);
            transform.localScale = new Vector3(scale, scale, scale);
        }



        
        if (nearObject)
        {
            PanelCTA.gameObject.SetActive(true);
        }
        else
        {
            PanelCTA.gameObject.SetActive(false);

        }

            if (Input.GetButton("Jump") && nearObject)
        {
            PanelCTA.gameObject.SetActive(false);
            PanelObj.gameObject.SetActive(true);
        }
        else
        {
            //PanelCTA.gameObject.SetActive(true);
            PanelObj.gameObject.SetActive(false);
        }




       

}


    public void OnTriggerEnter(Collider other)
    {
        
        nearObject = true;
    }

    public void OnTriggerExit(Collider other)
    {

        //PanelCTA.gameObject.SetActive(false);
        PanelObj.gameObject.SetActive(false);
        nearObject = false;
    }
}


