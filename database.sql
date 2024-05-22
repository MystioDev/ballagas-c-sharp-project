-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Máj 22. 20:18
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

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

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `customers`
--

CREATE TABLE `customers` (
  `name` varchar(100) NOT NULL,
  `phone` varchar(50) NOT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `customers`
--

INSERT INTO `customers` (`name`, `phone`, `id`) VALUES
('Példa Név', '+3606999999', 1),
('Példa Béla', '+3606999999', 2),
('Példa Marci', '+3606999999', 3),
('Példa Peti', '+3606999999', 4),
('Példa Géza', '+3606999999', 5),
('Példa Dávid', '+3606999999', 6),
('Példa Dominik', '+3606999999', 7),
('Példa Valaki', '+3606999999', 8),
('customerNameBox', '65449', 9);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `orders`
--

CREATE TABLE `orders` (
  `schoolName` varchar(100) NOT NULL,
  `className` varchar(20) NOT NULL,
  `classYears` varchar(50) NOT NULL,
  `message` varchar(255) NOT NULL,
  `status` varchar(20) NOT NULL DEFAULT 'Beérkezett',
  `pieces` int(11) NOT NULL,
  `customerId` int(11) NOT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `orders`
--

INSERT INTO `orders` (`schoolName`, `className`, `classYears`, `message`, `status`, `pieces`, `customerId`, `id`) VALUES
('\r\nSiófoki SZC Mathiász János Technikum és Gimnázium', '12/A', '2020-2024', 'Üzenet', 'Kézbesítve', 90, 2, 7),
('\r\nSiófoki SZC Mathiász János Technikum és Gimnázium', '12/A', '2020-2024', 'Üzenet', 'Függőben', 50, 5, 8),
('\r\nSiófoki SZC Mathiász János Technikum és Gimnázium', '12/A', '2020-2024', 'Üzenet', 'Függőben', 24, 1, 9),
('\r\nSiófoki SZC Mathiász János Technikum és Gimnázium', '12/A', '2020-2024', 'Üzenet', 'Függőben', 32, 3, 11),
('Bacsák', '12.b', '2000-2024', 'rossz üzenet', 'Függőben', 4, 3, 12),
('Nem bacsák', '12.c', '2024-2032', 'nagypn rossz üzenet', 'Függőben', 5, 4, 13),
('schoolNameBox', 'classNameBox', 'classYearsBox', 'messageBox', 'Beérkezett', 52, 9, 15);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`id`),
  ADD KEY `customerId` (`customerId`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `customers`
--
ALTER TABLE `customers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT a táblához `orders`
--
ALTER TABLE `orders`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`customerId`) REFERENCES `customers` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
