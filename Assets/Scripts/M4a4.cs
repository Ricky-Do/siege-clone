using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4a4 : MonoBehaviour
{
    private int maxAmmo = 30;
    private int currentAmmo;
    private float fireRate = 0.3f;
    private float nextFireTime;
    [SerializeField] Transform playerCamera;
    [SerializeField] Transform impactMarker;

    private void Start(){
        currentAmmo = maxAmmo;
    }

    private void Update(){
        if(Input.GetKey(KeyCode.Mouse0) && Time.time >= nextFireTime){
            Shoot();
        }
        if(Input.GetKeyDown(KeyCode.R)){
            Reload();
        }
    }
    
    private void Shoot(){
        if(currentAmmo > 0){
            //Debug.Log("Shooting m4a4");
            
            if(Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hit)){
                Instantiate(impactMarker, hit.point, Quaternion.identity);
            }
            currentAmmo--;
            nextFireTime = Time.time + fireRate; // Set the next time the gun can fire
            if(currentAmmo <= 0){
                //Debug.Log("No ammo. Need to reload.");
            }
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0) && currentAmmo <= 0){
            //Debug.Log("No ammo. Need to reload.");
        }
    }

    private void Reload(){
        if(currentAmmo == maxAmmo){
            //Debug.Log("Ammo full. Can't reload");
        }
        else{
            //Debug.Log("Reloading m4a4");
            currentAmmo = maxAmmo;
            //Debug.Log("Reloaded");
        }
    }
}
