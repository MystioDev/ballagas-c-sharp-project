-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Máj 22. 13:38
-- Kiszolgáló verziója: 10.4.28-MariaDB
-- PHP verzió: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `graduation`
--

CREATE DATABASE graduation

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `products`
--

CREATE TABLE `products` (
  `schoolName` varchar(100) NOT NULL,
  `className` varchar(20) NOT NULL,
  `classYears` varchar(50) NOT NULL,
  `message` varchar(255) NOT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `products`
--

INSERT INTO `products` (`schoolName`, `className`, `classYears`, `message`, `id`) VALUES
('\r\nSiófoki SZC Mathiász János Technikum és Gimnázium', '12/A', '2020-2024', 'üzenet 1', 1),
('\r\nSiófoki SZC Mathiász János Technikum és Gimnázium', '12/D', '2020-2024', 'üzenet 2', 2),
('\r\nSiófoki SZC Mathiász János Technikum és Gimnázium', '12/E', '2020-2024', 'üzenet 3', 3),
('\r\nSiófoki SZC Mathiász János Technikum és Gimnázium', '12/F', '2020-2024', 'üzenet 4', 4),
('\r\nSiófoki SZC Mathiász János Technikum és Gimnázium', '12/G', '2020-2024', 'üzenet 5', 5),
('\r\nSiófoki SZC Mathiász János Technikum és Gimnázium', '12/B', '2020-2024', 'üzenet 6', 6);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `products`
--
ALTER TABLE `products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
