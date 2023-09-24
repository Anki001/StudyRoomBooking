import { Component, OnInit } from '@angular/core';
import { BookingDetails } from 'src/app/model/bookingdetails';
import { ActivatedRoute } from '@angular/router';
import { StudyRoomService } from 'src/app/services/studyroom.service';
import { bookingDetailsArray } from 'src/assets/data/dummy-booking-details';
import { BookingReponse } from 'src/app/model/bookingresponse';

@Component({
  selector: 'app-booking-confirmation-screen',
  templateUrl: './booking-confirmation-screen.component.html',
  styleUrls: ['./booking-confirmation-screen.component.css']
})
export class BookingConfirmationScreenComponent implements OnInit{

 public bookingResponse=new BookingReponse;
  public bookingId: number  = -1;
  constructor(private route: ActivatedRoute, public service: StudyRoomService) {
    
  }
  ngOnInit(): void {
    const id=this.route.snapshot.paramMap.get('id')
    if(id!=null){
        this.bookingId=parseInt(id)
    }
   
    this.getBookingDetails()
    
  }

  getBookingDetails(){
    this.service.getBookingDetails(this.bookingId).subscribe(data=>{
      Object.assign(this.bookingResponse,data)
    })
  }
 
  
}

