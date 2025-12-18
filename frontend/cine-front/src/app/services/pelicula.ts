import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IPelicula } from '../components/pelicula/pelicula';

@Injectable({ providedIn: 'root' })
export class PeliculaService {
  private apiUrl = 'http://localhost:5120/api/peliculacrud';

  constructor(private http: HttpClient) {}

  getPeliculas(): Observable<IPelicula[]> {
    return this.http.get<IPelicula[]>(this.apiUrl);
  }

  agregarPelicula(pelicula: IPelicula): Observable<IPelicula> {
    return this.http.post<IPelicula>(this.apiUrl, pelicula);
  }

  actualizarPelicula(pelicula: IPelicula): Observable<IPelicula> {
    return this.http.put<IPelicula>(
      `${this.apiUrl}/${pelicula.idPelicula}`,
      pelicula
    );
  }

  eliminarPelicula(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
