import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EventsComponent } from './components/events-comp/events.component';
import { SpeakerComponent } from './components/speaker-comp/speaker.component';
import { ProfileComponent } from './components/profile/profile.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ContactsComponent } from './components/contacts/contacts.component';

const routes: Routes = [
  {path: 'events', component: EventsComponent},
  {path: 'speaker', component: SpeakerComponent},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'profile', component: ProfileComponent},
  {path: 'contact', component: ContactsComponent},
  {path: '', redirectTo: 'dashboard', pathMatch:'full'},
  {path: '**', redirectTo: 'dashboard', pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
