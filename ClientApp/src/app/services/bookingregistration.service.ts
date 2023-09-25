import { Injectable } from '@angular/core';
import { FormGroup,FormBuilder, Validators ,FormControl} from '@angular/forms';
import { BookingregistrationRepositoryService } from '../repositories/bookingregistration-repository.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class BookingregistrationService {
  registrationForm?: FormGroup;
  constructor(private repository:BookingregistrationRepositoryService,private route:Router) {

   }
    //OnSubmit
    SubmitForm(){
      if(this.registrationForm?.invalid){
        console.log('Registration form is invalid or null...............');
        return;
      }
      if(this.registrationForm?.valid){
        this.repository.bookingRegister(this.registrationForm.value)
        .subscribe(result=>{
          if(result==null){
            console.log('Registration form is invalid or null');
          }else{
            this.route.navigateByUrl('/bookingconfirmation');
          }
        });
      }
      else
      alert("Another Problem");
    }
}
