import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IPelicula } from './pelicula';

describe('Pelicula', () => {
  let component: IPelicula;
  let fixture: ComponentFixture<IPelicula>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IPelicula],
    }).compileComponents();

    fixture = TestBed.createComponent(IPelicula);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
