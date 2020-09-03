using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipIndicatorGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject m_motherShipIndicator;
    [SerializeField]
    private LayerMask m_collideableLayerMask;
    [SerializeField]
    private Transform m_playerShipTransform;

    private void LateUpdate()
    {
        if (m_playerShipTransform == null)
            return;

        float _rayDistance = Mathf.Infinity;
        
        Vector3 _directionVectorToPlayerFromMotherShip = m_playerShipTransform.position - this.transform.position;
        
        RaycastHit2D _hitColliderInformation = Physics2D.Raycast(this.transform.position, _directionVectorToPlayerFromMotherShip, _rayDistance, m_collideableLayerMask);
        
        if (_hitColliderInformation.collider != null)
        {
            Debug.Log("We hit " + _hitColliderInformation.collider.name);
            m_motherShipIndicator.SetActive(true);
            m_motherShipIndicator.transform.position = _hitColliderInformation.point;
        }
        else
        {
            m_motherShipIndicator.SetActive(false);
        }
        Debug.DrawRay(this.transform.position, _directionVectorToPlayerFromMotherShip);
    }
}
