import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BookingDetails } from '../model/bookingdetails';
import { environment } from '../environments/environment';
import { BookingReponse } from '../model/bookingresponse';

@Injectable({
  providedIn: 'root'
})
export class StudyRoomRepository {


  private baseUrl=environment.url
  constructor(private httpClient:HttpClient) { }

  getBookingDetailsById(bookingId:number):Observable<BookingReponse>{
      return this.httpClient.get(`${this.baseUrl}/BookingConfirmation/${bookingId}`)
  }
}
