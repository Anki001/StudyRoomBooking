import { ComponentFixture, TestBed } from '@angular/core/testing';
import { DebugElement } from '@angular/core';
import { By } from '@angular/platform-browser';
import { RoomBookingDetailsComponent } from './room-booking-details.component';
import { HttpClientTestingModule } from '@angular/common/http/testing'; // Import HttpClientTestingModule // Import your ApiServiceService
import { ApiServiceService } from 'src/shared/services/api-service.service';

describe('RoomBookingDetailsComponent', () => {
  let component: RoomBookingDetailsComponent;
  let fixture: ComponentFixture<RoomBookingDetailsComponent>;
  let debugElement: DebugElement;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RoomBookingDetailsComponent],
      imports: [HttpClientTestingModule], // Add HttpClientTestingModule
      providers: [ApiServiceService], // Provide ApiServiceService
    });

    fixture = TestBed.createComponent(RoomBookingDetailsComponent);
    component = fixture.componentInstance;
    debugElement = fixture.debugElement;
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });
  
});
