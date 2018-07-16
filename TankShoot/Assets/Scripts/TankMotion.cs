using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMotion : MonoBehaviour {

    public GameObject myTank;
    public Transform tr;

    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public GameObject Big_Bullet;

    public float Bullet_Forword_Force;
    public float Bullet_speed;
    public float Bullet_direction = 7.0f;
    public float gage;
    public float Tankspeed = 5.0f;
    public float directionMAX = 11.0f;
    public float directionMIN = 2.0f;
    public float DirectionChageSpeed = 0.3f;
    public float gageSpeed = 0.5f;

    private float v;

    // Use this for initialization
    void Start () {
        Bullet_Forword_Force = 200;
        Bullet_direction = 7.0f;
        Tankspeed = 5.0f;
        directionMIN = 2.0f;
        DirectionChageSpeed = 0.3f;
        gageSpeed = 0.8f;

}
	
	// Update is called once per frame
	void Update () {
        v = Input.GetAxis("Vertical");
        moving();
        Shooting();
	}

    public void moving()
    {

        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) //왼쪽으로 이동
        {
            if (v >= 0)
            {
                this.transform.Rotate(0, -Tankspeed * 10 * Time.deltaTime, 0);
            }
            else
            {
                this.transform.Rotate(0, Tankspeed * 10 * Time.deltaTime, 0);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) //오른쪽으로 이동
        {
            if (v < 0)
            {
                this.transform.Rotate(0, -Tankspeed * 10 * Time.deltaTime, 0);
            }
            else
            {
                this.transform.Rotate(0, Tankspeed * 10 * Time.deltaTime, 0);
            }

        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) //위쪽으로 이동
        {
            this.transform.Translate(Vector3.forward * Tankspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) //아래쪽으로 이동
        {
            this.transform.Translate(Vector3.back * Tankspeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Z) && Bullet_direction < directionMAX) //dirction 위로
        {
            Bullet_direction += DirectionChageSpeed;
        }
        if (Input.GetKey(KeyCode.X) && Bullet_direction > directionMIN) //dirction 아래로
        {
            Bullet_direction -= DirectionChageSpeed;
        }
    }

    public void SpawnsmallBullet()
    {
        
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
        Temporary_RigidBody.AddForce(transform.forward * Bullet_Forword_Force);
        Temporary_RigidBody.velocity = transform.TransformDirection(new Vector3(0, Bullet_direction, 0));

        Destroy(Temporary_Bullet_Handler, 7.0f);
    }
    public void SpawnBigBullet()
    {
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Big_Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
        Temporary_RigidBody.AddForce(transform.forward * Bullet_Forword_Force);
        Temporary_RigidBody.velocity = transform.TransformDirection(new Vector3(0, Bullet_direction, 0));

        Destroy(Temporary_Bullet_Handler, 10.0f);
    }

    public void Shooting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            gage += gageSpeed * Time.deltaTime;

        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            if (gage > 1)
            {
                Bullet_Forword_Force = 1000;
                SpawnBigBullet();
            }
            else
            {
                Bullet_Forword_Force = 400;
                SpawnsmallBullet();
            }
            gage = 0.0f;
        }

    }
}
