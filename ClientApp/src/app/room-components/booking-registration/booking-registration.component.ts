import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BookingConfirmationService } from 'src/app/services/booking-confirmation.service';

@Component({
  selector: 'app-booking-registration',
  templateUrl: './booking-registration.component.html',
  styleUrls: ['./booking-registration.component.css']
})
export class BookingRegistrationComponent {
    constructor(private service:BookingConfirmationService,private route:Router){
      
    }
    onclick(){
      this.service.bookingId=5;
      this.route.navigateByUrl("/bookingconfirmation")
    }
}
