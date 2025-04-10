using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    //public RectTransform PanelCTA;
    //public RectTransform PanelInfo;

    public bool nearObject=false;

    public Vector3 CameraOffset = new Vector3(0, 0, 0);
    public Camera myCamera;
    public int velocidad = 4;

    Animator animatorController;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (myCamera != null)
        {
            myCamera.transform.position = transform.position + CameraOffset;
        }

        //obtener la referencia del Animator
        animatorController = GetComponent<Animator>();


       // PanelCTA.gameObject.SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;
        //transform.position +=
        //    new Vector3(0,0, 0.1f*deltaTime);

        //transform.localPosition = new Vector3(0, 0, 0.1f * deltaTime);

        //W, S A y D

        transform.position += new Vector3(0, 0, Input.GetAxis("Vertical") * deltaTime*velocidad);
        transform.position += new Vector3(Input.GetAxis("Horizontal") * deltaTime*velocidad, 0, 0);

        //salto incompleto
        var pos = transform.position;
        //pos.y += Input.GetButton("Jump") ? 1 * deltaTime : 0;
        //transform.position = pos;

        if (myCamera != null)
        {
            myCamera.transform.position = transform.position + CameraOffset;
        }

        //apuntar el personaje en la direccion que se mueva
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (movement != Vector3.zero)
        {
            //establecer directamente la rotacion
            //transform.forward = movement.normalized;

            //establecer la rotacion con una suave interpolación
            //crear un quaterion con la rotacion deseada
            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation =
                Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);

          
            animatorController.SetBool("isMooving", true); // Set the isMoving parameter to true in the AnimatorController
        }
        else
        {
            
            animatorController.SetBool("isMooving", false); // Set the isMoving parameter to true in the AnimatorController

        }









    }


  





}
