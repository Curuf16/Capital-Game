using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AracKontrol : MonoBehaviour
{
    public WheelCollider onSolCol;
    public WheelCollider onSagCol;
    public WheelCollider arkaSolCol;
    public WheelCollider arkaSagCol;

    public GameObject onSol;
    public GameObject onSag;
    public GameObject arkaSol;
    public GameObject arkaSag;

    public float maxMotorGucu;
    public float maxDonusAcisi;
    public float motor;

    private void FixedUpdate()
    {
        motor = maxMotorGucu * Input.GetAxis("Vertical");
        float donus = maxDonusAcisi * Input.GetAxis("Horizontal");

        onSolCol.steerAngle = onSagCol.steerAngle = donus;
        arkaSagCol.motorTorque = motor;
        arkaSolCol.motorTorque = motor;
        onSolCol.motorTorque = motor;
        onSagCol.motorTorque = motor;

        SanalTeker();
    }

    void SanalTeker()
    {
        Quaternion rot;
        Vector3 pos;
        onSolCol.GetWorldPose(out pos, out rot);
        onSol.transform.position = pos;
        onSol.transform.rotation = rot;

        onSagCol.GetWorldPose(out pos, out rot);
        onSag.transform.position = pos;
        onSag.transform.rotation = rot;

        arkaSolCol.GetWorldPose(out pos, out rot);
        arkaSol.transform.position = pos;
        arkaSol.transform.rotation = rot;

        arkaSagCol.GetWorldPose(out pos, out rot);
        arkaSag.transform.position = pos;
        arkaSag.transform.rotation = rot;
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Chapter2")
        {
            SceneManager.LoadScene(2);
        }
    }
}
