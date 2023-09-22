import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { RoomRepositoryService } from './room-repository.service';
import { environment } from 'src/environments/environment';

describe('RoomRepositoryService', () => {
  let service: RoomRepositoryService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [RoomRepositoryService],
    });
    service = TestBed.inject(RoomRepositoryService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should retrieve rooms', () => {
    const mockRooms = [{ id: 1, name: 'Room 1',roomNumber:'A101',isAvailable:true  }, 
    { id: 2, name: 'Room 2',roomNumber:'B746',isAvailable:true  }];

    service.getRooms().subscribe((rooms) => {
      expect(rooms).toEqual(mockRooms);
    });

    const req = httpTestingController.expectOne(`${environment.url}/api/Room/GetAllRooms`);
    expect(req.request.method).toBe('GET');

    req.flush(mockRooms);
  });
});

