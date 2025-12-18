import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ISala } from '../components/sala/sala';

@Injectable({
  providedIn: 'root',
})
export class SalaService {
  private apiUrl = 'http://localhost:5144/api/salas'; // URL de tu API

  constructor(private http: HttpClient) {}

  getSalas(): Observable<ISala[]> {
    return this.http.get<ISala[]>(this.apiUrl);
  }

  agregarSala(sala: ISala): Observable<ISala> {
    return this.http.post<ISala>(this.apiUrl, sala);
  }

  actualizarSala(sala: ISala): Observable<ISala> {
    return this.http.put<ISala>(`${this.apiUrl}/${sala.id}`, sala);
  }

  eliminarSala(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
