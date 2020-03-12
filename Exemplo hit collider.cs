else
        {
            inWater = true;
 
            //rigidbody.isKinematic = false;
            chMotor.movement.gravity = 2;
            chMotor.movement.maxFallSpeed = 4;
            chMotor.movement.maxForwardSpeed = 4;
            chMotor.movement.maxSidewaysSpeed = 4;
 
            if(controller.velocity.magnitude > 0 && Input.GetKey(KeyCode.LeftShift))
                {
                chMotor.movement.maxForwardSpeed = 7;
                chMotor.movement.maxSidewaysSpeed = 7;
                staminaInfo.staminaBar.fillAmount -= 0.001f;
                }
                else
                {
                    chMotor.movement.maxForwardSpeed = 4;
                    chMotor.movement.maxSidewaysSpeed = 4;
                }
 
            if(Input.GetKey("q"))
            {
                locked = false;
                rigidbody.AddForce(Vector3.down * 5, ForceMode.VelocityChange);
 
                if(Physics.Raycast(transform.position, down, out hit,3))
                   {
                        if(hit.collider.gameObject.tag == "ground")
                        {
                        rigidbody.isKinematic = true;
                        }
                       
                    }
            }
            else
            {
                rigidbody.isKinematic = false;  
            }
 
   
 
        }
 
        if(inWater == true)
        {
 
            chMotor.jumping.enabled = false;
            if(transform.position.y < 45.6)
            {
                if(Input.GetKey("space"))
                {
                rigidbody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
                }
            }
 
            if(!locked && transform.position.y > 45.6f)
            {
                locked = true;
            }
 
            if(locked)
            {
                transform.position = new Vector3(transform.position.x, 45.6f, transform.position.z);
            }
               
 
        }