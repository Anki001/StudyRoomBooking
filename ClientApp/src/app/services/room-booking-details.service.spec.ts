import { TestBed } from '@angular/core/testing';

import { RoomBookingDetailsService } from './room-booking-details.service';

describe('RoomBookingDetailsService', () => {
  let service: RoomBookingDetailsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RoomBookingDetailsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
