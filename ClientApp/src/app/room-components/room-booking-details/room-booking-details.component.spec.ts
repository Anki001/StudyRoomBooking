import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomBookingDetailsComponent } from './room-booking-details.component';

describe('RoomBookingDetailsComponent', () => {
  let component: RoomBookingDetailsComponent;
  let fixture: ComponentFixture<RoomBookingDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RoomBookingDetailsComponent]
    });
    fixture = TestBed.createComponent(RoomBookingDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
