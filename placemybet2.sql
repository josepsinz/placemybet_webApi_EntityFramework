-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 30-10-2019 a las 13:59:28
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
(1, 2.5, b'1', 1.9, 25, 1, 2),
(2, 1.5, b'0', 1.9, 50, 1, 1);

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
(1, 'Bankia', 1234123412341234, 2000, 'pepe@gmail.com', 1);

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
(1, '2019-10-30 12:47:28.274058', 'Alicante', 0, 'Sueca', 0),
(2, '2019-10-30 12:47:28.277057', 'Cáceres', 0, 'Albaida', 0),
(3, '2029-10-30 12:47:28.000000', 'Ontinyent', 0, 'Albaida', 5),
(5, '2029-10-30 12:47:28.277057', 'Sevilla', 0, 'Getafe', 0),
(6, '2029-10-30 12:47:28.277057', 'Villareal', 0, 'Gandia', 5);

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
(1, 1.5, 1.9, 1.9, 105, 100, 2),
(2, 2.5, 1.9, 1.9, 100, 100, 2);

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
(2, 'anagarcia@gmail.com', 'Ana', 'Garcia', 33, 0, b'1', 'aBc123%');

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
  MODIFY `ApuestaId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `cuentas`
--
ALTER TABLE `cuentas`
  MODIFY `CuentaId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `eventos`
--
ALTER TABLE `eventos`
  MODIFY `EventoId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `mercados`
--
ALTER TABLE `mercados`
  MODIFY `MercadoId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `UsuarioId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

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
