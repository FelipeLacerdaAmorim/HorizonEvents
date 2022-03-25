import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  baseURL = 'https://localhost:5001/api/events';

constructor(private http: HttpClient) { }

  getEvents(): Observable<Event[]> {
    return this.http.get<Event[]>(this.baseURL);
  }

  getEventsbyTheme(theme: string): Observable<Event[]> {
    return this.http.get<Event[]>(`${this.baseURL}/theme/${theme}`);
  }

  getEventById(id: number): Observable<Event> {
    return this.http.get<Event>(`${this.baseURL}/${id}`);
  }
}
