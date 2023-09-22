import { TestBed } from '@angular/core/testing';
import { RoomService } from './room.service';
import { RoomRepositoryService } from '../repository/room-repository.service';
import { of } from 'rxjs';

describe('RoomService', () => {
  let roomService: RoomService;
  let roomRepositoryService: jasmine.SpyObj<RoomRepositoryService>;

  beforeEach(() => {
    const spy = jasmine.createSpyObj('RoomRepositoryService', ['getRooms']);
    TestBed.configureTestingModule({
      providers: [
        RoomService,
        { provide: RoomRepositoryService, useValue: spy }
      ]
    });
    roomService = TestBed.inject(RoomService);
    roomRepositoryService = TestBed.inject(RoomRepositoryService) as jasmine.SpyObj<RoomRepositoryService>;
  });

  it('should be created', () => {
    expect(roomService).toBeTruthy();
  });


  it('should return rooms from the repository', () => {
    const mockRooms = [{ id: 1, name: 'Room 1',roomNumber:'A101',isAvailable:true  }, 
    { id: 2, name: 'Room 2',roomNumber:'B746',isAvailable:true  }];
     roomRepositoryService.getRooms.and.returnValue(of(mockRooms));

    roomService.getRoomsdATA().subscribe(rooms => {
      expect(rooms).toEqual(mockRooms);
    });

    expect(roomRepositoryService.getRooms).toHaveBeenCalled();
  });
});
