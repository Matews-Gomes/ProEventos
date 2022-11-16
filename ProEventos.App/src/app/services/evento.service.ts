import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';

  @Injectable()

  export class EventoService {
    baseUrl = 'https://localhost:7210/api/eventos';
  constructor(private http: HttpClient) { }

    public getEvent(): Observable<Evento[]>{
      return this.http.get<Evento[]>(this.baseUrl)
    }

    public getEventById(id_evento: number): Observable<Evento>{
      return this.http.get<Evento>(`${this.baseUrl}/${id_evento}`)
    }
}
