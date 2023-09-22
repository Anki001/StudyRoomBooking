import { Component } from '@angular/core';
import { BookingDetails } from 'src/app/model/bookingdetails';
import { ActivatedRoute } from '@angular/router';
import { BookingConfirmationService } from 'src/app/services/booking-confirmation.service';
import { bookingDetailsArray } from 'src/assets/data/dummy-booking-details';

@Component({
  selector: 'app-booking-confirmation-screen',
  templateUrl: './booking-confirmation-screen.component.html',
  styleUrls: ['./booking-confirmation-screen.component.css']
})
export class BookingConfirmationScreenComponent {

  public bookingDetails = new BookingDetails();

  public bookingId: number  = -1;

  constructor(private route: ActivatedRoute, public service: BookingConfirmationService) {
   
      const id=this.route.snapshot.paramMap.get('id')
      if(id!=null){
        this.bookingId=parseInt(id)
      }
    
    
    this.getdummydata(this.bookingId)

  }
 
  getdummydata(bookingId:number){
    const booking= bookingDetailsArray.filter(data=>data.bookingId==bookingId)
    this.bookingDetails=booking[0]
    Object.assign(this.bookingDetails,booking)
    console.log(booking)
  }
}

