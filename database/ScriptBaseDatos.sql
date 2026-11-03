-- =============================================================
-- CATALOGO_WEB_DB - Script completo (esquema y datos)
-- TP Integrador Nivel 3 - Catalizado de articulos
-- Ejecutar en SQL Server (probado sobre SQL Express)
-- =============================================================
IF DB_ID('CATALOGO_WEB_DB') IS NULL
BEGIN
    CREATE DATABASE CATALOGO_WEB_DB;
END
GO

USE CATALOGO_WEB_DB;
GO

-- -------------------------------------------------------------
-- Tablas
-- -------------------------------------------------------------
IF OBJECT_ID('MARCAS') IS NULL
CREATE TABLE MARCAS
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(50) NULL
);

IF OBJECT_ID('CATEGORIAS') IS NULL
CREATE TABLE CATEGORIAS
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(50) NULL
);

IF OBJECT_ID('ARTICULOS') IS NULL
CREATE TABLE ARTICULOS
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(50) NULL,
    Nombre VARCHAR(100) NULL,
    Descripcion VARCHAR(300) NULL,
    IdMarca INT NULL,
    IdCategoria INT NULL,
    ImagenUrl VARCHAR(500) NULL,
    Precio MONEY NULL
);

IF OBJECT_ID('USERS') IS NULL
CREATE TABLE USERS
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    email VARCHAR(100) NOT NULL,
    pass VARCHAR(100) NOT NULL,
    nombre VARCHAR(100) NULL,
    apellido VARCHAR(100) NULL,
    urlImagenPerfil VARCHAR(300) NULL,
    admin BIT NOT NULL DEFAULT ((0))
);

IF OBJECT_ID('FAVORITOS') IS NULL
CREATE TABLE FAVORITOS
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdUser INT NOT NULL,
    IdArticulo INT NOT NULL,
    CONSTRAINT FK_FAVORITOS_Users FOREIGN KEY (IdUser) REFERENCES USERS(Id),
    CONSTRAINT FK_FAVORITOS_Articulos FOREIGN KEY (IdArticulo) REFERENCES ARTICULOS(Id)
);
GO

-- -------------------------------------------------------------
-- Datos
-- -------------------------------------------------------------
IF NOT EXISTS (SELECT 1 FROM MARCAS)
INSERT INTO MARCAS (Descripcion) VALUES ('Samsung'), ('Apple'), ('Sony'), ('Huawei'), ('Motorola');

IF NOT EXISTS (SELECT 1 FROM CATEGORIAS)
INSERT INTO CATEGORIAS (Descripcion) VALUES ('Celulares'), ('Televisores'), ('Media'), ('Audio');

IF NOT EXISTS (SELECT 1 FROM USERS)
INSERT INTO USERS (email, pass, admin) VALUES ('admin@admin.com', 'admin', 1), ('user@user.com', 'user', 0);

IF NOT EXISTS (SELECT 1 FROM ARTICULOS)
INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) VALUES
('S01', 'Galaxy S10', 'Una canoa cara', 1, 1, 'https://images.samsung.com/is/image/samsung/assets/ar/p6_gro2/p6_initial_mktpd/smartphones/galaxy-s10/specs/galaxy-s10-plus_specs_design_colors_prism_black.jpg?$163_346_PNG$', 70),
('M03', 'Moto G Play 7ma Gen', 'Ya siete de estos?', 5, 1, 'https://www.motorola.cl/arquivos/moto-g7-play-img-product.png?v=636862863804700000', 15699),
('S99', 'Play 4', 'Ya no se cuantas versiones hay', 3, 3, 'sin_imagen_para_que_de_error....muejeje', 35000),
('S56', 'Bravia 55', 'Alta tele', 3, 2, 'https://images.fravega.com/f1000/95ed4a639c25dde6b872e94a97a52a9f.jpg', 49500),
('A23', 'Apple TV', 'lindo loro', 2, 3, 'https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/rfb-apple-tv-4k?wid=1144&hei=1144&fmt=jpeg&qlt=80&.v=1513897159574', 7850),
('01020304', 'Play6', 'Lamejor todavia no llego', 3, 3, 'https://juegosdigitalesargentina.com/files/images/noticias/1762296715_5.webp', 2500000);

IF NOT EXISTS (SELECT 1 FROM FAVORITOS)
INSERT INTO FAVORITOS (IdUser, IdArticulo) VALUES (2, 1), (1, 6), (2, 6);
GO
