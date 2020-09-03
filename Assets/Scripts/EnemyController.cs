using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float m_movementSpeed = 0.3f;
    [SerializeField] private float m_idleDragSpeed = 0.5f;
    [SerializeField] private float m_followIntervalInSeconds = 2f;
    [SerializeField] private Transform m_targetTransformPlayerShip;
    //[Header("Effects")]
    //[SerializeField] private GameObject m_boosterEffect;

    float m_xAxisMovementValue, m_yAxisMovementValue;
    float m_elapsedTime = 0f;
    Rigidbody2D m_selfRigibody;
    shootController m_shootingAblities;

    private void Start()
    {
        m_selfRigibody = GetComponent<Rigidbody2D>();
        m_shootingAblities = GetComponentInChildren<shootController>();
    }

    private void Update()
    {
        Shooting();
    }

    private void LateUpdate()
    {
        FollowPlayerShip();
    }

    private void FollowPlayerShip()
    {
        Vector3 _targetDirectionFromSelf = m_targetTransformPlayerShip.position - this.transform.position;
        
        m_selfRigibody.velocity = _targetDirectionFromSelf * Random.Range(m_movementSpeed - 0.2f, m_movementSpeed + 0.2f);

        float _thetaInDirectionOfPlayerShip = Mathf.Atan2(_targetDirectionFromSelf.y, _targetDirectionFromSelf.x);
        float _degreeConvertedFromTheta = _thetaInDirectionOfPlayerShip * Mathf.Rad2Deg + 0f;
        this.transform.rotation = Quaternion.Euler(0f, 0f, _degreeConvertedFromTheta + 270f);
    }

    private void Shooting()
    {
        m_elapsedTime += Time.deltaTime;

        if (m_elapsedTime > 2f)
        {
            m_shootingAblities.Fire();
            m_elapsedTime = 0;
        }
    }
}
