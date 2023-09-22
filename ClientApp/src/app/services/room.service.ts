import { Injectable } from '@angular/core';
import { RoomRepositoryService } from '../repository/room-repository.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoomService {
  constructor(private apiService: RoomRepositoryService) {}
  getRoomsdATA(): Observable<any> {
    return this.apiService.getRooms();
  }
}
