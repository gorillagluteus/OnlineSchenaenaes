using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Mirror;
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float smoothing;


    public CharacterController c;

    private int multiplierX;
    private int multiplierZ;
    private bool diagonalCheck;
    private float turn;
    private NetworkIdentity id;
    
    // Start is called before the first frame update
    void Awake()
    {
        GameObject MCam = GameObject.FindGameObjectWithTag("Cameras");
        MCam.transform.parent = this.transform;
        MCam.GetComponent<CameraControl>().UpdatePlayerBody(this.transform);
        id = this.gameObject.GetComponent<NetworkIdentity>();
    }

    // Update is called once per frame
    void Update()
    {
        if (id.hasAuthority)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");
            FPS(x, z);
        }
    }
    void FPS(float x, float z)
    {
        Vector3 move = transform.right * x + transform.forward * z;
        c.Move(move * speed * Time.deltaTime);
    }
}
