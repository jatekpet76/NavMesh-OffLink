using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseInputController : MonoBehaviour, IAgentInfo
{
    NavMeshAgent _agent;
    string _info;

    public string GetInfo()
    {
        return _info;
    }

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)) {
                _info = string.Format("{0} to {1}", gameObject.name, hit.transform.gameObject.name);

                _agent.destination = hit.point;
            }
        }
    }
}
