using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToController : MonoBehaviour, IAgentInfo
{
    [SerializeField] List<GameObject> _waitpoints;
	int _next = 0;
	NavMeshAgent _agent;

	string _info = "NONE";

	public string GetInfo() {
		return _info;
	}

    // Start is called before the first frame update
    void Start()
    {
		_agent = GetComponent<NavMeshAgent>();

		StartCoroutine(WalkingBetweenWaitpoints());
    }

	IEnumerator WalkingBetweenWaitpoints() {
		while (true) {
			yield return new WaitForSeconds(3);

			MoveTo();
		}
	}

    // Update is called once per frame
    void Update()
    {

    }

    void MoveTo()
    {
		if (_agent.destination == null) {
			_agent.destination = _waitpoints[_next].transform.position;

			Debug.Log("Set the first destination");
		}

		if (Vector3.Distance(transform.position, _waitpoints[_next].transform.position) < 0.3) {
			_agent.destination = _waitpoints[_next].transform.position;
			_next++;

			Debug.Log("Set the next destination: " + _next);

			if (_next > _waitpoints.Count-1) {
				_next = 0;

				Debug.Log("Go back to First one");
			}
		}

		_info = string.Format("{0} to {1}", gameObject.name, _waitpoints[_next].name);
    }
}
