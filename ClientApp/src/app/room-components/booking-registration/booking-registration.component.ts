import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { Component } from '@angular/core';
import { BookingregistrationService } from 'src/app/services/bookingregistration.service';
import { Router } from '@angular/router';
import { BookingregistrationRepositoryService } from 'src/app/repositories/bookingregistration-repository.service';

@Component({
  selector: 'app-booking-registration',
  templateUrl: './booking-registration.component.html',
  styleUrls: ['./booking-registration.component.css']
})
export class BookingRegistrationComponent {

  registrationForm: FormGroup;
  constructor(private formBuilder: FormBuilder,private route: Router,private service:BookingregistrationService) {
    this.registrationForm = this.formBuilder.group({
      firstname: ['', [Validators.required, Validators.pattern(/^[A-Za-z]+$/)]],
      lastname: ['', [Validators.required, Validators.pattern(/^[A-Za-z]+$/)]],
      email: ['', [Validators.required, Validators.email]],
      date: ['', [Validators.required, this.notPreviousDay.bind(this)]],
    });
   }
   notPreviousDay(control: FormControl): { [key: string]: boolean } | null {
    const currentDate = new Date();
    const selectedDate = new Date(control.value);

    if (selectedDate < currentDate) {
      return { previousDay: true };
    }
    return null;
  }
    //OnSubmit
    SubmitForm(){
     this.service.SubmitForm();
    }
}
