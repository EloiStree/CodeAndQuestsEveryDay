using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OVRInputEvent : MonoBehaviour
{
    public InputTrackedBool[] m_listenedBoolInput;

    [System.Serializable]
    public struct InputTrackedBool
    {
        public string m_description ;
        public OVRInput.Button m_button;
        public OVRInput.Controller m_controller;
        public OnOVRInputBool m_onChanged;
        public bool m_current;
        public void SetValue(bool value) {
            if (m_current != value)
            {
                m_onChanged.Invoke(value);
            }
        }

    }
 
    void Update()
    {
        for (int i = 0; i < m_listenedBoolInput. Length; i++)
        {
            InputTrackedBool inp = m_listenedBoolInput[i];
            inp.SetValue(OVRInput.Get(inp.m_button, inp.m_controller));
        }
    }
}
[System.Serializable]
public class OnOVRInputBool :UnityEvent<bool> {

}
