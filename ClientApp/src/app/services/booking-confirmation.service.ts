import { Injectable } from '@angular/core';
import { BookingDetails } from '../model/bookingdetails';
import { BookingConfirmationRepository } from '../repositories/booking-confirmation.repository';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookingConfirmationService {
  public bookingDetails:BookingDetails=new BookingDetails();
  constructor(private bookingRepository:BookingConfirmationRepository) {

   }

public getBookingDetails(bookingId:number) :Observable<BookingDetails>{
   return this.bookingRepository.getBookingDetailsById(bookingId).pipe(
      catchError(error => {
        console.error('Error fetching rooms');
        return [];
      })
    )
  }
  
}
