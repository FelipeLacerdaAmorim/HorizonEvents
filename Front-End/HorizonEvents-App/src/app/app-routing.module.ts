import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EventsComponent } from './components/events-comp/events.component';
import { SpeakerComponent } from './components/speaker-comp/speaker.component';
import { ProfileComponent } from './components/user/profile/profile.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ContactsComponent } from './components/contacts/contacts.component';
import { EventDetailComponent } from './components/events-comp/event-detail/event-detail.component';
import { EventListComponent } from './components/events-comp/event-list/event-list.component';
import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';

const routes: Routes = [
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'registration', component: RegistrationComponent}
    ]
  },
  { path: 'events', redirectTo: 'events/list'},
  {
    path: 'events', component: EventsComponent,
    children: [
      { path: 'detail/:id', component: EventDetailComponent },
      { path: 'detail', component: EventDetailComponent },
      { path: 'list', component: EventListComponent },
    ]
  },
  {path: 'speaker', component: SpeakerComponent},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'user/profile', component: ProfileComponent},
  {path: 'contact', component: ContactsComponent},
  {path: '', redirectTo: 'dashboard', pathMatch:'full'},
  {path: '**', redirectTo: 'dashboard', pathMatch:'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
