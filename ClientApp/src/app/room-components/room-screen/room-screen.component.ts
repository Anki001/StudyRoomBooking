import { Component } from '@angular/core';
import { RoomService } from 'src/app/services/room.service';

@Component({
  selector: 'app-room-screen',
  templateUrl: './room-screen.component.html',
  styleUrls: ['./room-screen.component.css']
})
export class RoomScreenComponent {


  constructor(private roomService:RoomService) {  
  }
  getRooms(){
   return this.roomService.getRooms()
  }

}
