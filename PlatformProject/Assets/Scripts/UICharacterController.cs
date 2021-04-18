using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterController : MonoBehaviour
{
    [SerializeField]
    PressedButton leftButton;
    [SerializeField]
    PressedButton rightButton;
    [SerializeField]
    Button upButton;
    [SerializeField]
    Button fireButton;

    public PressedButton LeftButton{get{return leftButton;}}
    public PressedButton RightButton{get{return rightButton;}}
    public Button UpButton{get{return upButton;}}
    public Button FireButton{get{return fireButton;}}
    void Start()
    {
        PlayerControllerScript.instance.InitButtonController(this);
    }

}
