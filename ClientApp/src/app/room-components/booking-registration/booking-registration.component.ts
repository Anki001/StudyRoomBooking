import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BookingConfirmationService } from 'src/app/services/booking-confirmation.service';
import { BookingregistrationService } from 'src/app/services/bookingregistration.service';

@Component({
  selector: 'app-booking-registration',
  templateUrl: './booking-registration.component.html',
  styleUrls: ['./booking-registration.component.css']
})
export class BookingRegistrationComponent {
  registrationForm: FormGroup;

  constructor(private formBuilder: FormBuilder,private route: Router,private bookingRegistarionService:BookingregistrationService,private bookingConfirmation:BookingConfirmationService) {
    this.registrationForm = this.formBuilder.group({
      firstname: ['', [Validators.required, Validators.pattern(/^[A-Za-z]+$/), Validators.minLength(3)]],
      lastname: ['', [Validators.required, Validators.pattern(/^[A-Za-z]+$/),Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email,Validators.pattern(/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/)]],
      date: ['', [Validators.required, this.notPreviousDay.bind(this)]],
    });
   }
   notPreviousDay(control: FormControl): { [key: string]: boolean } | null {
    const currentDate = new Date();
    currentDate.setHours(0, 0, 0, 0);

    const selectedDate = new Date(control.value);
    selectedDate.setHours(0, 0, 0, 0);

    if (selectedDate < currentDate) {
      return { previousDay: true };
    }
    return null;
  }
  SubmitForm() {
    if (this.registrationForm?.invalid) {
      return;
    }

    if (this.registrationForm?.valid) {
      console.log('Form is valid. Submitting data...');
      this.bookingRegistarionService.bookingRegister(this.registrationForm.value)
        .subscribe(
          result => {
            if (result === null) {
              alert('Registration form is invalid or null');
            } else {
              this.bookingConfirmation.bookingId=result;
              this.route.navigate([`/bookingconfirmation`]);
              this.registrationForm.reset({}, { emitEvent: false });
            }
          },
          error => {
            if (error.status === 404) {
              alert('StudyRoom is Unavailable');
            } else {
              alert('An error occurred while processing the request');
            }
          });
    } else {
      alert('Another Problem');
    }
  }
}
