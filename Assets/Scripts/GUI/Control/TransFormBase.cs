using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

//选择相对屏幕原点
public enum E_ScreenType
{
    up,
    down,
    left,
    right,
    center,
    left_up,
    right_up,
    left_down,
    right_down,
}

//选择相对按件原点
public enum E_ControlType
{
    up,
    down,
    left,
    right,
    center,
    left_up,
    right_up,
    left_down,
    right_down,
}

[System.Serializable]
public class TransFormBase
{
    //位置信息
    private Rect rect1=new Rect(0,0,100,100);
    //提供外部修改按件的宽高
    public float c_kuang;
    public float c_gao;
    //偏移原点的位置
    public int x_pianyi;
    public int y_pianyi;
    
    public E_ScreenType screen=E_ScreenType.center;
    public E_ControlType controlType=E_ControlType.center;
    //临时记录坐标位置
    private Vector2 vector;
    private void Cro()
    {
        switch (controlType)
        {
            case E_ControlType.up:
                vector.x= -c_kuang / 2;
                vector.y = 0;
                break;
            case E_ControlType.down:
                vector.x = -c_kuang / 2;
                vector.y = -c_gao;
                break;
            case E_ControlType.left:
                vector.x = 0;
                vector.y = -c_gao/2;
                break;
            case E_ControlType.right:
                vector.x = -c_kuang;
                vector.y = -c_gao/2;
                break;
            case E_ControlType.center:
                vector.x = -c_kuang / 2;
                vector.y = -c_gao / 2;
                break;
            case E_ControlType.left_up:
                vector.x = 0;
                vector.y = 0;
                break;
            case E_ControlType.right_up:
                vector.x = -c_kuang;
                vector.y = 0;
                break;
            case E_ControlType.left_down:
                vector.x = 0;
                vector.y = -c_gao;
                break;
            case E_ControlType.right_down:
                vector.x = -c_kuang;
                vector.y = -c_gao ;
                break;
            
        }
    }
    //按件位置屏幕自适应计算
    private void Scr()
    {
        switch (screen)
        {
            case E_ScreenType.up:
                rect1.x=Screen.width/2+vector.x+x_pianyi;
                rect1.y=vector.y+y_pianyi;
                break;
            case E_ScreenType.down:
                rect1.x = Screen.width / 2 + vector.x + x_pianyi;
                rect1.y = Screen.height+vector.y - y_pianyi;
                break;
            case E_ScreenType.left:
                rect1.x = vector.x + x_pianyi;
                rect1.y = Screen.height + vector.y + y_pianyi;
                break;
            case E_ScreenType.right:
                rect1.x = Screen.width + vector.x -x_pianyi;
                rect1.y = Screen.height/2 + vector.y + y_pianyi;
                break;
            case E_ScreenType.center:
                rect1.x = Screen.width/2 + vector.x + x_pianyi;
                rect1.y = Screen.height/2 + vector.y + y_pianyi;
                break;
            case E_ScreenType.left_up:
                rect1.x = vector.x + x_pianyi;
                rect1.y = vector.y + y_pianyi;
                break;
            case E_ScreenType.right_up:
                rect1.x = Screen.width + vector.x - x_pianyi;
                rect1.y = vector.y + y_pianyi;
                break;
            case E_ScreenType.left_down:
                rect1.x = vector.x + x_pianyi;
                rect1.y = Screen.height + vector.y - y_pianyi;
                break;
            case E_ScreenType.right_down:
                rect1.x = Screen.width + vector.x - x_pianyi;
                rect1.y = Screen.height + vector.y - y_pianyi;
                break;
        }
    }
    public Rect str
    {
        get
        {
            Cro();
            Scr();
            rect1.width = c_kuang;
            rect1.height = c_gao;
            return rect1;
        }
    }
}
