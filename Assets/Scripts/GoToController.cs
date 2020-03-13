using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToController : MonoBehaviour
{
    [SerializeField] List<Transform> _waitpoints;
	int _next = 0;
	NavMeshAgent _agent;

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
		if (_agent.destination == null || Vector3.Distance(transform.position, _waitpoints[_next].position) < 0.3) {
			_agent.destination = _waitpoints[_next].position;
			_next++;

			if (_next > _waitpoints.Count-1) {
				_next = 0;

				Debug.Log("Go back to First one");
			}
		}
    }
}
