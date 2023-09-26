import { Component, OnInit } from '@angular/core';
import { BookingDetails } from 'src/app/model/bookingDetails';
import { RoomBookingDetailsService } from 'src/app/services/room-booking-details.service';

@Component({
  selector: 'app-room-booking-details',
  templateUrl: './room-booking-details.component.html',
  styleUrls: ['./room-booking-details.component.css']
})
export class RoomBookingDetailsComponent implements OnInit {
  data: any
  constructor(private bookingDetails: RoomBookingDetailsService) {
    this.getAllDetails()
  }
  ngOnInit(): void {
    
  }
   getAllDetails() {
     console.log("Component Called");
     this.bookingDetails.getAllBookings().subscribe(res => {
       console.log(res);
       return this.data = res
     })
   }
}
