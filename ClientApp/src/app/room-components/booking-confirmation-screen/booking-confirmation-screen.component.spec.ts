import { ComponentFixture, TestBed } from '@angular/core/testing';
import { BookingConfirmationScreenComponent } from './booking-confirmation-screen.component';
import { ActivatedRoute } from '@angular/router';
import { BookingConfirmationService } from 'src/app/services/booking-confirmation.service';
import { bookingDetailsArray } from 'src/assets/data/dummy-booking-details';
import { BookingDetails } from 'src/app/model/bookingdetails';

fdescribe('BookingConfirmationScreenComponent', () => {
  let component: BookingConfirmationScreenComponent;
  let fixture: ComponentFixture<BookingConfirmationScreenComponent>;

  const mockActivatedRoute = {
    snapshot: {
      paramMap: {
        get: jasmine.createSpy('get').and.returnValue(1) 
      }
    }
  };

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookingConfirmationScreenComponent ],
      providers: [
        { provide: ActivatedRoute, useValue: mockActivatedRoute },
        { provide: BookingConfirmationService, useValue: {} }  // Assuming you don't call any service method in the current provided component code
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BookingConfirmationScreenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should set bookingId from route parameter', () => {
    expect(component.bookingId).toEqual(1); 
  });

  it('should set bookingDetails from dummy data based on bookingId', () => {
    const BookingDetail:BookingDetails[]  = bookingDetailsArray.filter(data => data.bookingId === 1);
    expect(component.bookingDetails).toEqual(BookingDetail[0]);
  });
});
