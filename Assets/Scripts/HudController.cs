using System.Collections;
using System.Collections.Generic;
using System.Linq;   
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField] Text _agentTargets;
    IAgentInfo[] _goTos;
    
    // Start is called before the first frame update
    void Start()
    {
        _goTos = GameObject.FindObjectsOfType<MonoBehaviour>().OfType<IAgentInfo>().ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        _agentTargets.text = "";

        foreach (IAgentInfo goTo in _goTos) {
            _agentTargets.text += goTo.GetInfo() + "\n";
        }

    }
}
