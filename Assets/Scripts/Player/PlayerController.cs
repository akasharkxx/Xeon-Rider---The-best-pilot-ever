using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] Joystick m_joystick1;

    [Header("Movement")]
    [SerializeField] private float m_movSpeed = 10f;
    [SerializeField] private float m_dragSpeed = 0.5f;

    [Header("Effects")]
    [SerializeField] private GameObject m_boosterEffect;

    float m_xAxisMovementValueFromJoyStick, m_yAxisMovementValueFromJoyStick;
    Rigidbody2D m_playerRigibody;
    shootController m_playerShootingAbilities;
    float m_elapsedTime = 0f;

    private void Start()
    {
        m_playerRigibody = GetComponent<Rigidbody2D>();
        m_playerShootingAbilities = GetComponentInChildren<shootController>();
        m_boosterEffect.SetActive(false);
    }

    private void Update()
    {
        ProcessInput();
        m_elapsedTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_elapsedTime > 1f)
            {
                m_playerShootingAbilities.Fire();
                m_elapsedTime = 0f;
            }
        }
    }

    private void FixedUpdate()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float _xValueReceivedFromJoystick = m_joystick1.Direction.x;
        float _yValueReceivedFromJoystick = m_joystick1.Direction.y;
        
        //Calculating Theta For rotating the Player ship in direction of the Joystick
        float _thetaGeneratedInDirectionOfJoystickDirection = Mathf.Atan2(_yValueReceivedFromJoystick,_xValueReceivedFromJoystick);
        float _degreeConvertedFromThetaOfJoystick = _thetaGeneratedInDirectionOfJoystickDirection * Mathf.Rad2Deg + 0f;
        
        if(_xValueReceivedFromJoystick != 0 && _yValueReceivedFromJoystick != 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, (_degreeConvertedFromThetaOfJoystick + 270f));
        }
    }

    private void ProcessTranslation()
    {
        if(m_xAxisMovementValueFromJoyStick != 0 && m_yAxisMovementValueFromJoyStick != 0)
        {
            Vector2 _thrustGeneratedUsingJoystick = new Vector2(m_xAxisMovementValueFromJoyStick * m_movSpeed, m_yAxisMovementValueFromJoyStick * m_movSpeed);
            //rb.velocity = thrust;
            m_playerRigibody.AddForce(_thrustGeneratedUsingJoystick, ForceMode2D.Force);
            m_boosterEffect.SetActive(true);
        }
        else
        {
            //When Ship Idle Simulating Space drag
            m_playerRigibody.AddForce(new Vector2(m_dragSpeed, m_dragSpeed), ForceMode2D.Force);
            m_boosterEffect.SetActive(false);
        }
    }

    private void ProcessInput()
    {
        m_xAxisMovementValueFromJoyStick = m_joystick1.Horizontal;
        m_yAxisMovementValueFromJoyStick = m_joystick1.Vertical;
    }
}
