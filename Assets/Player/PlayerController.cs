using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum PlayerState { idle, walk, dash, air, jump };

    public PlayerState m_CurrState = PlayerState.idle;

    [SerializeField]
    private float WALK_SPEED = 5f;
    [SerializeField]
    private float JUMP_POWER = 200f;
    [SerializeField]
    private float DASH_POWER = 200f;

    private bool m_FacingRight = true;

    private float m_DashCDCurr = 0f;
    [SerializeField]
    private float DASH_CD = 2f;

    private bool m_IsGrounded = false;
    [SerializeField]
    private Vector3 m_GroundCheckTransform = new Vector3();
    [SerializeField]
    private float m_GroundCheckHeight = 0.3f;
    [SerializeField]
    private float m_GroundCheckWidth = 0.5f;
    public LayerMask m_GroundLayers;

    private Rigidbody2D m_Rb;

    // Start is called before the first frame update
    void Start()
    {
        m_Rb = GetComponent<Rigidbody2D>();
    }

    // Should be called when game is initializing
    public void InitPlayer()
    {
        m_CurrState = PlayerState.idle;
        m_IsGrounded = false;
        m_FacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_DashCDCurr > 0)
        {
            m_DashCDCurr -= Time.deltaTime;
        }

        m_IsGrounded = Physics2D.OverlapBox(transform.position + m_GroundCheckTransform, new Vector2(m_GroundCheckWidth, m_GroundCheckHeight), 0, m_GroundLayers);

        if((m_FacingRight && Input.GetAxis("Horizontal") < 0) || (!m_FacingRight && Input.GetAxis("Horizontal") > 0))
        {
            Flip();
        }

        ExecuteState();
    }

    // Call to Set the state of the player
    private void SetState(PlayerState t_State)
    {
        switch(t_State)
        {
            case PlayerState.idle:
                break;
            case PlayerState.walk:
                break;
            case PlayerState.dash:
                m_DashCDCurr = DASH_CD;
                m_Rb.AddForce(new Vector2((m_FacingRight) ? DASH_POWER : -DASH_POWER, 0));
                break;
            case PlayerState.air:
                break;
            case PlayerState.jump:
                m_Rb.AddForce(new Vector2(0, JUMP_POWER));
                break;
            default:
                break;
        }

        m_CurrState = t_State;
    }

    // Called once per frame in order to update the player
    private void ExecuteState()
    {
        switch (m_CurrState)
        {
            case PlayerState.idle:
                IdleState();
                break;
            case PlayerState.walk:
                WalkState();
                break;
            case PlayerState.dash:
                DashState();
                break;
            case PlayerState.air:
                AirState();
                break;
            case PlayerState.jump:
                JumpState();
                break;
            default:
                break;
        }
    }

    private void IdleState()
    {

        if(!m_IsGrounded)
        {
            SetState(PlayerState.air);
            return;
        }
        else if(Input.GetAxis("Horizontal") != 0)
        {
            SetState(PlayerState.walk);
            return;
        }
        else if(Input.GetButtonDown("Jump"))
        {
            SetState(PlayerState.jump);
            return;
        }
        else if(Input.GetButtonDown("Dash") && m_DashCDCurr <= 0)
        {
            SetState(PlayerState.dash);
            return;
        }
    }

    private void WalkState()
    {
        transform.Translate((Input.GetAxis("Horizontal") * Time.deltaTime * WALK_SPEED), 0, 0);


        if (!m_IsGrounded)
        {
            SetState(PlayerState.air);
            return;
        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            SetState(PlayerState.idle);
            return;
        }
        else if (Input.GetButtonDown("Jump"))
        {
            SetState(PlayerState.jump);
            return;
        }
        else if (Input.GetButtonDown("Dash") && m_DashCDCurr <= 0)
        {
            SetState(PlayerState.dash);
            return;
        }
    }

    private void DashState()
    {
        if (m_IsGrounded)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                SetState(PlayerState.walk);
                return;
            }

            SetState(PlayerState.idle);
            return;
        }
        else
        {
            SetState(PlayerState.air);
            return;
        }
    }

    private void AirState()
    {
        transform.Translate((Input.GetAxis("Horizontal") * Time.deltaTime * WALK_SPEED), 0, 0);

        //check if landed
        if(m_IsGrounded)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                SetState(PlayerState.walk);
                return;
            }

            SetState(PlayerState.idle);
            return;
        }
        else if (Input.GetButtonDown("Dash") && m_DashCDCurr <= 0)
        {
            SetState(PlayerState.dash);
            return;
        }
    }

    private void JumpState()
    {
        SetState(PlayerState.air);
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + m_GroundCheckTransform, new Vector3(m_GroundCheckWidth, m_GroundCheckHeight, 0));

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3((m_FacingRight) ? 1 : -1, 0, 0));
    }
}
