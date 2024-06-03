CREATE DATABASE laboratoriocrud;
USE laboratoriocrud;

CREATE TABLE personajes (id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    juego VARCHAR(100) NOT NULL,
    clase VARCHAR(50),
    nivel INT,
    habilidades TEXT,
    consola VARCHAR(50),
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO personajes (nombre, juego, clase, nivel, consola, habilidades, fecha_creacion)
VALUES 
('Mario', 'Super Mario', 'Plomero', 50, 'Nintendo', 'Salto, Lanzar Fuego', '1985-09-13'),
('Link', 'The Legend of Zelda', 'Héroe', 75, 'Nintendo', 'Espada, Arco, Escudo', '1986-02-21'),
('Samus', 'Metroid', 'Cazadora de Recompensas', 80, 'Nintendo', 'Disparo, Morfosfera', '1986-08-06'),
('Sonic', 'Sonic the Hedgehog', 'Erizo', 90, 'Sega', 'Velocidad, Spin Dash', '1991-06-23'),
('Kratos', 'God of War', 'Dios', 100, 'PlayStation', 'Fuerza, Espadas del Caos', '2005-03-22'),
('Master Chief', 'Halo', 'Soldado', 85, 'Xbox', 'Armas de Fuego, Escudo', '2001-11-15'),
('Lara Croft', 'Tomb Raider', 'Aventurera', 70, 'Multi-Plataforma', 'Arqueología, Combate', '1996-10-25'),
('Pikachu', 'Pokémon', 'Pokémon', 60, 'Nintendo', 'Electricidad, Velocidad', '1996-02-27'),
('Geralt', 'The Witcher', 'Brujo', 90, 'Multi-Plataforma', 'Espada, Magia', '2007-10-26'),
('Cloud Strife', 'Final Fantasy VII', 'Mercenario', 80, 'Multi-Plataforma', 'Espada, Magia', '1997-01-31'),
('Doom Slayer', 'DOOM', 'Guerrero', 95, 'Multi-Plataforma', 'Armas de Fuego, Fuerza', '1993-12-10'),
('Ezio Auditore', 'Assassin’s Creed', 'Asesino', 85, 'Multi-Plataforma', 'Sigilo, Combate', '2009-11-17'),
('Solid Snake', 'Metal Gear Solid', 'Espía', 75, 'Multi-Plataforma', 'Sigilo, Armas de Fuego', '1998-09-03'),
('Ryu', 'Street Fighter', 'Luchador', 70, 'Multi-Plataforma', 'Artes Marciales, Hadouken', '1987-08-30'),
('Sub-Zero', 'Mortal Kombat', 'Luchador', 65, 'Multi-Plataforma', 'Criomancia, Combate', '1992-10-08'),
('Mega Man', 'Mega Man', 'Robot', 60, 'Nintendo', 'Armas de Energía, Salto', '1987-12-17'),
('Pac-Man', 'Pac-Man', 'Comecocos', 50, 'Multi-Plataforma', 'Comer, Velocidad', '1980-05-22'),
('Gordon Freeman', 'Half-Life', 'Científico', 70, 'PC', 'Armas de Fuego, Física', '1998-11-19'),
('Arthur Morgan', 'Red Dead Redemption 2', 'Vaquero', 85, 'Multi-Plataforma', 'Armas de Fuego, Caballo', '2018-10-26'),
('Tracer', 'Overwatch', 'Heroína', 75, 'Multi-Plataforma', 'Velocidad, Teletransporte', '2016-05-24');

 
 Select*from personajes; 
