import { ComponentFixture, TestBed, async } from '@angular/core/testing';
import { RoomService } from 'src/app/services/room.service';
import { RoomScreenComponent } from './room-screen.component';
describe('RoomScreenComponent', () => {
  let component: RoomScreenComponent;
  let fixture: ComponentFixture<RoomScreenComponent>;
  let roomService: jasmine.SpyObj<RoomService>;

  beforeEach(async(() => {
    const roomServiceSpy = jasmine.createSpyObj('RoomService', ['getRooms']);

    TestBed.configureTestingModule({
      declarations: [RoomScreenComponent],
      providers: [{ provide: RoomService, useValue: roomServiceSpy }]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RoomScreenComponent);
    component = fixture.componentInstance;
    roomService = TestBed.inject(RoomService) as jasmine.SpyObj<RoomService>;
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call roomService.getRooms when getRooms is called', () => {
    const mockRooms = [{ id: 1, name: 'Room 1',roomNumber:'A101',isAvailable:true  }, { id: 2, name: 'Room 2',roomNumber:'B746',isAvailable:true  }];

    roomService.getRooms.and.returnValue(mockRooms);

    component.getRooms();

    expect(roomService.getRooms).toHaveBeenCalled();
  });

});


