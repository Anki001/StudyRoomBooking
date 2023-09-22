import { TestBed } from '@angular/core/testing';

import { BookingregistrationService } from './bookingregistration.service';

describe('BookingregistrationService', () => {
  let service: BookingregistrationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BookingregistrationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
