// import { ComponentFixture, TestBed } from '@angular/core/testing';

// import { BookingConfirmationScreenComponent } from './booking-confirmation-screen.component';

// describe('BookingConfirmationScreenComponent', () => {
//   let component: BookingConfirmationScreenComponent;
//   let fixture: ComponentFixture<BookingConfirmationScreenComponent>;

//   beforeEach(() => {
//     TestBed.configureTestingModule({
//       declarations: [BookingConfirmationScreenComponent]
//     });
//     fixture = TestBed.createComponent(BookingConfirmationScreenComponent);
//     component = fixture.componentInstance;
//     fixture.detectChanges();
//   });

//   it('should create', () => {
//     expect(component).toBeTruthy();
//   });
// });

import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';
import { Observable, of } from 'rxjs';
import { BookingConfirmationScreenComponent } from './booking-confirmation-screen.component';
import { BookingConfirmationService } from 'src/app/services/booking-confirmation.service';
import { BookingDetails } from 'src/app/model/bookingdetails';

fdescribe('BookingConfirmationScreenComponent', () => {
    let component: BookingConfirmationScreenComponent;
    let fixture: ComponentFixture<BookingConfirmationScreenComponent>;
    let mockService: jasmine.SpyObj<BookingConfirmationService>;

    beforeEach(() => {
        mockService = jasmine.createSpyObj('BookingConfirmationService', ['getBookingDetails']);

        TestBed.configureTestingModule({
            declarations: [ BookingConfirmationScreenComponent ],
            providers: [
                { provide: BookingConfirmationService, useValue: mockService },
                { provide: ActivatedRoute, useValue: { snapshot: { paramMap: { get: () => '123' } } } }
            ]
        });

        fixture = TestBed.createComponent(BookingConfirmationScreenComponent);
        component = fixture.componentInstance;
    });

    it('should create the component', () => {
        expect(component).toBeTruthy();
    });

    it('should get bookingId from ActivatedRoute on initialization', () => {
        fixture.detectChanges();
        expect(component.bookingId).toBe(1);
    });

    it('should call getBookingDetails of the service when bookingId is not null', () => {
    const bookingDetails:Observable<BookingDetails>= mockService.getBookingDetails(1);
      component.getBookingDetails()
      expect(mockService.getBookingDetails).toHaveBeenCalledWith(1);
  });
  

    it('should not call getBookingDetails of the service when bookingId is null', () => {
        component.bookingId = -1;

        component.getBookingDetails();

        expect(mockService.getBookingDetails).not.toHaveBeenCalled();
    });
});


