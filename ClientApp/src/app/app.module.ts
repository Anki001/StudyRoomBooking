import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './shared-component/navbar/navbar.component';
import { FooterComponent } from './shared-component/footer/footer.component';
import { HomeComponent } from './home/home.component';
import { RoomBookingDetailsComponent } from './room-components/room-booking-details/room-booking-details.component';
import { RoomScreenComponent } from './room-components/room-screen/room-screen.component';
import { BookingConfirmationScreenComponent } from './room-components/booking-confirmation-screen/booking-confirmation-screen.component';
import { BookingRegistrationComponent } from './room-components/booking-registration/booking-registration.component';
import { ContactUsComponent } from './shared-component/contact-us/contact-us.component';
import {  StudyRoomService } from './services/studyroom.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    HomeComponent,
    RoomBookingDetailsComponent,
    RoomScreenComponent,
    BookingConfirmationScreenComponent,
    BookingRegistrationComponent,
    ContactUsComponent,
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [StudyRoomService],
  bootstrap: [AppComponent]
})
export class AppModule { }
