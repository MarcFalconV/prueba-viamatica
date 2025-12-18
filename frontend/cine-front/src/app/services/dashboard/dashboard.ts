import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DashboardService {
   constructor() { }

  getIndicadores(): Observable<{ totalSalas: number, salasDisponibles: number, totalPeliculas: number }> {
    // Datos simulados; se pueden reemplazar con API real en .NET Core
    return of({
      totalSalas: 10,
      salasDisponibles: 6,
      totalPeliculas: 25
    });
  }
}
