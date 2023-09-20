import { Injectable } from '@angular/core';
import { RoomRepositoryService } from '../repository/room-repository.service';
import { Room } from '../model/room';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  rooms:Room[]=[];

  constructor(private roomRepository: RoomRepositoryService) {
    this.fetchRooms();
   }

   private fetchRooms() {
    this.roomRepository.getRooms().pipe(
      catchError(error => {
        console.error('Error fetching rooms');
        return [];
      })
    ).subscribe(res => {
      this.rooms = res.rooms;
    });
  }

  getRooms(){
    return this.rooms;
  }
}
