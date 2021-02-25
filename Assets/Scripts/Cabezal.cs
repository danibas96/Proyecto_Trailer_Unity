using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabezal : MonoBehaviour
{
    public WheelCollider[] wc_C;
    public Transform[] Ruedas;
    public float torque,freno,friccion, volante;
    // Start is called before the first frame update
    public GameObject camara;
    public GameObject camion;
    private Vector3 distancia;
    void Start()
    {
        distancia = camara.transform.position - camion.transform.position;
    }
    void updateRuedas()
    {
        Vector3 pos;
        Quaternion rot;
        for (int i=0;i<wc_C.Length; i++)
        {
            wc_C[i].motorTorque = Input.GetAxis("Vertical")*torque;
            wc_C[i].brakeTorque = (Input.GetKey(KeyCode.Space)) ? freno : friccion- Mathf.Abs(Input.GetAxis("Vertical") * friccion);
            if(i<2)
               wc_C[i].steerAngle= Mathf.Lerp(wc_C[i].steerAngle, volante*Input.GetAxis("Horizontal"),Time.deltaTime*4);

            wc_C[i].GetWorldPose(out pos, out rot);
            Ruedas[i].position = pos;
            Ruedas[i].rotation = rot;
            Debug.Log(pos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateRuedas();
        camara.transform.position = camion.transform.position + distancia;

    }
}
