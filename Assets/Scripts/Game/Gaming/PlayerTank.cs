using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTank : TankBaseObj
{
    public WeaponObj weaponObj;
    public Transform pao;
    private void Start()
    {
       //Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        //前后位移
        this.transform.Translate(Input.GetAxis("Vertical") * Vector3.forward*movespeed*Time.deltaTime);
        //坦克左右旋转
        this.transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * roundspeed*Time.deltaTime);
        //炮台左右旋转
        tankhead.transform.Rotate(Input.GetAxis("Mouse X")*Vector3.up*headroundspeed*Time.deltaTime);
        if(Input.GetMouseButtonDown(0))
        {
            fire();
        }
    }
    public override void fire()
    {
        weaponObj.fire();
    }
    public override void die()
    {
        Time.timeScale = 0;
        LosePanel.ptr.ShowMe();
    }
    public override void hurt(TankBaseObj other)
    {
        base.hurt(other);
        GameMainPanel.Instance.updatehp(maxhp, hp);
    }
    //更改武器
    public void ChangeWeapon(WeaponObj weaponObj1)
    {
        if(weaponObj != null)
        {
            Destroy(weaponObj.gameObject);
        }
        WeaponObj obj1=Instantiate(weaponObj1,pao,false);
        weaponObj=obj1;
        weaponObj.setfather(this);
    }
}
