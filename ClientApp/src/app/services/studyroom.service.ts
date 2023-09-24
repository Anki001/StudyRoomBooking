import { Injectable } from '@angular/core';
import {  StudyRoomRepository } from '../repository/studyroom.repository';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { BookingDetails } from '../model/bookingdetails';
import { BookingReponse } from '../model/bookingresponse';

@Injectable({
  providedIn: 'root'
})
export class StudyRoomService {
 
  constructor(private studyRoomRepository:StudyRoomRepository) {
   }

public getBookingDetails(bookingId:number):Observable<BookingReponse>{
   return this.studyRoomRepository.getBookingDetailsById(bookingId)
}
  
}
