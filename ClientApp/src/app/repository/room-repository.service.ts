import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class RoomRepositoryService {

  
  baseUrl = environment.url

  constructor(private http: HttpClient,) { }

  getRooms():Observable<any>{
     console.log("Repository Call for Getting Rooms");
    return this.http.get(`${this.baseUrl}/api/Room/GetAllRooms`);
  }
  
}
