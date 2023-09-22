import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BookingregistrationRepositoryService {
  baseUrl = environment.url;
  constructor(private http:HttpClient) { }

bookingRegister(data:any){
  console.log(data + "from Booking registration repository");
  return this.http.post(`${this.baseUrl}/api/bookingregister`,data);
}

}
