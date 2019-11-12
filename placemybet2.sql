-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 12-11-2019 a las 23:38:11
-- Versión del servidor: 10.4.6-MariaDB
-- Versión de PHP: 7.3.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `placemybet2`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `apuestas`
--

CREATE TABLE `apuestas` (
  `ApuestaId` int(11) NOT NULL,
  `TipoMercado` float NOT NULL,
  `isOver` bit(1) NOT NULL,
  `Cuota` float NOT NULL,
  `Apostado` double NOT NULL,
  `UsuarioId` int(11) NOT NULL,
  `MercadoId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `apuestas`
--

INSERT INTO `apuestas` (`ApuestaId`, `TipoMercado`, `isOver`, `Cuota`, `Apostado`, `UsuarioId`, `MercadoId`) VALUES
(635, 1.5, b'0', 1.9, 20, 4, 1),
(636, 2.5, b'1', 1.9, 34, 4, 2),
(637, 2.5, b'1', 1.65896, 100, 4, 2),
(638, 1.5, b'1', 2.09, 1, 4, 1),
(639, 1.5, b'1', 2.07871, 3, 4, 1),
(640, 1.5, b'1', 2.04615, 5, 4, 1),
(641, 1.5, b'1', 1.99587, 12, 4, 1),
(642, 1.5, b'1', 1.89215, 12, 4, 1),
(643, 3.5, b'1', 2.21667, 100, 5, 43),
(644, 3.5, b'1', 1.9, 124, 5, 43),
(645, 1.5, b'1', 1.80714, 10, 4, 1),
(646, 2.5, b'1', 1.35598, 100, 4, 2),
(647, 2.5, b'1', 1.23443, 100, 4, 2),
(648, 3.5, b'0', 2.1945, 2, 5, 43),
(649, 2.5, b'1', 1.9, 6, 5, 48),
(650, 2.5, b'0', 1.957, 20, 5, 48),
(652, 1.5, b'1', 1.88007, 1, 5, 1),
(653, 1.5, b'1', 1.87361, 10, 5, 1),
(654, 1.5, b'1', 1.9, 3, 5, 50),
(655, 3.5, b'1', 1.9, 20.5, 3, 49),
(656, 3.5, b'1', 1.73838, 11, 3, 49),
(657, 1.5, b'1', 1.87233, 500, 5, 50);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuentas`
--

CREATE TABLE `cuentas` (
  `CuentaId` int(11) NOT NULL,
  `Banco` longtext DEFAULT NULL,
  `NumeroTarjeta` bigint(20) NOT NULL,
  `Saldo` double NOT NULL,
  `Email` longtext DEFAULT NULL,
  `UsuarioId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `cuentas`
--

INSERT INTO `cuentas` (`CuentaId`, `Banco`, `NumeroTarjeta`, `Saldo`, `Email`, `UsuarioId`) VALUES
(1, 'Bankia', 1234123412341234, 2000, 'pepe@gmail.com', 1),
(2, 'Cajamar', 1234432145679874, 20000, 'clara@mm.com', 3);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `eventos`
--

CREATE TABLE `eventos` (
  `EventoId` int(11) NOT NULL,
  `Fecha` datetime(6) NOT NULL,
  `Local` longtext DEFAULT NULL,
  `GolesLocal` int(11) NOT NULL,
  `Visitante` longtext DEFAULT NULL,
  `GolesVisitante` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `eventos`
--

INSERT INTO `eventos` (`EventoId`, `Fecha`, `Local`, `GolesLocal`, `Visitante`, `GolesVisitante`) VALUES
(2, '2020-01-09 12:47:28.277057', 'Cáceres', 0, 'Albaida', 0),
(3, '2029-10-30 12:47:28.000000', 'Ontinyent', 0, 'Albaida', 0),
(5, '2029-10-30 13:47:28.277057', 'Sevilla', 0, 'Getafe', 0),
(6, '2029-10-30 12:39:28.277057', 'L\'Olleria', 0, 'Gandia', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `mercados`
--

CREATE TABLE `mercados` (
  `MercadoId` int(11) NOT NULL,
  `TipoMercado` float NOT NULL,
  `CuotaOver` float NOT NULL,
  `CuotaUnder` float NOT NULL,
  `DineroOver` double NOT NULL,
  `DineroUnder` double NOT NULL,
  `EventoId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `mercados`
--

INSERT INTO `mercados` (`MercadoId`, `TipoMercado`, `CuotaOver`, `CuotaUnder`, `DineroOver`, `DineroUnder`, `EventoId`) VALUES
(1, 1.5, 1.81364, 1.995, 154, 140, 2),
(2, 2.5, 1.16889, 5.073, 434, 100, 2),
(43, 3.5, 1.67882, 2.18831, 524, 402, 5),
(45, 2.5, 1.9, 1.9, 100, 100, 5),
(46, 1.5, 1.9, 1.9, 100, 100, 6),
(47, 3.5, 1.9, 1.9, 100, 100, 2),
(48, 2.5, 2.02547, 1.78917, 106, 120, 6),
(49, 3.5, 1.67243, 2.19925, 131.5, 100, 6),
(50, 1.5, 1.10755, 6.6785, 603, 100, 5),
(51, 1.5, 1.9, 1.9, 100, 100, 3),
(52, 2.5, 1.9, 1.9, 100, 100, 3);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `UsuarioId` int(11) NOT NULL,
  `Email` longtext DEFAULT NULL,
  `Nombre` longtext DEFAULT NULL,
  `Apellidos` longtext DEFAULT NULL,
  `Edad` int(11) NOT NULL,
  `Fondos` double NOT NULL,
  `Administrador` bit(1) NOT NULL,
  `Password` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`UsuarioId`, `Email`, `Nombre`, `Apellidos`, `Edad`, `Fondos`, `Administrador`, `Password`) VALUES
(1, 'pepe@gmail.com', 'Pepe', 'Sanchez', 29, 0, b'0', 'Abc123%'),
(2, 'anagarcia@gmail.com', 'Ana', 'Garcia', 33, 0, b'1', 'aBc123%'),
(3, 'clara@mm.com', 'Clara', 'Olivares Olivares', 30, 2000, b'0', '1234'),
(4, 'rodrigo@malaga8.com', 'Rodrigo', 'Alberdi', 26, 14, b'1', 'mm810'),
(5, 'josebeniso@hotmail.com', 'Jose', 'Roig Lluch', 29, 3000, b'0', 'jose'),
(6, 'sdf@sdf', 'Andrés', 'Pérez', 30, 0, b'0', '4321'),
(13, 'sample@sample.com', 'Juan', 'Sample', 60, 0, b'0', 'Mm810.'),
(14, 'sampleAdmin@gmail.com', 'Admin', 'Istrador', 40, 0, b'0', 'Mm810.');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20191030111718_m1', '2.2.6-servicing-10079'),
('20191030114729_m2', '2.2.6-servicing-10079');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `apuestas`
--
ALTER TABLE `apuestas`
  ADD PRIMARY KEY (`ApuestaId`),
  ADD KEY `IX_Apuestas_MercadoId` (`MercadoId`),
  ADD KEY `IX_Apuestas_UsuarioId` (`UsuarioId`);

--
-- Indices de la tabla `cuentas`
--
ALTER TABLE `cuentas`
  ADD PRIMARY KEY (`CuentaId`),
  ADD UNIQUE KEY `IX_Cuentas_UsuarioId` (`UsuarioId`);

--
-- Indices de la tabla `eventos`
--
ALTER TABLE `eventos`
  ADD PRIMARY KEY (`EventoId`);

--
-- Indices de la tabla `mercados`
--
ALTER TABLE `mercados`
  ADD PRIMARY KEY (`MercadoId`),
  ADD KEY `IX_Mercados_EventoId` (`EventoId`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`UsuarioId`);

--
-- Indices de la tabla `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `apuestas`
--
ALTER TABLE `apuestas`
  MODIFY `ApuestaId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=658;

--
-- AUTO_INCREMENT de la tabla `cuentas`
--
ALTER TABLE `cuentas`
  MODIFY `CuentaId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `eventos`
--
ALTER TABLE `eventos`
  MODIFY `EventoId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT de la tabla `mercados`
--
ALTER TABLE `mercados`
  MODIFY `MercadoId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=53;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `UsuarioId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `apuestas`
--
ALTER TABLE `apuestas`
  ADD CONSTRAINT `FK_Apuestas_Mercados_MercadoId` FOREIGN KEY (`MercadoId`) REFERENCES `mercados` (`MercadoId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Apuestas_Usuarios_UsuarioId` FOREIGN KEY (`UsuarioId`) REFERENCES `usuarios` (`UsuarioId`) ON DELETE CASCADE;

--
-- Filtros para la tabla `cuentas`
--
ALTER TABLE `cuentas`
  ADD CONSTRAINT `FK_Cuentas_Usuarios_UsuarioId` FOREIGN KEY (`UsuarioId`) REFERENCES `usuarios` (`UsuarioId`) ON DELETE CASCADE;

--
-- Filtros para la tabla `mercados`
--
ALTER TABLE `mercados`
  ADD CONSTRAINT `FK_Mercados_Eventos_EventoId` FOREIGN KEY (`EventoId`) REFERENCES `eventos` (`EventoId`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
