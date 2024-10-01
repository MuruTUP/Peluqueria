DROP DATABASE Peluqueria
GO
CREATE DATABASE Peluqueria
GO
USE Peluqueria
GO
CREATE TABLE Servicio(
	id			INT IDENTITY(1,1),
	nombre		VARCHAR(25),
	costo		FLOAT,
	enPromocion	BIT

	CONSTRAINT pk_id_servicio PRIMARY KEY(id)
)



CREATE TABLE Turno(
	id		INT IDENTITY(1,1),
	fecha	DATETIME,
	hora	TIME,
	cliente	VARCHAR(50)

	CONSTRAINT pk_id_turno PRIMARY KEY (id)
)

CREATE TABLE DetalleTurno(
	id_turno		INT,
	id_servicio		INT,
	observaciones VARCHAR(50)

	CONSTRAINT pk_id_detalle_turno PRIMARY KEY (id_turno, id_servicio),
	CONSTRAINT fk_id_turno FOREIGN KEY(id_turno)
		REFERENCES Turno(id) ,
	CONSTRAINT fk_id_servicio_detalleTurno FOREIGN KEY (id_servicio)
		REFERENCES Servicio(id)
)
GO

INSERT INTO Servicio (nombre, costo, enPromocion) 
VALUES
	('Corte de Cabello', 25.00, 1),
	('Manicura', 15.50, 0),
	('Pedicura', 18.00, 1),
	('Tinte de Cabello', 40.75, 0),
	('Depilación', 20.00, 1),
	('Masaje', 35.00, 0);

INSERT INTO Turno (fecha, hora, cliente) 
VALUES
	('2024-09-30', '10:00:00', 'Juan Pérez'),
	('2024-09-30', '11:30:00', 'María Gómez'),
	('2024-09-30', '13:00:00', 'Carlos Ramírez'),
	('2024-10-01', '09:30:00', 'Ana López'),
	('2024-10-01', '11:00:00', 'Luis Sánchez');

INSERT INTO DetalleTurno (id_turno, id_servicio, observaciones) 
VALUES
	(1, 1, 'Corte moderno'),
	(1, 2, 'Manicura francesa'),
	(2, 4, 'Tinte completo'),
	(3, 5, 'Depilación con cera'),
	(4, 1, 'Corte de cabello estándar'),
	(5, 6, 'Masaje relajante');

	select * from DetalleTurno