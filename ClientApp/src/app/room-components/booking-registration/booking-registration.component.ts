import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BookingregistrationService } from 'src/app/services/bookingregistration.service';

@Component({
  selector: 'app-booking-registration',
  templateUrl: './booking-registration.component.html',
  styleUrls: ['./booking-registration.component.css']
})
export class BookingRegistrationComponent {
  registrationForm: FormGroup;

  constructor(private formBuilder: FormBuilder,private route: Router,private bookingRegistarionService:BookingregistrationService) {
    this.registrationForm = this.formBuilder.group({
      firstname: ['', [Validators.required, Validators.pattern(/^[A-Za-z]+$/)]],
      lastname: ['', [Validators.required, Validators.pattern(/^[A-Za-z]+$/)]],
      email: ['', [Validators.required, Validators.email]],
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
    console.log('Submitting form...');
    if (this.registrationForm?.invalid) {
      console.log('Registration form is invalid or null');
      return;
    }

    if (this.registrationForm?.valid) {
      console.log('Form is valid. Submitting data...');
      this.bookingRegistarionService.bookingRegister(this.registrationForm.value)
        .subscribe(result => {
          console.log('Response from server:', result);

          if (result === null) {
            console.log('Registration form is invalid or null');
          } else {
            this.route.navigate([`/bookingconfirmation`,result]);

            // Clear the form fields
            this.registrationForm.reset({}, { emitEvent: false });
          }
        });
    } else {
      console.log('Another Problem');
      alert('Another Problem');
    }
  }
}
