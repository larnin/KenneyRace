using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour
{
    SubscriberList m_subscriberList = new SubscriberList();
    
    void Awake()
    {
        m_subscriberList.Add(new Event<CameraMoveEvent>.Subscriber(OnMove));
        m_subscriberList.Add(new Event<CameraMoveInstantEvent>.Subscriber(OnMoveInstant));
        m_subscriberList.Subscribe();
    }

    private void OnDestroy()
    {
        m_subscriberList.Unsubscribe();
    }

    void Update()
    {

    }

    void OnMove(CameraMoveEvent e)
    {
        OnMoveInstant(new CameraMoveInstantEvent(e.position, e.forward, e.up, e.cameraPosition, e.speed));
    }

    void OnMoveInstant(CameraMoveInstantEvent e)
    {
        transform.position = e.cameraPosition;

        Vector3 target = transform.position + e.forward;
        transform.LookAt(target, e.up);
    }
}
