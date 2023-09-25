import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookingregistrationRepositoryService {
  baseUrl = environment.url;
  constructor(private http:HttpClient) { }

bookingRegister(bookingDetails: any): Observable<number> {
  console.log('in repository'+bookingDetails)
  return this.http.post<number>(`${this.baseUrl}/api/bookingregistration/RoomBooking`, bookingDetails);
}

}
