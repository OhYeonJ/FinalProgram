using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    static public CameraMovement instance;

    public GameObject target; //카메라가 따라갈 대상
    public float moveSpeed; //카메라의 속도
    private Vector3 targetPosition; //따라갈 대상의 현재 위치

    public BoxCollider2D bound;

    private Vector3 minBound;
    private Vector3 maxBound; //박스 컬라이더 영역의 최대 x,y값을 지님

    private float halfWidth;
    private float halfHeight; //카메라의 반너비,반높이 값을 지닐 변수

    private Camera theCamera; //카메라의 반높이값을 구할 속성을 이용하기 위한 변수

   
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }

        target = GameObject.Find("Player");
    }
    

    void Start()
    {
       
        //target = GameObject.Find("Player");
        DontDestroyOnLoad(gameObject);// 씬 전환될 때마다 파괴되지 않게 
        theCamera = GetComponent<Camera>();
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;
        halfHeight = theCamera.orthographicSize; //카메라의 반높이
        halfWidth = halfHeight * Screen.width / Screen.height; //해상도

    }

    void Update()
    {
        if(target.gameObject != null)
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime); //1초에 MoveSpeed만큼 이동

            float clampedX = Mathf.Clamp(this.transform.position.x, minBound.x + halfWidth, maxBound.x - halfWidth);
            float clampedY = Mathf.Clamp(this.transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);

            this.transform.position = new Vector3(clampedX, clampedY, this.transform.position.z);
        }
        
    }

    public void SetBound(BoxCollider2D nBound)
    {
        bound = nBound;
        minBound = bound.bounds.min; 
        maxBound = bound.bounds.max;


    }
    
}
