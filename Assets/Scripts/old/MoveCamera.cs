using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Header("GameObject")]
    // Start is called before the first frame update

    public Transform TargetObject;
    public Transform Camera;
    public Rigidbody2D RB2D;

    void Start()
    {
        transform.position=new Vector3(TargetObject.position.x, TargetObject.position.y, -10);
        // RB2D=GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // Camera.position=Vector3.Lerp(new Vector3(Camera.position.x,Camera.position.y,-10), TargetObject.position,Time.deltaTime);


        transform.position= new Vector3(TargetObject.position.x, TargetObject.position.y, -10);
        // Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector2(transform.position) + RB2D.velocity.normalized*7, 5*Time.deltaTime);

    // TargetObject.position.z
    // catch (Exception error) {
    //     Debug.LogError(error);
    // }
        
    }
}
