import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';

interface IPelicula {
  id: number;
  nombre: string;
}

interface ISala {
  id: number;
  nombre: string;
  disponible: boolean;
}

interface IAsignacion {
  salaId: number;
  peliculaId: number;
}

@Component({
  selector: 'app-asignacion',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './asignacion.html',
  styleUrl: './asignacion.css',
})
export class AsignacionComponent {
  asignacionForm: FormGroup;
  peliculas: IPelicula[] = [];
  salas: ISala[] = [];
  asignaciones: IAsignacion[] = [];

  constructor(private fb: FormBuilder) {
    this.asignacionForm = this.fb.group({
      salaId: [null, Validators.required],
      peliculaId: [null, Validators.required],
    });
  }

  ngOnInit(): void {
    // Datos simulados; reemplazar por llamadas a API
    this.peliculas = [
      { id: 1, nombre: 'Película A' },
      { id: 2, nombre: 'Película B' },
      { id: 3, nombre: 'Película C' },
    ];

    this.salas = [
      { id: 1, nombre: 'Sala 1', disponible: true },
      { id: 2, nombre: 'Sala 2', disponible: true },
      { id: 3, nombre: 'Sala 3', disponible: false },
    ];
  }

  guardar(): void {
    if (this.asignacionForm.invalid) return;

    const salaId = this.asignacionForm.value.salaId;
    const peliculaId = this.asignacionForm.value.peliculaId;

    // Validación: evitar asignaciones duplicadas o a salas no disponibles
    const conflicto = this.asignaciones.find((a) => a.salaId === salaId);
    const sala = this.salas.find((s) => s.id === salaId);

    if (conflicto) {
      alert('Esta sala ya tiene una película asignada.');
      return;
    }

    if (!sala?.disponible) {
      alert('La sala seleccionada no está disponible.');
      return;
    }

    this.asignaciones.push({ salaId, peliculaId });
    this.asignacionForm.reset();
  }

  eliminar(index: number): void {
    this.asignaciones.splice(index, 1);
  }

  obtenerNombreSala(salaId: number): string {
    return this.salas.find((s) => s.id === salaId)?.nombre || '';
  }

  obtenerNombrePelicula(peliculaId: number): string {
    return this.peliculas.find((p) => p.id === peliculaId)?.nombre || '';
  }
}
