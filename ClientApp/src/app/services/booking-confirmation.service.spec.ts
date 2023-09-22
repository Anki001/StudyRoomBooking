import { TestBed } from '@angular/core/testing';
import { of, throwError } from 'rxjs';
import { BookingConfirmationService } from './booking-confirmation.service';
import { BookingConfirmationRepository } from '../repositories/booking-confirmation.repository';
import { BookingDetails } from '../model/bookingdetails';

describe('BookingConfirmationService', () => {
    let service: BookingConfirmationService;
    let mockRepository: jasmine.SpyObj<BookingConfirmationRepository>;

    beforeEach(() => {
        mockRepository = jasmine.createSpyObj('BookingConfirmationRepository', ['getBookingDetailsById']);

        TestBed.configureTestingModule({
            providers: [
                BookingConfirmationService,
                { provide: BookingConfirmationRepository, useValue: mockRepository }
            ]
        });

        service = TestBed.inject(BookingConfirmationService);
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });

    it('should get booking details correctly', () => {
        const mockBookingDetails: BookingDetails = { bookingId: 1,firstName:"rakesh",lastName:"pernati",email:"rakesh@gmail.com",date:new Date()};
        mockRepository.getBookingDetailsById.and.returnValue(of(mockBookingDetails));

        service.getBookingDetails(1).subscribe(data => {
            expect(data).toEqual(mockBookingDetails);
        });

        expect(mockRepository.getBookingDetailsById).toHaveBeenCalledWith(1);
    });

    it('should handle errors without crashing', () => {
        mockRepository.getBookingDetailsById.and.returnValue(throwError('An error occurred'));

        spyOn(console, 'error');  // to avoid console errors during test execution

        service.getBookingDetails(1).subscribe(
            data => {
                return expect(data).toEqual(new BookingDetails);  // Expecting an empty array as defined in your catchError
            },
            error => {
                fail('We should not get here since errors are being caught.');
            }
        );

        expect(console.error).toHaveBeenCalledWith('Error fetching rooms');
    });
});
