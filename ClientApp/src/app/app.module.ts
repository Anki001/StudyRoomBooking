import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { RoomBookingDetailsComponent } from './room-components/room-booking-details/room-booking-details.component';
import { RoomScreenComponent } from './room-components/room-screen/room-screen.component';
import { BookingConfirmationScreenComponent } from './room-components/booking-confirmation-screen/booking-confirmation-screen.component';
import { BookingRegistrationComponent } from './room-components/booking-registration/booking-registration.component';
import { NavbarComponent } from 'src/shared/components/navbar/navbar.component';
import { FooterComponent } from 'src/shared/components/footer/footer.component';
import {HttpClientModule} from '@angular/common/http'
import { ContactUsComponent } from './contact-us/contact-us.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    HomeComponent,
    ContactUsComponent,
    RoomBookingDetailsComponent,
    RoomScreenComponent,
    BookingConfirmationScreenComponent,
    BookingRegistrationComponent,
    ContactUsComponent,
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
