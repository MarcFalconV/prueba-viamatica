USE cine_demo;
GO

CREATE OR ALTER PROCEDURE sp_ConsultaPeliculasSala
    @nombrePelicula VARCHAR(100) = NULL,
    @fecha DATETIME = NULL,
    @nombreSala VARCHAR(100) = NULL
AS
BEGIN

    IF @nombrePelicula IS NOT NULL
    BEGIN
        SELECT id_pelicula, nombre, duracion
        FROM pelicula
        WHERE nombre LIKE '%' + @nombrePelicula + '%'
          AND activo = 1;
    END

    IF @fecha IS NOT NULL
    BEGIN
        IF @fecha IS NULL
        BEGIN
            SELECT 'Fecha no válida' AS Mensaje;
            RETURN;
        END

        SELECT p.nombre AS Pelicula, s.nombre AS Sala, ps.fecha_publicacion
        FROM pelicula_salacine ps
        JOIN pelicula p ON ps.id_pelicula = p.id_pelicula
        JOIN sala_cine s ON ps.id_sala_cine = s.id_sala
        WHERE CAST(ps.fecha_publicacion AS DATE) = CAST(@fecha AS DATE);
    END

    IF @nombreSala IS NOT NULL
    BEGIN
        DECLARE @total INT;

        SELECT @total = COUNT(*)
        FROM pelicula_salacine ps
        JOIN sala_cine s ON ps.id_sala_cine = s.id_sala
        WHERE s.nombre = @nombreSala
          AND s.activo = 1;

        IF @total < 3
            SELECT 'Sala disponible' AS Mensaje;
        ELSE IF @total BETWEEN 3 AND 5
            SELECT 'Sala con ' + CAST(@total AS VARCHAR) + ' películas asignadas' AS Mensaje;
        ELSE
            SELECT 'Sala no disponible' AS Mensaje;
    END

END
GO
