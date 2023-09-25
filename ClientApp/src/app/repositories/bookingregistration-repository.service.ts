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

// bookingRegister(data:any){
//   console.log(data + "from Booking registration repository");
//   return this.http.post(`${this.baseUrl}/api/BookingRegistration/RoomBooking`,data);
// }
bookingRegister(bookingDetails: any): Observable<number> {
  return this.http.post<number>(`${this.baseUrl}/api/bookingregistration`, bookingDetails);
}

}
