import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';

export interface ISala {
  id: number;
  nombre: string;
  capacidad: number;
  disponible: boolean;
}

@Component({
  selector: 'app-sala',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './sala.html',
  styleUrl: './sala.css',
})
export class SalaComponent {
  salaForm: FormGroup;
  salas: ISala[] = [];
  editarIndex: number | null = null;

  constructor(private fb: FormBuilder) {
    this.salaForm = this.fb.group({
      nombre: ['', [Validators.required, Validators.minLength(2)]],
      capacidad: ['', [Validators.required, Validators.min(1)]],
      disponible: [true, Validators.required],
    });
  }

  ngOnInit(): void {}

  guardar(): void {
    if (this.salaForm.invalid) return;

    const nuevaSala: ISala = {
      id:
        this.editarIndex !== null
          ? this.salas[this.editarIndex].id
          : Date.now(),
      nombre: this.salaForm.value.nombre,
      capacidad: this.salaForm.value.capacidad,
      disponible: this.salaForm.value.disponible,
    };

    if (this.editarIndex !== null) {
      this.salas[this.editarIndex] = nuevaSala;
      this.editarIndex = null;
    } else {
      this.salas.push(nuevaSala);
    }

    this.salaForm.reset({ disponible: true });
  }

  editar(index: number): void {
    this.editarIndex = index;
    const sala = this.salas[index];
    this.salaForm.setValue({
      nombre: sala.nombre,
      capacidad: sala.capacidad,
      disponible: sala.disponible,
    });
  }

  eliminar(index: number): void {
    this.salas.splice(index, 1);
  }
}
