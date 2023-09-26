import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ApiServiceService } from './api-service.service';
import { ApiConstants } from '../constants/api-constants';
import { Room } from 'src/app/model/room';
import { BookingDetails } from 'src/app/model/bookingdetails';

fdescribe('ApiServiceService', () => {
  let service: ApiServiceService;
  let httpTestingController:HttpTestingController
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers:[
        HttpClientTestingModule
      ]
    });
    service = TestBed.inject(ApiServiceService);
    httpTestingController=TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should retrieve all booking details',()=>{
    const mockRoom:Room={ id: 1, name: 'Room 1',roomNumber:'A101',isAvailable:false }
        const mockBookingDetails: BookingDetails = { bookingId: 1,firstName:"rakesh",lastName:"pernati",email:"rakesh@gmail.com",date:new Date(),studyRoom:mockRoom};
    service.GetById(ApiConstants.GET_BOOKING_CONFIRMATION_ID,1).subscribe(details=>{
        expect(details.bookingDetails).toEqual(mockBookingDetails)
    })
    const req=httpTestingController.expectOne('https://localhost:7297/api/BookingConfirmation/1')
    req.request.method("Get");
  
  })

  
});
