//-----------------------------------------------------------------
//1，把本类作为一个组件，包含在 GameObject 中。
//2，左手坐标系。
//-----------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//-----------------------------------------------------------------
//使用WSAD键控制摄像机的前后左右移动，使用鼠标右键控制摄像机的旋转
//这个脚本不只可以用在摄像机上，也可以用在一般的GameObject上
public class Came : MonoBehaviour
{
    public float moveSpeed = 30.0f;
    public float rotateSpeed = 0.2f;


    public static Vector3 kUpDirection = new Vector3(0.0f, 1.0f, 0.0f);


    //控制摄像机旋转的成员变量。
    private float m_fLastMousePosX = 0.0f;
    private float m_fLastMousePosY = 0.0f;
    private bool m_bMouseRightKeyDown = false;


    //-----------------------------------------------------------------
    void Start()
    {


    }
    //-----------------------------------------------------------------
    void Update()
    {
        //判断旋转
        if (Input.GetMouseButtonDown(0)) //鼠标右键刚刚按下了
        {
            if (m_bMouseRightKeyDown == false)
            {
                m_bMouseRightKeyDown = true;
                Vector3 kMousePos = Input.mousePosition;
                m_fLastMousePosX = kMousePos.x;
                m_fLastMousePosY = kMousePos.y;
            }
        }
        else if (Input.GetMouseButtonUp(0)) //鼠标右键刚刚抬起了
        {
            if (m_bMouseRightKeyDown == true)
            {
                m_bMouseRightKeyDown = false;
                m_fLastMousePosX = 0;
                m_fLastMousePosY = 0;
            }
        }
        else if (Input.GetMouseButton(0)) //鼠标右键处于按下状态中
        {
            if (m_bMouseRightKeyDown)
            {
                Vector3 kMousePos = Input.mousePosition;
                float fDeltaX = kMousePos.x - m_fLastMousePosX;
                float fDeltaY = kMousePos.y - m_fLastMousePosY;
                m_fLastMousePosX = kMousePos.x;
                m_fLastMousePosY = kMousePos.y;


                Vector3 kNewEuler = transform.eulerAngles;
                kNewEuler.x += (fDeltaY * rotateSpeed);
                kNewEuler.y += -(fDeltaX * rotateSpeed);
                transform.eulerAngles = kNewEuler;
            }
        }

        //判断缩放
        //Zoom out
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView <= 100)
                Camera.main.fieldOfView += 2;
            if (Camera.main.orthographicSize <= 20)
                Camera.main.orthographicSize += 0.5F;
        }
        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView > 2)
                Camera.main.fieldOfView -= 2;
            if (Camera.main.orthographicSize >= 1)
                Camera.main.orthographicSize -= 0.5F;
        }

        //判断位移
        float fMoveDeltaX = 0.0f;
        float fMoveDeltaZ = 0.0f;
        float fDeltaTime = Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            fMoveDeltaX -= moveSpeed * fDeltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            fMoveDeltaX += moveSpeed * fDeltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            fMoveDeltaZ += moveSpeed * fDeltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            fMoveDeltaZ -= moveSpeed * fDeltaTime;
        }
        if (fMoveDeltaX != 0.0f || fMoveDeltaZ != 0.0f)
        {
            Vector3 kForward = transform.forward;
            Vector3 kRight = Vector3.Cross(kUpDirection, kForward);
            Vector3 kNewPos = transform.position;
            kNewPos += kRight * fMoveDeltaX;
            kNewPos += kForward * fMoveDeltaZ;
            transform.position = kNewPos;
        }
    }
}
//-----------------------------------------------------------------
