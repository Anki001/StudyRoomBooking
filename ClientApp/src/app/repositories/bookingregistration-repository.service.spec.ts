import { TestBed } from '@angular/core/testing';

import { BookingregistrationRepositoryService } from './bookingregistration-repository.service';

describe('BookingregistrationRepositoryService', () => {
  let service: BookingregistrationRepositoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BookingregistrationRepositoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
