import { Component } from '@angular/core';
import { BookingDetails } from 'src/app/model/bookingDetails';
import { RoomBookingDetailsService } from 'src/app/services/room-booking-details.service';

@Component({
  selector: 'app-room-booking-details',
  templateUrl: './room-booking-details.component.html',
  styleUrls: ['./room-booking-details.component.css']
})
export class RoomBookingDetailsComponent {
  data:any
constructor(private bookingDetails:RoomBookingDetailsService) {
  // this.getAllDetails()
  this.getAll()
}

  getAllDetails(){
    console.log("Component Called");
  this.bookingDetails.getData().subscribe(res=>{
    console.log(res);
   return this.data = res
   })
  }

  getAll(){
    this.data= this.bookingDetails.getAllRoomDetails()
  }
}
