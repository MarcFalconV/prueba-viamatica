import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { PeliculaService } from '../../services/pelicula';

export interface IPelicula {
  idPelicula: number;
  nombre: string;
  duracion: number;
}

@Component({
  selector: 'app-pelicula',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './pelicula.html',
  styleUrl: './pelicula.css',
})
export class PeliculaComponent {
  peliculaForm: FormGroup;
  peliculas: IPelicula[] = [];
  editarId: number | null = null;

  constructor(
    private fb: FormBuilder,
    private peliculaService: PeliculaService
  ) {
    this.peliculaForm = this.fb.group({
      nombre: ['', [Validators.required, Validators.minLength(2)]],
      duracion: ['', [Validators.required, Validators.min(1)]],
    });
  }

  ngOnInit(): void {
    this.cargarPeliculas();
  }

  cargarPeliculas(): void {
    this.peliculaService.getPeliculas().subscribe((data) => {
      this.peliculas = data;
      this.peliculaForm.reset();
      this.editarId = null;
    });
  }

  editar(id: number): void {
    const pelicula = this.peliculas.find((p) => p.idPelicula === id);
    if (!pelicula) return;
    console.log('', this.editarId);
    this.editarId = pelicula.idPelicula;
    this.peliculaForm.setValue({
      nombre: pelicula.nombre,
      duracion: pelicula.duracion,
    });
    console.log('', this.editarId);
    console.log('', this.peliculaForm);
  }

  guardar(): void {
    if (this.peliculaForm.invalid) return;

    const peliculaData: IPelicula = {
      idPelicula: this.editarId ?? 0,
      nombre: this.peliculaForm.value.nombre,
      duracion: this.peliculaForm.value.duracion,
    };

    if (this.editarId) {
      this.peliculaService.actualizarPelicula(peliculaData).subscribe(() => {
        this.cargarPeliculas();
      });
    } else {
      this.peliculaService.agregarPelicula(peliculaData).subscribe(() => {
        this.cargarPeliculas();
      });
    }
  }

  eliminar(id: number): void {
    console.log(id);
    this.peliculaService.eliminarPelicula(id).subscribe(() => {
      this.cargarPeliculas();
    });
  }
}
