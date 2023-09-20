import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookingConfirmationScreenComponent } from './booking-confirmation-screen.component';

describe('BookingConfirmationScreenComponent', () => {
  let component: BookingConfirmationScreenComponent;
  let fixture: ComponentFixture<BookingConfirmationScreenComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BookingConfirmationScreenComponent]
    });
    fixture = TestBed.createComponent(BookingConfirmationScreenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
