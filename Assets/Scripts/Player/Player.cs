using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterMovement
{
    // direction to move towards
    private Vector2 moveDir;
    
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
        
        Move(moveDir);
    }
}
