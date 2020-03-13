using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseInputController : MonoBehaviour, IAgentInfo
{
    NavMeshAgent _agent;
    string _info;

    [SerializeField] GameObject _start;

    public string GetInfo()
    {
        return _info;
    }

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        
        if (_start != null) {
            _agent.destination = _start.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)) {
                var distance = Vector3.Distance(transform.position, hit.point);

                _info = string.Format("{0} to {1} : {2}m", gameObject.name, hit.transform.gameObject.name, distance);

                _agent.destination = hit.point;
            }
        }
    }
}
