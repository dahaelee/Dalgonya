using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    const int DefaultLife = 3; // 생명 개수 
    const float StunDuration = 0.5f; // 스턴상태 유지시간 

    CharacterController controller;
    //Animator animator;

    Vector3 moveDirection = new Vector3(0.0f, 0.5f, -0.0f);
    int life = DefaultLife;
    float recoverTime = 0.0f;

    public float gravity;
    public float speedZ;
    public float speedX;
    public float speedJump;
    public float accelerationZ;

    public int Life()
    {
        return life;
    }

    // 스턴상태 여부
    public bool IsStun()
    {
        return recoverTime > 0.0f || life <= 0; // 회복 중이거나 생명 다 썼을 때 
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            MoveToLeft();
        if (Input.GetKey(KeyCode.RightArrow))
            MoveToRight();
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        // 스턴 상태일 때 좌우 이동 막기
        if (IsStun())
        {
            moveDirection.x = 0.0f;
            moveDirection.z = 0.0f;
            recoverTime -= Time.deltaTime;
        }

        else
        {
            // Z방향으로 천천히 가속
            float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
            moveDirection.z = Mathf.Clamp(acceleratedZ, 0, speedZ);
        }

        // 중력만큼의 힘을 매 프레임에 추가
        moveDirection.y -= gravity * Time.deltaTime;

        // 이동 실행
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection * Time.deltaTime);

        // 이동 후 접지하고 있으면 Y방향의 속도는 리셋
        if (controller.isGrounded) moveDirection.y = 0;

        // 속도가 0 이상이면 애니메이터에 달리고 있는 플래그를 true로 
        //animator.SetBool("run", moveDirection.z > 0.0f);
    }

    public void MoveToLeft()
    {
        if (IsStun()) // 스턴상태인지 체크
            return;
        //if (controller.isGrounded)
            moveDirection.x = -speedX;
    }

    public void MoveToRight()
    {
        if (IsStun()) // 스턴상태인지 체크
            return;
        moveDirection.x = speedX;
    }

    public void Jump()
    {
        if (IsStun()) // 스턴상태인지 체크
            return;
        moveDirection.y = speedJump;

        // 애니메이터에 점프 트리거를 설정
        //animator.SetTrigger("jump");
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (IsStun()) // 스턴상태인지 체크
            return;

        // 장애물 태그 별로 다르게 반응하기
    }
}
