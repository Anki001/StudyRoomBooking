import { Injectable } from '@angular/core';
import { ApiServiceService } from 'src/shared/services/api-service.service';

import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class RoomBookingDetailsService {

  constructor(private apiService: ApiServiceService,private http:HttpClient ) { }

  getAllRoomDetails(){
    
    return  {
      "bookingDetails": [
        {
          "bookingId": 1,
          "firstName": "Rakesh",
          "lastName": "Pernati",
          "email": "rakesh@gmail.com",
          "date": "2023-09-19T14:51:10.097",
          "studyRoom": {
            "id": 1,
            "name": "Earth",
            "roomNumber": "A101",
            "isAvailable": false
          }
        },
        {
          "bookingId": 2,
          "firstName": "siva",
          "lastName": "kamireddy",
          "email": "siva@gmail.com",
          "date": "2023-09-20T04:37:59.019",
          "studyRoom": {
            "id": 2,
            "name": "Neptune",
            "roomNumber": "A102",
            "isAvailable": false
          }
        },
        {
          "bookingId": 3,
          "firstName": "ankush",
          "lastName": "chawarasa",
          "email": "ankush@gmail.com",
          "date": "2023-09-20T10:24:49.078",
          "studyRoom": {
            "id": 3,
            "name": "Mercury",
            "roomNumber": "A103",
            "isAvailable": false
          }
        },
        {
          "bookingId": 4,
          "firstName": "ankush",
          "lastName": "chawa",
          "email": "ankush@gmail.com",
          "date": "2023-09-20T10:24:49.078",
          "studyRoom": {
            "id": 4,
            "name": "Saturn",
            "roomNumber": "A201",
            "isAvailable": false
          }
        },
        {
          "bookingId": 5,
          "firstName": "rakesh",
          "lastName": "pernati",
          "email": "rakesh@gmail.com",
          "date": "2023-09-20T14:35:37.468",
          "studyRoom": {
            "id": 5,
            "name": "Uranus",
            "roomNumber": "A202",
            "isAvailable": false
          }
        },
        {
          "bookingId": 6,
          "firstName": "Saikumar",
          "lastName": "kuncha",
          "email": "sai@gmail.com",
          "date": "2023-09-20T14:43:59.166",
          "studyRoom": {
            "id": 6,
            "name": "Mars",
            "roomNumber": "A203",
            "isAvailable": false
          }
        },
        {
          "bookingId": 7,
          "firstName": "satyam",
          "lastName": "mudili",
          "email": "satyam@gmail.com",
          "date": "2023-09-21T06:11:44.154",
          "studyRoom": {
            "id": 7,
            "name": "Venus",
            "roomNumber": "A301",
            "isAvailable": false
          }
        },
        {
          "bookingId": 8,
          "firstName": "chandra",
          "lastName": "mudili",
          "email": "chandra@gmail.com",
          "date": "2023-09-21T06:11:44.154",
          "studyRoom": {
            "id": 8,
            "name": "Jupiter",
            "roomNumber": "A302",
            "isAvailable": false
          }
        }
      ]
    }
  }

  getData() :Observable<any>{
    return this.http.get('../../app/data.json');
  }
}
