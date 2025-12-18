import { Component } from '@angular/core';
import { DashboardService } from '../../services/dashboard/dashboard';
import { PeliculaComponent } from '../pelicula/pelicula';
import { SalaComponent } from '../sala/sala';
import { AsignacionComponent } from '../asignacion/asignacion';
import { NavbarComponent } from '../navbar/navbar';

@Component({
  selector: 'app-dashboard',
  imports: [
    PeliculaComponent,
    SalaComponent,
    AsignacionComponent,
    NavbarComponent,
  ],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css',
})
export class DashboardComponent {
  totalSalas: number = 0;
  salasDisponibles: number = 0;
  totalPeliculas: number = 0;

  constructor(private dashboardService: DashboardService) {}

  ngOnInit(): void {
    this.dashboardService.getIndicadores().subscribe((data) => {
      this.totalSalas = data.totalSalas;
      this.salasDisponibles = data.salasDisponibles;
      this.totalPeliculas = data.totalPeliculas;
    });
  }
}
