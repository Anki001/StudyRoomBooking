import { Component, OnInit } from '@angular/core';

import { RoomService } from 'src/app/services/room.service';

@Component({
  selector: 'app-room-screen',
  templateUrl: './room-screen.component.html',
  styleUrls: ['./room-screen.component.css']
})
export class RoomScreenComponent implements OnInit{

  rooms: any[] = [];

  constructor(private roomService:RoomService) {  
  }
  ngOnInit(): void {
    this.getRooms()
  }
  
getRooms(){
  this.roomService.getRoomsdATA().subscribe(
    (data) => {
      this.rooms = data.rooms;
    },
    (error) => {
      console.error('Error fetching rooms', error);
    }
  );
}
}
