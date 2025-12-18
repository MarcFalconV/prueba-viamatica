import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login';
import { DashboardComponent } from './components/dashboard/dashboard';
import { AsignacionComponent } from './components/asignacion/asignacion';
import { PeliculaComponent } from './components/pelicula/pelicula';
import { SalaComponent } from './components/sala/sala';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'peliculas', component: PeliculaComponent },
  { path: 'salas', component: SalaComponent },
  { path: 'asignaciones', component: AsignacionComponent },
  { path: '**', redirectTo: '' },
];
