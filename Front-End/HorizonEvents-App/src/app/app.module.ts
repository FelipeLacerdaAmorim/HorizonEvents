import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule, Title } from '@angular/platform-browser';
import { BrowserAnimationsModule} from '@angular/platform-browser/animations'
import { HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';

//ngx modules
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';

import { ToastrModule } from 'ngx-toastr';

import { NgxSpinnerModule } from 'ngx-spinner';

//Components
import { AppComponent } from './app.component';
import { EventsComponent } from './components/events-comp/events.component';
import { SpeakerComponent } from './components/speaker-comp/speaker.component';
import { NavComponent } from './nav-comp/nav.component';
import { ContactsComponent } from './components/contacts/contacts.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ProfileComponent } from './components/profile/profile.component';
import { TitleComponent } from './shared/title/title.component';

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { FormsModule } from '@angular/forms';
import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';

@NgModule({
  declarations: [
    AppComponent,
    EventsComponent,
    SpeakerComponent,
    NavComponent,
    DateTimeFormatPipe,
    TitleComponent,
    ContactsComponent,
    DashboardComponent,
    ProfileComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    FormsModule,
    TooltipModule.forRoot(),
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true
    }),
    NgxSpinnerModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule { }
