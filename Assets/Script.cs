using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //动态创建游戏对象（当相机看不见游戏对象时，应该Destroy(obj)防止内存泄漏）
        GameObject goNew = GameObject.CreatePrimitive(PrimitiveType.Cube);
        goNew.transform.position = new Vector3(0, 0, -2);//位置
        goNew.AddComponent<Rigidbody>();//添加钢体属性（也可动态添加脚本 goNew.AddComponent<Script>();“Script”为脚本名）

    }

    // Update is called once per frame
    void Update () {
        //FPS:Frame Per Second

        ////向前的脉冲力
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //this.gameObject//当前脚本实例依附的游戏对象
        //    this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 50, ForceMode.Impulse);//向前的脉冲力，50为力的大小
        //}

        ////鼠标点击位置的脉冲力（鼠标坐标转为世界坐标）
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 tarGetPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,3));//3表示z方向的假定深度，因为屏幕是二维没有深度，越大越靠里
        //    Vector3 dir = tarGetPos - Camera.main.transform.position;//vector2 - vector1 表示从vector1指向vector2的向量
        //    this.gameObject.GetComponent<Rigidbody>().AddForce(dir * 5, ForceMode.Impulse);
        //}

    }
}
