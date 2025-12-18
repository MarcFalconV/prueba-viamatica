import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class Prueba {
  //private apiUrl = 'http://localhost:5120/api/Weather';
  private apiUrl = 'http://localhost:5120/api/Weather';

  constructor(private http: HttpClient) {}

  checkStatus(): Observable<boolean> {
    return this.http
      .get(this.apiUrl, { observe: 'response', responseType: 'text' })
      .pipe(
        map((response: HttpResponse<any>) => {
          return response.status === 200;
        }),
        catchError((error) => {
          console.error('Error en la petición:', error);
          return of(false);
        })
      );
  }
}
