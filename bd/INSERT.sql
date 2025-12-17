USE cine_demo;
GO

DECLARE @IdPeliA INT, @IdPeliB INT, @IdPeliC INT, @IdPeliD INT;
DECLARE @IdSalaA INT, @IdSalaB INT;

INSERT INTO pelicula (nombre, duracion, activo) 
VALUES ('Dune: Part Two', 165, 1);
SET @IdPeliA = SCOPE_IDENTITY();

INSERT INTO pelicula (nombre, duracion, activo) 
VALUES ('Oppenheimer', 180, 1);
SET @IdPeliB = SCOPE_IDENTITY();

INSERT INTO pelicula (nombre, duracion, activo) 
VALUES ('The Matrix', 136, 1);
SET @IdPeliC = SCOPE_IDENTITY();

INSERT INTO pelicula (nombre, duracion, activo) 
VALUES ('Blade Runner 2049', 164, 1);
SET @IdPeliD = SCOPE_IDENTITY();

INSERT INTO pelicula (nombre, duracion, activo) 
VALUES ('Pelicula Inactiva Demo', 100, 0);

INSERT INTO sala_cine (nombre, estado, activo) 
VALUES ('Sala Digital 01', 1, 1);
SET @IdSalaA = SCOPE_IDENTITY();

INSERT INTO sala_cine (nombre, estado, activo) 
VALUES ('Sala Dolby Atmos', 1, 1);
SET @IdSalaB = SCOPE_IDENTITY();

INSERT INTO sala_cine (nombre, estado, activo) 
VALUES ('Sala Cerrada Temporal', 0, 1);

INSERT INTO pelicula_salacine (id_sala_cine, id_pelicula, fecha_publicacion, fecha_fin)
VALUES
(@IdSalaA, @IdPeliA, '2026-01-05 14:30:00', '2026-01-20 22:00:00'),
(@IdSalaA, @IdPeliB, '2026-01-05 18:00:00', '2026-01-20 22:00:00');

INSERT INTO pelicula_salacine (id_sala_cine, id_pelicula, fecha_publicacion, fecha_fin)
VALUES
(@IdSalaB, @IdPeliC, '2026-01-05 15:00:00', '2026-01-25 23:59:59'),
(@IdSalaB, @IdPeliD, '2026-01-05 19:00:00', '2026-01-25 23:59:59'),
(@IdSalaB, @IdPeliA, '2026-01-06 21:30:00', '2026-01-25 23:59:59');
