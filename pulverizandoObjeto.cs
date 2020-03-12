 //The slice value to be assigned to the shader
 float Val_Slice=100;    
 
 void OnTriggerEnter (Collider other) 
 {
   if (other.gameObject.tag == "Player")
   {
     CC.SetActive(true);
     CCBad.SetActive (false);
     AudioSource.PlayClipAtPoint(pop, transform.position );
     AudioSource.PlayClipAtPoint(dialogue, transform.position );
   }
 }
 
 void OnTriggerEnter(Collider other)
 {
   if(other.gameObject.Tag=="Player")
   {
     //Start the FadeAndDestroy coroutine here
     StartCoroutine("FadeAndDestroy");
   }
 }
 
 IEnumerator FadeAndDestroy()
 {
   //Loop until slice value reaches zero
   while(Val_Slice>0.0f)
   {
     //Reduce slice value over time
     Val_Slice-=Time.deltatime;
 
     //Apply the slice value to shader(change the string "_SliceAmount" to ur shader property string)
     renderer.material.SetFloat("_SliceAmount",Val_Slice);
 
     //Use this line if you want to increase the delay in decrementing
     //yield return new WaitForSeconds(0.1f);
 
   }
 
   //Loop exited since value reached zero (perform post dissolve task here)
   CC.SetActive(false);
   CCBad.SetActive(true);
   Destroy(this.gameObject);
   AudioSource.PlayClipAtPoint(pop2,transform.position);
 }