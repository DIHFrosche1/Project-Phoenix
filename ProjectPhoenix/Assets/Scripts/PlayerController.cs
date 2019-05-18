using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(CapsuleCollider))] // Set Collider to 2 in height
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_WalkSpeed;
    [SerializeField] private MouseLook m_MouseLook;




    private CharacterController m_CharacterController;
    private Vector3 m_MoveDir = Vector3.zero;
    private Vector2 m_Input;



    // Start is called before the first frame update
    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float speed;
        GetInput(out speed);

        Vector3 desiredMove = transform.forward * m_Input.y + transform.right * m_Input.x;

        m_MoveDir.x = desiredMove.x * speed;
        m_MoveDir.z = desiredMove.z * speed;

        m_CharacterController.Move(m_MoveDir * Time.deltaTime);
    }
    void PlayerState()
    {

    }
    void GetInput(out float speed)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        speed = m_WalkSpeed;
        m_Input = new Vector2(horizontal, vertical);

        if (m_Input.sqrMagnitude > 1)
        {
            m_Input.Normalize();
        }
    }
   
}

