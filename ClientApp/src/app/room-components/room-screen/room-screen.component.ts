import { Component, OnInit } from '@angular/core';

import { RoomService } from 'src/app/services/room.service';
import { GlobalConstants } from 'src/shared/constants/global-constants';

@Component({
  selector: 'app-room-screen',
  templateUrl: './room-screen.component.html',
  styleUrls: ['./room-screen.component.css']
})
export class RoomScreenComponent implements OnInit{

  rooms: any[] = [];

  result:any []=[]
  constructor(private roomService:RoomService) {  
  }
  ngOnInit(): void {
    this.getRooms()
    this.getBookingDetailsById()
  }
  
getRooms(){
  this.roomService.getRooms().subscribe(
    (data) => {
      this.rooms = data.rooms;
    },
    (error) => {
      console.error(GlobalConstants.GENERIC_ERROR, error);
      this.rooms = []
    }
  );
}

getBookingDetailsById(){
  this.roomService.getBookingDetailsById(1).subscribe(res=>{
this.result = res
  })
}
}
