import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { environment } from '../environments/environment';
import { BookingDetails } from '../model/bookingdetails';
import { BookingConfirmationRepository } from './booking-confirmation.repository';

fdescribe('BookingConfirmationRepository', () => {
    let service: BookingConfirmationRepository;
    let httpMock: HttpTestingController;

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [HttpClientTestingModule],
            providers: [BookingConfirmationRepository]
        });

        service = TestBed.inject(BookingConfirmationRepository);
        httpMock = TestBed.inject(HttpTestingController);
    });

    afterEach(() => {
        httpMock.verify();  // Ensure that no requests are outstanding
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });

    it('should fetch booking details by ID', () => {
        const mockBookingDetails: BookingDetails = {
          bookingId: 1,firstName:"rakesh",lastName:"pernati",email:"rakesh@gmail.com",date:new Date()
        };

        const bookingId = 1;

        service.getBookingDetailsById(bookingId).subscribe((data: any) => {
            expect(data).toEqual(mockBookingDetails);
        });

        const req = httpMock.expectOne(`${environment.url}/BookingConfirmation/${bookingId}`);
        expect(req.request.method).toBe('GET');
        req.flush(mockBookingDetails);
    });
});
