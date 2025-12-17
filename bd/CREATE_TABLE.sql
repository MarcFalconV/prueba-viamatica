CREATE DATABASE cine_demo

USE cine_demo

CREATE TABLE pelicula (
    id_pelicula INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(255) NOT NULL,
    duracion INT NOT NULL,
    activo BIT DEFAULT 1
);

CREATE TABLE sala_cine (
    id_sala INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    estado INT NOT NULL,
    activo BIT DEFAULT 1 
);

CREATE TABLE pelicula_salacine (
    id_pelicula_sala INT PRIMARY KEY IDENTITY(1,1),
    id_sala_cine INT NOT NULL,
    id_pelicula INT NOT NULL,
    fecha_publicacion DATETIME NOT NULL,
    fecha_fin DATETIME NOT NULL,
    
    CONSTRAINT FK_PeliculaSalacine_Pelicula FOREIGN KEY (id_pelicula) 
        REFERENCES pelicula(id_pelicula),
    CONSTRAINT FK_PeliculaSalacine_SalaCine FOREIGN KEY (id_sala_cine) 
        REFERENCES sala_cine(id_sala)
);
