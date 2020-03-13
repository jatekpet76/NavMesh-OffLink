using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToController : MonoBehaviour, IAgentInfo
{
    [SerializeField] List<GameObject> _waitpoints;
	GameObject _waitpoint;
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
		if (_waitpoint == null) {
			_waitpoint = _waitpoints[_next];
			_agent.destination = _waitpoint.transform.position;

			Debug.Log(gameObject.name + " Set the first destination");
		} else {
			Debug.Log(gameObject.name + " Has destination " + _agent.destination);
		}

		var distance = Vector3.Distance(transform.position, _waitpoint.transform.position);

		if (distance < 0.3) {
			_next++;
			_waitpoint = _waitpoints[_next];
			_agent.destination = _waitpoint.transform.position;

			Debug.Log(gameObject.name + " Set the next destination: " + _next);

			if (_next > _waitpoints.Count-1) {
				_next = 0;

				Debug.Log(gameObject.name + " Go back to First one");
			}
		} else {
			Debug.Log(gameObject.name + " Far from destination "+_agent.hasPath);
		}

		_info = string.Format("{0} to {1} : {2}m - {3} - {4}", gameObject.name, _waitpoint.name, distance, _agent.hasPath, _agent.destination.ToString("F3"));
    }
}
