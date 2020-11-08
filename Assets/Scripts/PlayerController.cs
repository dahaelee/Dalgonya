using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    const int DefaultLife = 3; // 생명 개수 
    const float StunDuration = 0.7f; // 스턴상태 유지시간 
    const float catnipDuration = 5.0f; // 캡닛상태 유지시간

    CharacterController controller;

    Vector3 moveDirection = new Vector3(0.0f, 0.5f, -0.0f);
    int life = DefaultLife;
    float recoverTime = 0.0f;
    float catnipTime = 0.0f;

    public float gravity;
    public float speedZ;
    public float speedX;
    public float speedJump;
    public float accelerationZ;

    Animator anima;
    PlayerController playercont;
    GameController gamecont;

    public AudioSource bgm_normal, bgm_catnip, nya1, nya2;
    public GameObject catnipSky;
    public GameObject cat;

    public int Life()
    {
        return life;
    }

    // 스턴상태 여부
    public bool IsStun()
    {
        return recoverTime > 0.0f || life <= 0; // 회복 중이거나 생명 다 썼을 때 
    }

    public bool IsCatnip()
    {
        return catnipTime > 0.0f;
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anima = GameObject.Find("img").GetComponent<Animator>();
        playercont = GetComponent<PlayerController>();
        gamecont = GameObject.Find("GameController").GetComponent<GameController>();
        catnipSky.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            MoveToLeft();
            if (IsCatnip())
                MoveToRight();
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            MoveToRight();
            if (IsCatnip())
                MoveToLeft();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            moveDirection.x = 0;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // 공중에 떠있으면 점프 애니메이션
        if (!controller.isGrounded & !IsStun()) 
            anima.SetInteger("Input", 1);

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

        // 이동 후 땅에 닿아있으면 Y방향의 속도는 리셋
        if (controller.isGrounded) moveDirection.y = 0;

        if (IsCatnip())
        {
            catnipTime -= Time.deltaTime;
            catnipSky.SetActive(true);
            bgm_normal.pitch = 2.0f;
        }
        if (!IsCatnip())
        {
            catnipSky.SetActive(false);
            bgm_normal.pitch = 1.0f;
        }
    }

    public void MoveToLeft()
    {
        if (IsStun()) // 스턴상태인지 체크
            return;
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
        if (controller.isGrounded)
            moveDirection.y = speedJump;

        // 애니메이터에 점프 트리거를 설정
        //animator.SetTrigger("jump");
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (IsStun()) // 스턴상태인지 체크
            return;

        // 장애물 태그 별로 다르게 반응하기
        if (hit.gameObject.tag == "heartminus")
        {
            nya1.PlayOneShot(nya1.clip);
            recoverTime = StunDuration;
            life--;
            anima.SetInteger("Input", -1);
            Destroy(hit.gameObject);
        }
        else if (hit.gameObject.tag == "reverse")
        {
            nya1.PlayOneShot(nya1.clip);
            recoverTime = StunDuration;
            catnipTime = catnipDuration;
            anima.SetInteger("Input", 2);
            Destroy(hit.gameObject, 0.7f);
        }
        else anima.SetInteger("Input", 0);

        if (hit.gameObject.tag == "Sil")
        {
            Destroy(hit.gameObject);
            nya1.PlayOneShot(nya2.clip);
            gamecont.itemscore = 30;
            Debug.Log(gamecont.itemscore);
        }

        else if (hit.gameObject.tag == "Mouse")
        {
            Destroy(hit.gameObject);
            nya1.PlayOneShot(nya2.clip);
            gamecont.itemscore = 50;
            Debug.Log(gamecont.itemscore);
        }

        else if (hit.gameObject.tag == "Tuna")
        {
            Destroy(hit.gameObject);
            nya1.PlayOneShot(nya2.clip);
            gamecont.itemscore = 100;
            Debug.Log(gamecont.itemscore);
        }
    }
}
