using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Actor_Player : Actor
{
    Rigidbody rigid;
    Skill_Near skillNear;
    float gravity = -9.81f;
    [SerializeField] float stamina;
    [SerializeField] Slider staminaSlider;
    [SerializeField] Slider staminaSliderBack;
    [SerializeField] float speed;
    [SerializeField] GameObject skillMgr;
    [SerializeField] Transform playerCam;
    Vector3 MoveDir = Vector3.zero;
    [SerializeField] float staminaTime = 2;
    float playerSpeed;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        skillNear = skillMgr.GetComponent<Skill_Near>();
    }

    private void Start()
    {
        playerSpeed = speed;
    }

    private void Update()
    {
        Move();
        if(Input.GetMouseButtonDown(0))
        {
            skillNear.SkillPlay(eSkill.Normal_Near);
        }
        staminaIdle(true);
        staminaTimer(true, false);
    }
    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        float vertical = Input.GetAxisRaw("Vertical");

        MoveDir = new Vector3(horizontal, 0f, vertical);

        MoveDir = MoveDir.normalized;

        Vector3 cameraForward = playerCam.forward;
        Vector3 cameraRight = playerCam.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        MoveDir = MoveDir.z * cameraForward + MoveDir.x * cameraRight;
        if(Input.GetKeyDown(KeyCode.LeftShift) && staminaSlider.value > 0)
        {
            speed *= 2;
            staminaIdle(false);
            if (staminaSlider.value <= 0)
            {
                return;
            }
        }
        if
        (Input.GetKey(KeyCode.LeftShift) && staminaSlider.value > 0)
        {
            staminaSlider.value -= stamina * Time.deltaTime;
            staminaTimer(false, true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && speed >= playerSpeed)
        {
            speed /= 2;
        }
        transform.Translate(MoveDir * speed * Time.deltaTime, Space.World);
    }

    private void staminaIdle(bool _bool)
    {
        if(_bool == true && staminaTime == 0)
        {
            staminaSlider.value += stamina / 2 * Time.deltaTime;
        }
        else if(_bool == false)
        {
            return;
        }
    }

    private void staminaTimer(bool _timer, bool _reset)
    {
        if(_timer == true)
        {
            staminaTime -= Time.deltaTime;
        }
        if(staminaTime <= 0)
        {
            staminaTime = 0;
        }
        if(_reset == true)
        {
            staminaTime = 2;
        }
    }
}
