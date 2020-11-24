using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Charactor Movment Animation Script

public class Player : MonoBehaviour {

    static public Player instance; //인스턴스 생성

    public string currentMapName; //transferMap 스크립트에 있는 tranferMap 변수 값 저장

    private BoxCollider2D boxCollider;
    public LayerMask layerMask;//통과가 불가능한 레이어를 설정

    public string walkSound;

    private SoundManager soundManager;

    public float speed; //움직일 속도 정의
    private Vector3 vec; //움직이는 방향 정의

    public float runSpeed; // shift키 입력시 증가할 속도
    private float applyRunSpeed; // shitf키 입력시 연산되는 증가 속도
    private bool applyRunFlag = false; // shift키 입력 여부

    public int walkCount; //방향키 입력시 이동값을 정하기 위한 값
    private int currentWalkCount; //이동값 리셋을 위한 값

    private bool canMove = true; //방향키 이동 반복실행 방지를 위한 값

    public bool notMove = false; //키입력 방지

    private Animator animator;



    void Start()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);// 씬 전환될 때마다 파괴되지 않게 
            boxCollider = GetComponent<BoxCollider2D>();
            animator = GetComponent<Animator>(); // 애니메이터 컴포넌트 가져오기
            instance = this;
            notMove = false;

            soundManager = FindObjectOfType<SoundManager>();

        }
        else
        {
            Destroy(this.gameObject);
        }
       
    }

    IEnumerator MoveCoroutine()
    {

        // 키입력이 이뤄지는 동안 실행
        while (Input.GetAxisRaw("Horizontal") != 0 && !notMove)
        {
            // Shift키 입력을 확인하여 스피드 값 할당, 입력 여부를 반환            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                applyRunSpeed = runSpeed;
                applyRunFlag = true;
            }
            else
            {
                applyRunSpeed = 0;
                applyRunFlag = false;
            }

            // 변수 vector의 값으로 입력한 방향키 값을 할당 -1 또는 1
            vec.Set(Input.GetAxisRaw("Horizontal"), 0, transform.position.z);

            // 입력한 vector 값을 받아 파라미터로 전달 -> 받은 파라미터를 기반으로 애니메이션 실행
            // 동시입력시에 상하키는 기본0이 되도록 설정
            if (vec.x != 0)
            {
                vec.y = 0;
            }

            animator.SetFloat("DirX", vec.x); //여기 문제인가?

            RaycastHit2D hit;

            Vector2 start = transform.position; //시작 지점 , 캐릭터의 현재 위치 값
            Vector2 end = start + new Vector2(vec.x * speed * walkCount,0); //끝 지점, 캐릭터가 이동하고자 하는 위치의 값


            boxCollider.enabled = false;
            hit = Physics2D.Linecast(start, end, layerMask);
            boxCollider.enabled = true;


            if (hit.transform != null)
                break;

            animator.SetBool("walk", true);



            // walkCount 값만큼 반복하여 객체 이동 walkCount(20) * speed(2.4) = 48px
            // 이동시 Shift키 입력여부 확인하여 Speed 값 추가(2.4)
            while (currentWalkCount < walkCount)
            {
                if (vec.x != 0)
                {
                    transform.Translate(vec.x * (speed + applyRunSpeed), 0, 0);
                }

                // Shift키 입력시 동시에 실행하여 +2씩 증가하는 효과
                if (applyRunFlag)
                {
                    currentWalkCount++;
                }
                currentWalkCount++;

                // 0.01f의 대기시간을 가지고 while문을 반복
                yield return new WaitForSeconds(0.01f);
            }

            if(currentWalkCount == 2) //걷는 소리 재생
            {
                //soundManager.Play(walkSound);
            }
            //soundManager.Stop(walkSound); //걷는 소리 재생 중지
            //soundManager.LoopCancle(walkSound); //루프 중지
            //soundManager.LoopSound(walkSound); //루프

            //soundManager.SoundVolum(walkSound,0.3f); //볼륨

            // 변수 리셋
            currentWalkCount = 0;
        }
        canMove = true;

        // Walking 값 리셋
        animator.SetBool("walk", false);
    }

   
    void Update()
    {
        // canMove 변수값에 따라서 작동
        if (canMove && !notMove)
        {
            // 좌측 방향키면 -1, 우측 방향키면 1 
            if (Input.GetAxisRaw("Horizontal") != 0 )
            {
                canMove = false;
                // 코루틴 실행
                StartCoroutine(MoveCoroutine());
            }
        }

        
    }
}
