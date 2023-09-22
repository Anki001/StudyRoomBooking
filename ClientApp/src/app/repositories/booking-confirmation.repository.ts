import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BookingDetails } from '../model/bookingdetails';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookingConfirmationRepository {


  private baseUrl=environment.url
  constructor(private httpClient:HttpClient) { }

  getBookingDetailsById(bookingId:number):Observable<BookingDetails>{
       return this.httpClient.get<BookingDetails>(`${this.baseUrl}/BookingConfirmation/${bookingId}`)
  }
}
